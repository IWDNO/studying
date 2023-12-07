namespace Industrial_Production_App
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAddWorker = new Button();
            btnAddMachine = new Button();
            btnStartProduction = new Button();
            btnStopProduction = new Button();
            BottomToolStripPanel = new ToolStripPanel();
            TopToolStripPanel = new ToolStripPanel();
            RightToolStripPanel = new ToolStripPanel();
            LeftToolStripPanel = new ToolStripPanel();
            ContentPanel = new ToolStripContentPanel();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            lstMachines = new ListView();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            lstWorkers = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // btnAddWorker
            // 
            btnAddWorker.Location = new Point(19, 26);
            btnAddWorker.Name = "btnAddWorker";
            btnAddWorker.Size = new Size(249, 29);
            btnAddWorker.TabIndex = 3;
            btnAddWorker.Text = "Добавить Работника";
            btnAddWorker.UseVisualStyleBackColor = true;
            btnAddWorker.Click += btnAddWorker_Click;
            // 
            // btnAddMachine
            // 
            btnAddMachine.Location = new Point(19, 74);
            btnAddMachine.Name = "btnAddMachine";
            btnAddMachine.Size = new Size(249, 29);
            btnAddMachine.TabIndex = 4;
            btnAddMachine.Text = "Добавить станок";
            btnAddMachine.UseVisualStyleBackColor = true;
            btnAddMachine.Click += btnAddMachine_Click;
            // 
            // btnStartProduction
            // 
            btnStartProduction.Location = new Point(6, 35);
            btnStartProduction.Name = "btnStartProduction";
            btnStartProduction.Size = new Size(262, 29);
            btnStartProduction.TabIndex = 5;
            btnStartProduction.Text = "Запустить производство";
            btnStartProduction.UseVisualStyleBackColor = true;
            btnStartProduction.Click += btnStartProduction_Click;
            // 
            // btnStopProduction
            // 
            btnStopProduction.Location = new Point(6, 83);
            btnStopProduction.Name = "btnStopProduction";
            btnStopProduction.Size = new Size(262, 29);
            btnStopProduction.TabIndex = 6;
            btnStopProduction.Text = "Остановить Производство";
            btnStopProduction.UseVisualStyleBackColor = true;
            btnStopProduction.Click += btnStopProduction_Click;
            // 
            // BottomToolStripPanel
            // 
            BottomToolStripPanel.Location = new Point(0, 0);
            BottomToolStripPanel.Name = "BottomToolStripPanel";
            BottomToolStripPanel.Orientation = Orientation.Horizontal;
            BottomToolStripPanel.RowMargin = new Padding(4, 0, 0, 0);
            BottomToolStripPanel.Size = new Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            TopToolStripPanel.Location = new Point(0, 0);
            TopToolStripPanel.Name = "TopToolStripPanel";
            TopToolStripPanel.Orientation = Orientation.Horizontal;
            TopToolStripPanel.RowMargin = new Padding(4, 0, 0, 0);
            TopToolStripPanel.Size = new Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            RightToolStripPanel.Location = new Point(0, 0);
            RightToolStripPanel.Name = "RightToolStripPanel";
            RightToolStripPanel.Orientation = Orientation.Horizontal;
            RightToolStripPanel.RowMargin = new Padding(4, 0, 0, 0);
            RightToolStripPanel.Size = new Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            LeftToolStripPanel.Location = new Point(0, 0);
            LeftToolStripPanel.Name = "LeftToolStripPanel";
            LeftToolStripPanel.Orientation = Orientation.Horizontal;
            LeftToolStripPanel.RowMargin = new Padding(4, 0, 0, 0);
            LeftToolStripPanel.Size = new Size(0, 0);
            // 
            // ContentPanel
            // 
            ContentPanel.Size = new Size(180, 185);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnStartProduction);
            groupBox1.Controls.Add(btnStopProduction);
            groupBox1.Location = new Point(336, 145);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(288, 126);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Управление";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Left;
            groupBox2.Controls.Add(btnAddWorker);
            groupBox2.Controls.Add(btnAddMachine);
            groupBox2.Location = new Point(336, 13);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(284, 126);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Добавление";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lstMachines);
            groupBox3.Controls.Add(lstWorkers);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(label1);
            groupBox3.Location = new Point(12, 13);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(300, 438);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Цех";
            // 
            // lstMachines
            // 
            lstMachines.Columns.AddRange(new ColumnHeader[] { columnHeader4, columnHeader5, columnHeader6 });
            lstMachines.Location = new Point(6, 261);
            lstMachines.Name = "lstMachines";
            lstMachines.Size = new Size(275, 163);
            lstMachines.TabIndex = 11;
            lstMachines.UseCompatibleStateImageBehavior = false;
            lstMachines.View = View.Details;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Имя";
            columnHeader4.Width = 50;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Серийный номер";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            columnHeader5.Width = 130;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Занятость";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            columnHeader6.Width = 90;
            // 
            // lstWorkers
            // 
            lstWorkers.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            lstWorkers.Location = new Point(6, 56);
            lstWorkers.Name = "lstWorkers";
            lstWorkers.Size = new Size(275, 163);
            lstWorkers.TabIndex = 10;
            lstWorkers.UseCompatibleStateImageBehavior = false;
            lstWorkers.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Имя";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Должность";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Занятость";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = 90;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 29);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 4;
            label2.Text = "Работники";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 229);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 3;
            label1.Text = "Станки";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(632, 477);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            MaximumSize = new Size(650, 524);
            MinimumSize = new Size(650, 524);
            Name = "MainForm";
            Text = "Промышленное производство";
            FormClosing += MainForm_FormClosing;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnAddWorker;
        private Button btnAddMachine;
        private Button btnStartProduction;
        private Button btnStopProduction;
        private ToolStripPanel BottomToolStripPanel;
        private ToolStripPanel TopToolStripPanel;
        private ToolStripPanel RightToolStripPanel;
        private ToolStripPanel LeftToolStripPanel;
        private ToolStripContentPanel ContentPanel;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label2;
        private Label label1;
        private ListView lstWorkers;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ListView lstMachines;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
    }
}