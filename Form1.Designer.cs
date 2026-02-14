namespace lab2_variant5
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtSnglNum = new TextBox();
            txtStart = new TextBox();
            txtEnd = new TextBox();
            label4 = new Label();
            lstResults = new ListBox();
            label5 = new Label();
            label6 = new Label();
            button1 = new Button();
            cmbFilter = new ComboBox();
            btnHelp = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            btnRunTests = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(139, 78);
            label1.Name = "label1";
            label1.Size = new Size(322, 32);
            label1.TabIndex = 0;
            label1.Text = "Введите число для анализа:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(297, 124);
            label2.Name = "label2";
            label2.Size = new Size(165, 32);
            label2.TabIndex = 1;
            label2.Text = "Диапазон ОТ:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(294, 169);
            label3.Name = "label3";
            label3.Size = new Size(169, 32);
            label3.TabIndex = 2;
            label3.Text = "Диапазон ДО:";
            // 
            // txtSnglNum
            // 
            txtSnglNum.BackColor = Color.WhiteSmoke;
            txtSnglNum.BorderStyle = BorderStyle.None;
            txtSnglNum.Font = new Font("Segoe UI", 14F);
            txtSnglNum.Location = new Point(467, 78);
            txtSnglNum.Name = "txtSnglNum";
            txtSnglNum.Size = new Size(125, 32);
            txtSnglNum.TabIndex = 3;
            // 
            // txtStart
            // 
            txtStart.BackColor = Color.WhiteSmoke;
            txtStart.BorderStyle = BorderStyle.None;
            txtStart.Font = new Font("Segoe UI", 14F);
            txtStart.Location = new Point(467, 124);
            txtStart.Name = "txtStart";
            txtStart.Size = new Size(125, 32);
            txtStart.TabIndex = 4;
            // 
            // txtEnd
            // 
            txtEnd.BackColor = Color.WhiteSmoke;
            txtEnd.BorderStyle = BorderStyle.None;
            txtEnd.Font = new Font("Segoe UI", 14F);
            txtEnd.Location = new Point(467, 169);
            txtEnd.Name = "txtEnd";
            txtEnd.Size = new Size(125, 32);
            txtEnd.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 20F);
            label4.Location = new Point(137, 18);
            label4.Name = "label4";
            label4.Size = new Size(434, 46);
            label4.TabIndex = 6;
            label4.Text = "Анализатор свойств чисел";
            // 
            // lstResults
            // 
            lstResults.BorderStyle = BorderStyle.None;
            lstResults.Font = new Font("Segoe UI", 14F);
            lstResults.FormattingEnabled = true;
            lstResults.ItemHeight = 31;
            lstResults.Location = new Point(635, 114);
            lstResults.Name = "lstResults";
            lstResults.Size = new Size(764, 248);
            lstResults.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(628, 43);
            label5.Name = "label5";
            label5.Size = new Size(245, 32);
            label5.TabIndex = 10;
            label5.Text = "Результаты расчетов";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 14F);
            label6.Location = new Point(132, 369);
            label6.Name = "label6";
            label6.Size = new Size(290, 32);
            label6.TabIndex = 11;
            label6.Text = "Визуализация диапазона";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 18F);
            button1.Location = new Point(377, 218);
            button1.Name = "button1";
            button1.Size = new Size(215, 71);
            button1.TabIndex = 12;
            button1.Text = "Старт";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnAnalyze_Click;
            // 
            // cmbFilter
            // 
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Location = new Point(635, 76);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(245, 28);
            cmbFilter.TabIndex = 13;
            cmbFilter.Click += cmbFilter_SelectedIndexChanged;
            // 
            // btnHelp
            // 
            btnHelp.Font = new Font("Segoe UI", 10F);
            btnHelp.Location = new Point(915, 76);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(115, 29);
            btnHelp.TabIndex = 14;
            btnHelp.Text = "Справка";
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Click += btnHelp_Click;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(139, 404);
            panel1.Name = "panel1";
            panel1.Size = new Size(1251, 450);
            panel1.TabIndex = 15;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 62);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnRunTests
            // 
            btnRunTests.Location = new Point(1050, 78);
            btnRunTests.Name = "btnRunTests";
            btnRunTests.Size = new Size(94, 26);
            btnRunTests.TabIndex = 16;
            btnRunTests.Text = "Тесты";
            btnRunTests.UseVisualStyleBackColor = true;
            btnRunTests.Click += btnRunTests_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1444, 866);
            Controls.Add(btnRunTests);
            Controls.Add(panel1);
            Controls.Add(btnHelp);
            Controls.Add(cmbFilter);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(lstResults);
            Controls.Add(label4);
            Controls.Add(txtEnd);
            Controls.Add(txtStart);
            Controls.Add(txtSnglNum);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Анализатор свойств чисел";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtSnglNum;
        private TextBox txtStart;
        private TextBox txtEnd;
        private Label label4;

        private ListBox lstResults;
        private Label label5;
        private Label label6;
        private Button button1;
        private ComboBox cmbFilter;
        private Button btnHelp;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Button btnRunTests;
    }
}
