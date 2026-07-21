namespace FitnessClubApp
{
    partial class TrainingForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainingForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtpTrainingDate = new System.Windows.Forms.DateTimePicker();
            this.cbTrainingType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbTrainer = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbCustomer = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnClearFilter = new Guna.UI2.WinForms.Guna2Button();
            this.btnFilter = new Guna.UI2.WinForms.Guna2Button();
            this.dtpFilterTrainingDate = new System.Windows.Forms.DateTimePicker();
            this.cbFilterTrainer = new Guna.UI2.WinForms.Guna2ComboBox();
            this.chkFilterByDate = new System.Windows.Forms.CheckBox();
            this.chkFilterByTrainer = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 123);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(450, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Training Management";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 123);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1200, 92);
            this.panel2.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(375, 15);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 54);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(195, 15);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(150, 54);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(15, 15);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 54);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtpTrainingDate);
            this.panel3.Controls.Add(this.cbTrainingType);
            this.panel3.Controls.Add(this.cbTrainer);
            this.panel3.Controls.Add(this.cbCustomer);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 215);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1200, 154);
            this.panel3.TabIndex = 3;
            // 
            // dtpTrainingDate
            // 
            this.dtpTrainingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTrainingDate.Location = new System.Drawing.Point(825, 77);
            this.dtpTrainingDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpTrainingDate.Name = "dtpTrainingDate";
            this.dtpTrainingDate.Size = new System.Drawing.Size(150, 26);
            this.dtpTrainingDate.TabIndex = 7;
            // 
            // cbTrainingType
            // 
            this.cbTrainingType.BackColor = System.Drawing.Color.Transparent;
            this.cbTrainingType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.cbTrainingType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTrainingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrainingType.FocusedColor = System.Drawing.Color.Empty;
            this.cbTrainingType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbTrainingType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbTrainingType.FormattingEnabled = true;
            this.cbTrainingType.ItemHeight = 30;
            this.cbTrainingType.Location = new System.Drawing.Point(525, 77);
            this.cbTrainingType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTrainingType.Name = "cbTrainingType";
            this.cbTrainingType.Size = new System.Drawing.Size(250, 36);
            this.cbTrainingType.TabIndex = 6;
            // 
            // cbTrainer
            // 
            this.cbTrainer.BackColor = System.Drawing.Color.Transparent;
            this.cbTrainer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.cbTrainer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTrainer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrainer.FocusedColor = System.Drawing.Color.Empty;
            this.cbTrainer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbTrainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbTrainer.FormattingEnabled = true;
            this.cbTrainer.ItemHeight = 30;
            this.cbTrainer.Location = new System.Drawing.Point(275, 77);
            this.cbTrainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTrainer.Name = "cbTrainer";
            this.cbTrainer.Size = new System.Drawing.Size(200, 36);
            this.cbTrainer.TabIndex = 5;
            // 
            // cbCustomer
            // 
            this.cbCustomer.BackColor = System.Drawing.Color.Transparent;
            this.cbCustomer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.cbCustomer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomer.FocusedColor = System.Drawing.Color.Empty;
            this.cbCustomer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.ItemHeight = 30;
            this.cbCustomer.Location = new System.Drawing.Point(25, 77);
            this.cbCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(200, 36);
            this.cbCustomer.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(825, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(525, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Training Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Trainer:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Customer:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnClearFilter);
            this.panel4.Controls.Add(this.btnFilter);
            this.panel4.Controls.Add(this.dtpFilterTrainingDate);
            this.panel4.Controls.Add(this.cbFilterTrainer);
            this.panel4.Controls.Add(this.chkFilterByDate);
            this.panel4.Controls.Add(this.chkFilterByTrainer);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 369);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1200, 100);
            this.panel4.TabIndex = 4;
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.btnClearFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClearFilter.ForeColor = System.Drawing.Color.White;
            this.btnClearFilter.Location = new System.Drawing.Point(675, 13);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(148, 54);
            this.btnClearFilter.TabIndex = 7;
            this.btnClearFilter.Text = "Сбросить";
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(532, 12);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(137, 54);
            this.btnFilter.TabIndex = 6;
            this.btnFilter.Text = "Применить";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dtpFilterTrainingDate
            // 
            this.dtpFilterTrainingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterTrainingDate.Location = new System.Drawing.Point(181, 13);
            this.dtpFilterTrainingDate.Name = "dtpFilterTrainingDate";
            this.dtpFilterTrainingDate.Size = new System.Drawing.Size(150, 26);
            this.dtpFilterTrainingDate.TabIndex = 1;
            // 
            // cbFilterTrainer
            // 
            this.cbFilterTrainer.BackColor = System.Drawing.Color.Transparent;
            this.cbFilterTrainer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.cbFilterTrainer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilterTrainer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterTrainer.FocusedColor = System.Drawing.Color.Empty;
            this.cbFilterTrainer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFilterTrainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbFilterTrainer.FormattingEnabled = true;
            this.cbFilterTrainer.ItemHeight = 30;
            this.cbFilterTrainer.Location = new System.Drawing.Point(299, 42);
            this.cbFilterTrainer.Name = "cbFilterTrainer";
            this.cbFilterTrainer.Size = new System.Drawing.Size(200, 36);
            this.cbFilterTrainer.TabIndex = 4;
            // 
            // chkFilterByDate
            // 
            this.chkFilterByDate.AutoSize = true;
            this.chkFilterByDate.Location = new System.Drawing.Point(15, 15);
            this.chkFilterByDate.Name = "chkFilterByDate";
            this.chkFilterByDate.Size = new System.Drawing.Size(160, 24);
            this.chkFilterByDate.TabIndex = 0;
            this.chkFilterByDate.Text = "Фильтр по дате";
            this.chkFilterByDate.UseVisualStyleBackColor = true;
            // 
            // chkFilterByTrainer
            // 
            this.chkFilterByTrainer.AutoSize = true;
            this.chkFilterByTrainer.Location = new System.Drawing.Point(181, 46);
            this.chkFilterByTrainer.Name = "chkFilterByTrainer";
            this.chkFilterByTrainer.Size = new System.Drawing.Size(112, 24);
            this.chkFilterByTrainer.TabIndex = 3;
            this.chkFilterByTrainer.Text = "Включить";
            this.chkFilterByTrainer.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Фильтр по тренеру:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(465, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 20);
            this.label7.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeight = 34;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 469);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1200, 454);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // TrainingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 923);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TrainingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Training Management";
            this.Load += new System.EventHandler(this.TrainingForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtpTrainingDate;
        private Guna.UI2.WinForms.Guna2ComboBox cbTrainingType;
        private Guna.UI2.WinForms.Guna2ComboBox cbTrainer;
        private Guna.UI2.WinForms.Guna2ComboBox cbCustomer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private Guna.UI2.WinForms.Guna2Button btnFilter;
        private Guna.UI2.WinForms.Guna2Button btnClearFilter;
        private System.Windows.Forms.DateTimePicker dtpFilterTrainingDate;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilterTrainer;
        private System.Windows.Forms.CheckBox chkFilterByDate;
        private System.Windows.Forms.CheckBox chkFilterByTrainer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}