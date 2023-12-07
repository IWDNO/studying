namespace Industrial_Production_App
{
    public partial class AddWorkerFormcs : Form
    {
        private Workshop workshop;

        public AddWorkerFormcs(Workshop workshop)
        {
            InitializeComponent();
            this.workshop = workshop;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string workerName = textBox1.Text;
            // check if name is choosen
            if (workerName == "")
            {
                label1.Text = "*Имя";
                return;
            }
            // check if name contains only letters
            if (!workerName.All(char.IsLetter))
            {
                MessageBox.Show("Некорректное имя!");
                return;
            }
            // check if position is choosen
            if (!Enum.TryParse(comboBox1.SelectedItem?.ToString(), out Position workerPosition))
            {
                label2.Text = "*Должность";
                return;
            }

            workshop.AddWorker(new Worker(workerName, workerPosition));

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
