namespace FitnessClubApp
{
    partial class AbonementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbonementForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbAbonementType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtValidity = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnClearFilter = new Guna.UI2.WinForms.Guna2Button();
            this.btnFilter = new Guna.UI2.WinForms.Guna2Button();
            this.txtFilterValidity = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbFilterAbonementType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.chkFilterByValidity = new System.Windows.Forms.CheckBox();
            this.chkFilterByType = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
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
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(450, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Abonement Management";
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
            this.panel3.Controls.Add(this.cbAbonementType);
            this.panel3.Controls.Add(this.txtValidity);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 215);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1200, 154);
            this.panel3.TabIndex = 3;
            // 
            // cbAbonementType
            // 
            this.cbAbonementType.BackColor = System.Drawing.Color.Transparent;
            this.cbAbonementType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.cbAbonementType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAbonementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAbonementType.FocusedColor = System.Drawing.Color.Empty;
            this.cbAbonementType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbAbonementType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbAbonementType.FormattingEnabled = true;
            this.cbAbonementType.ItemHeight = 30;
            this.cbAbonementType.Location = new System.Drawing.Point(375, 77);
            this.cbAbonementType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAbonementType.Name = "cbAbonementType";
            this.cbAbonementType.Size = new System.Drawing.Size(298, 36);
            this.cbAbonementType.TabIndex = 3;
            // 
            // txtValidity
            // 
            this.txtValidity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.txtValidity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtValidity.DefaultText = "";
            this.txtValidity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtValidity.Location = new System.Drawing.Point(75, 77);
            this.txtValidity.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txtValidity.Name = "txtValidity";
            this.txtValidity.PlaceholderText = "";
            this.txtValidity.SelectedText = "";
            this.txtValidity.Size = new System.Drawing.Size(300, 55);
            this.txtValidity.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(375, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Abonement Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Validity:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnClearFilter);
            this.panel4.Controls.Add(this.btnFilter);
            this.panel4.Controls.Add(this.txtFilterValidity);
            this.panel4.Controls.Add(this.cbFilterAbonementType);
            this.panel4.Controls.Add(this.chkFilterByValidity);
            this.panel4.Controls.Add(this.chkFilterByType);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label6);
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
            this.btnClearFilter.Location = new System.Drawing.Point(608, 8);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(131, 54);
            this.btnClearFilter.TabIndex = 7;
            this.btnClearFilter.Text = "Сбросить";
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(458, 8);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(144, 54);
            this.btnFilter.TabIndex = 6;
            this.btnFilter.Text = "Применить";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txtFilterValidity
            // 
            this.txtFilterValidity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.txtFilterValidity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilterValidity.DefaultText = "";
            this.txtFilterValidity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFilterValidity.Location = new System.Drawing.Point(282, 46);
            this.txtFilterValidity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValidity.Name = "txtFilterValidity";
            this.txtFilterValidity.PlaceholderText = "";
            this.txtFilterValidity.SelectedText = "";
            this.txtFilterValidity.Size = new System.Drawing.Size(80, 34);
            this.txtFilterValidity.TabIndex = 4;
            // 
            // cbFilterAbonementType
            // 
            this.cbFilterAbonementType.BackColor = System.Drawing.Color.Transparent;
            this.cbFilterAbonementType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.cbFilterAbonementType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilterAbonementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterAbonementType.FocusedColor = System.Drawing.Color.Empty;
            this.cbFilterAbonementType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFilterAbonementType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbFilterAbonementType.FormattingEnabled = true;
            this.cbFilterAbonementType.ItemHeight = 30;
            this.cbFilterAbonementType.Location = new System.Drawing.Point(175, 7);
            this.cbFilterAbonementType.Name = "cbFilterAbonementType";
            this.cbFilterAbonementType.Size = new System.Drawing.Size(200, 36);
            this.cbFilterAbonementType.TabIndex = 1;
            // 
            // chkFilterByValidity
            // 
            this.chkFilterByValidity.AutoSize = true;
            this.chkFilterByValidity.Location = new System.Drawing.Point(163, 49);
            this.chkFilterByValidity.Name = "chkFilterByValidity";
            this.chkFilterByValidity.Size = new System.Drawing.Size(112, 24);
            this.chkFilterByValidity.TabIndex = 3;
            this.chkFilterByValidity.Text = "Включить";
            this.chkFilterByValidity.UseVisualStyleBackColor = true;
            // 
            // chkFilterByType
            // 
            this.chkFilterByType.AutoSize = true;
            this.chkFilterByType.Location = new System.Drawing.Point(15, 15);
            this.chkFilterByType.Name = "chkFilterByType";
            this.chkFilterByType.Size = new System.Drawing.Size(156, 24);
            this.chkFilterByType.TabIndex = 0;
            this.chkFilterByType.Text = "Фильтр по типу";
            this.chkFilterByType.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Фильтр по сроку:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(375, 53);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "дней";
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
            // AbonementForm
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
            this.Name = "AbonementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abonement Management";
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
        private Guna.UI2.WinForms.Guna2ComboBox cbAbonementType;
        private Guna.UI2.WinForms.Guna2TextBox txtValidity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private Guna.UI2.WinForms.Guna2Button btnFilter;
        private Guna.UI2.WinForms.Guna2Button btnClearFilter;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterValidity;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilterAbonementType;
        private System.Windows.Forms.CheckBox chkFilterByValidity;
        private System.Windows.Forms.CheckBox chkFilterByType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}