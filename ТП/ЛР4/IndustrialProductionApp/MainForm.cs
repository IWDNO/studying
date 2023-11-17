namespace Industrial_Production_App
{
    public partial class MainForm : Form
    {
        private Workshop workshop;
        public MainForm()
        {
            InitializeComponent();
            workshop = new Workshop();
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
    }
}