using System.Reflection.Metadata.Ecma335;

namespace Industrial_Production_App
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

    public abstract class Machine
    {
        private readonly Equipment type;
        private readonly int serialNumber;
        private bool isBusy;

        public Machine(Equipment type, int serialNumber)
        {
            this.type = type;
            this.serialNumber = serialNumber;
        }

        public string GetInfo()
        {
            return $"{type} - {serialNumber}\n";
        }

        public Equipment Type => type;
        public int SerialNumber => serialNumber;

        public bool IsBusy() { return isBusy; }
        public void SetBusy(bool isBusy)
        {
            this.isBusy = isBusy;
        }

        /// <summary>
        /// ������ ������ ��� ������ ��������� � ���������� ����������
        /// </summary>
        public void Start(Worker worker)
        {
            if (GetValidPositions().Contains(worker.Position))
            {
                Console.WriteLine($"{type} #{serialNumber} �������: {worker.Name} ({worker.Position})");
            }
            else
            {
                Console.WriteLine($"{type} �� ����� ���� ������� ����������� � ���������� {worker.Position}");
            }
        }

        /// <summary>
        /// �������� ������ ��������� ���������� ��� ������ �� ������ 
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

    public class Worker
    {
        private readonly string name;
        private readonly Position position;
        private bool isBusy;

        public Worker(string name, Position position)
        {
            this.name = name;
            this.position = position;
        }

        public string GetInfo()
        {
            return $"{name} - {position}\n";
        }

        public string Name => name;
        public Position Position => position;

        public bool IsBusy() { return isBusy; }

        public void SetBusy(bool isBusy)
        {
            this.isBusy = isBusy;
        }
    }

    public class Workshop
    {
        private List<Machine> machines;
        private List<Worker> workers;

        public List<Machine> GetMachines()
        {
            return machines;
        }
        public List<Worker> GetWorkers()
        {
            return workers;
        }

        public Workshop()
        {
            machines = new List<Machine>();
            workers = new List<Worker>();
        }

        /// <summary>
        /// �������� ������ � ���
        /// </summary>
        public void AddMachine(Machine machine)
        {
            machines.Add(machine);
            machine.SetBusy(false);
        }

        /// <summary>
        /// �������� ��������� � ���
        /// </summary>
        public void AddWorker(Worker worker)
        {
            workers.Add(worker);
            worker.SetBusy(false);
        }

        /// <summary>
        /// ������ ������������. ������ ��������� ������ ����������� ���� ������ ��������� �������� � ���������� ����������
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
        /// ���������� ��� ������ � ����������
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
        }
    }


    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}