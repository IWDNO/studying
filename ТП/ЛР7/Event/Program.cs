using System.Diagnostics;

namespace IndustriaProduction
{
    public delegate void LogMessage(string param);
    public class Logger
    {
        public static void Log(string message)
        {
            string timestamp = DateTime.Now.ToString();
            string methodName = new StackTrace().GetFrame(1).GetMethod().Name;
            Console.WriteLine($"#\n# {timestamp} - Method: {methodName} - {message}\n#");
        }
    }

    public class Workshop
    {
        private readonly List<Machine> machines;
        private readonly List<Worker> workers;
        public event LogMessage Log;

        public Workshop()
        {
            machines = new List<Machine>();
            workers = new List<Worker>();
        }

        /// <summary>
        /// Добавить станок в цех
        /// </summary>
        public void AddMachine(Machine machine)

        {
            machines.Add(machine);
            machine.SetBusy(false);
        }

        /// <summary>
        /// Добавить Работника в цех
        /// </summary>
        public void AddWorker(Worker worker)
        {
            workers.Add(worker);
            worker.SetBusy(false);
        }

        /// <summary>
        /// Запуск производства. Каждый свободный станок запускается если найден свободный работник с подходящей должностью
        /// </summary>
        public void StartProduction()
        {
            foreach (Machine machine in machines)
            {
                if (machine.IsBusy()) continue;
                foreach (Worker worker in workers)
                {
                    if (worker.IsBusy()) continue;
                    if (!machine.GetValidPositions().Contains(worker.Position)) continue;
                    machine.SetBusy(true);
                    worker.SetBusy(true);
                    machine.Start(worker);
                    break;
                }
            }
            Log("Производство запущено");
        }

        /// <summary>
        /// Освободить все станки и работников
        /// </summary>
        public void StopProduction()
        {
            foreach (Machine machine in machines)
            {
                machine.SetBusy(false);
            }
            foreach (Worker worker in workers)
            {
                worker.SetBusy(false);
            }
            Log("Производство остановленно");
        }

        /// <summary>
        /// Показать состояние (занятость) производства
        /// </summary>
        public void CheckProduction()
        {
            Log("Проверка состояния производства");
            Console.WriteLine("Состояние производства:");
            foreach (Machine machine in machines)
            {
                string status = machine.IsBusy() ? "работает" : "отдыхает";
                Console.WriteLine($"{machine.Type} #{machine.SerialNumber} {status}");
            }
            Console.WriteLine("-----------------------");
            foreach (Worker worker in workers)
            {
                string status = worker.IsBusy() ? "работает" : "отдыхает";
                Console.WriteLine($"{worker.Name} ({worker.Position}) {status}");
            }
        }
    }

    public enum Position
    {
        Engineer,
        Technician,
        Manager
    }

    public enum Equipment
    {
        LatheMachine,
        PressMachine
    }

    interface IMachine
    {
        Equipment Type { get; }
        int SerialNumber { get; }
        bool IsBusy();
        void SetBusy(bool isBusy);
        void Start(Worker worker);
    }

    interface IWorker
    {
        string Name { get; }
        Position Position { get; }
        bool IsBusy();
        void SetBusy(bool isBusy);
    }

    public abstract class Machine : IMachine
    {
        private readonly Equipment type;
        private readonly int serialNumber;
        private bool isBusy;

        public Machine(Equipment type, int serialNumber)
        {
            this.type = type;
            this.serialNumber = serialNumber;
        }

        public Equipment Type => type;
        public int SerialNumber => serialNumber;

        public bool IsBusy() { return isBusy; }
        public void SetBusy(bool isBusy)
        {
            this.isBusy = isBusy;
        }

        /// <summary>
        /// Запуск станка при помощи работника с подходящей должностью
        /// </summary>
        public void Start(Worker worker)
        {
            if (GetValidPositions().Contains(worker.Position))
            {
                Console.WriteLine($"{type} #{serialNumber} запущен: {worker.Name} ({worker.Position})");
            }
            else
            {
                Console.WriteLine($"{type} не может быть запущен сотрудником с должностью {worker.Position}");
            }
        }

        /// <summary>
        /// Получить спимок доступных должностей для работы на станке 
        /// </summary>
        public abstract List<Position> GetValidPositions();
    }

    class LatheMachine : Machine
    {
        public LatheMachine(int serialNumber) : base(Equipment.LatheMachine, serialNumber) { }

        public override List<Position> GetValidPositions()
        {
            return new List<Position> { Position.Engineer, Position.Technician };
        }
    }

    class PressMachine : Machine
    {
        public PressMachine(int serialNumber) : base(Equipment.PressMachine, serialNumber) { }

        public override List<Position> GetValidPositions()
        {
            return new List<Position> { Position.Technician };
        }
    }

    public class Worker : IWorker
    {
        private readonly string name;
        private readonly Position position;
        private bool isBusy;

        public Worker(string name, Position position)
        {
            this.name = name;
            this.position = position;
        }

        public string Name => name;
        public Position Position => position;

        public bool IsBusy() { return isBusy; }

        public void SetBusy(bool isBusy)
        {
            this.isBusy = isBusy;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            TestProduction();
        }

        static void TestProduction()
        {
            Workshop workshop = new Workshop();
            workshop.Log += Logger.Log;

            // Создаем станки и работников
            LatheMachine lathe1 = new LatheMachine(1);
            LatheMachine lathe2 = new LatheMachine(2);
            PressMachine press1 = new PressMachine(1);
            Worker engineer = new Worker("Иван", Position.Engineer);
            Worker technician = new Worker("Анна", Position.Technician);
            Worker manager = new Worker("Петр", Position.Manager);

            // Добавляем станки и работников в цех
            workshop.AddMachine(lathe1);
            workshop.AddMachine(lathe2);
            workshop.AddMachine(press1);
            workshop.AddWorker(engineer);
            workshop.AddWorker(technician);
            workshop.AddWorker(manager);

            // Запускаем производство
            workshop.StartProduction();
            Console.WriteLine();
            workshop.CheckProduction();
            Console.WriteLine();

            // Останавливаем производство
            workshop.StopProduction();
            Console.WriteLine();
            workshop.CheckProduction();
            Console.WriteLine();
        }
    }
}
