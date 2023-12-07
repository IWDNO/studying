namespace Industrial_Production_App
{
    public partial class MainForm : Form
    {
        private Workshop workshop;
        private Thread saveDataThread;

        public MainForm()
        {
            InitializeComponent();
            workshop = new Workshop();
            saveDataThread = new Thread(SaveData);
            saveDataThread.Start();
        }

        private void SaveData()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(10000);
                    using (StreamWriter writer = new("C:\\Users\\Павел\\Desktop\\data\\machines.txt"))
                    {
                        foreach (Machine machine in workshop.GetMachines())
                        {
                            writer.Write(machine.GetInfo());
                        }
                    }
                    using (StreamWriter writer = new("C:\\Users\\Павел\\Desktop\\data\\workers.txt"))
                    {
                        foreach (Worker worker in workshop.GetWorkers())
                        {
                            writer.Write(worker.GetInfo());
                        }
                    }
                }
            }
            catch { }
        }

        private void UpdateWorkers()
        {
            lstWorkers.Items.Clear();
            foreach (Worker worker in workshop.GetWorkers())
            {
                ListViewItem item = new ListViewItem(worker.Name);
                item.SubItems.Add(worker.Position.ToString());
                string state = worker.IsBusy() ? "Работает" : "Отдыхает";
                item.SubItems.Add(state);
                lstWorkers.Items.Add(item);
            }
        }

        private void UpdateMachines()
        {
            lstMachines.Items.Clear();
            foreach (Machine machine in workshop.GetMachines())
            {
                ListViewItem item = new ListViewItem(machine.Type.ToString());
                item.SubItems.Add(machine.SerialNumber.ToString());
                string state = machine.IsBusy() ? "Работает" : "Отдыхает";
                item.SubItems.Add(state);
                lstMachines.Items.Add(item);
            }
        }

        private void updateAll()
        {
            UpdateWorkers();
            UpdateMachines();
        }

        private void btnAddWorker_Click(object sender, EventArgs e)
        {
            AddWorkerFormcs form = new AddWorkerFormcs(workshop);
            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateWorkers();
            }
        }

        private void btnAddMachine_Click(object sender, EventArgs e)
        {
            AddMachineForm form = new AddMachineForm(workshop);
            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateMachines();
            }
        }

        private void btnStartProduction_Click(object sender, EventArgs e)
        {
            workshop.StartProduction();
            updateAll();
        }

        private void btnStopProduction_Click(object sender, EventArgs e)
        {
            workshop.StopProduction();
            updateAll();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveDataThread.Interrupt();
            saveDataThread.Join();
        }
    }
}