namespace IndustriaProduction
{
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

    abstract class Machine
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

    class Worker
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

    class Workshop
    {
        private List<Machine> machines;
        private List<Worker> workers;

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
        }

        /// <summary>
        /// Показать состояние (занятость) производства
        /// </summary>
        public void CheckProduction()
        {
            Console.WriteLine("Состояние производства:\n-----------------------");
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

        /// <summary>
        /// Освободить все станки и работников
        /// </summary>
        public void StopProduction()
        {
            foreach(Machine machine in machines)
            {
                machine.SetBusy(false);
            }
            foreach(Worker worker in workers)
            {
                worker.SetBusy(false);
            }
        }
    }

    class Program
    {
        /// <summary>
        /// Сonsole interface created by chatGPT
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            TestProduction();

            Workshop workshop = new Workshop();

            while (true)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("[1] Добавить станок\n[2] Добавить работника\n[3] Проверка производства\n[4] Запуск производства\n[5] Остановить производство\n[6] Выйти");
                Console.WriteLine("-------------------------");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Введите тип станка (1 - Токарный станок, 2 - Пресс): ");
                        int machineType = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите серийный номер станка: ");
                        int serialNumber = int.Parse(Console.ReadLine());
                        if (machineType == 1)
                        {
                            workshop.AddMachine(new LatheMachine(serialNumber));
                            Console.WriteLine("Токарный станок добавлен.");
                        }
                        else if (machineType == 2)
                        {
                            workshop.AddMachine(new PressMachine(serialNumber));
                            Console.WriteLine("Пресс добавлен.");
                        }
                        else
                        {
                            Console.WriteLine("Неверный тип станка.");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Введите имя работника: ");
                        string workerName = Console.ReadLine();
                        Console.WriteLine("Введите должность работника (Engineer, Technician, Manager): ");
                        string workerPositionInput = Console.ReadLine();
                        Position workerPosition;
                        if (Enum.TryParse(workerPositionInput, out workerPosition))
                        {
                            workshop.AddWorker(new Worker(workerName, workerPosition));
                            Console.WriteLine("Работник добавлен.");
                        }
                        else
                        {
                            Console.WriteLine("Неверная должность работника.");
                        }
                        break;
                    case "3":
                        workshop.CheckProduction();
                        break;
                    case "4":
                        workshop.StartProduction();
                        Console.WriteLine("Производство запущено.");
                        break;
                    case "5":
                        workshop.StopProduction();
                        Console.WriteLine("Производство остановлено.");
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неверный ввод. Попробуйте снова.");
                        break;
                }
                Console.WriteLine();
            }
        }

        static void TestProduction()
        {
            Workshop workshop = new Workshop();

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
            workshop.CheckProduction();

            // Останавливаем производство
            workshop.StopProduction();
            workshop.CheckProduction();
        }
    }
}

