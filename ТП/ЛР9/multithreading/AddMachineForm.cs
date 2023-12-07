namespace Industrial_Production_App
{
    public partial class AddMachineForm : Form
    {
        private Workshop workshop;

        public AddMachineForm(Workshop workshop)
        {
            InitializeComponent();
            this.workshop = workshop;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // check if machine type is choosen
            if (!Enum.TryParse(comboBox1.SelectedItem?.ToString(), out Equipment machineType))
            {
                label1.Text = "*Выберите тип станка";
                return;
            }
            // check if serial number is `int`
            if (!int.TryParse(textBox1.Text, out int serialNumber))
            {
                label2.Text = "(Число) Серийный номер";
                return;
            }
            // check if serial number is unique
            if (workshop.GetMachines().Exists(machine => machine.SerialNumber == serialNumber && machine.Type == machineType))
            {
                MessageBox.Show($"{comboBox1.SelectedItem} с таким серийным номером уже существует");
                return;
            }

            switch (machineType)
            {
                case Equipment.LatheMachine:
                    workshop.AddMachine(new LatheMachine(serialNumber));
                    break;
                case Equipment.PressMachine:
                    workshop.AddMachine(new PressMachine(serialNumber));
                    break;
                default: 
                    break;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
