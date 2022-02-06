namespace batch_processing
{
    partial class PictureControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbRotatre = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbWatermark = new System.Windows.Forms.CheckBox();
            this.cbRename = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbWmPath = new System.Windows.Forms.TextBox();
            this.cmbRotate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.cbNegate = new System.Windows.Forms.CheckBox();
            this.cbEdges = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(288, 360);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbRename);
            this.groupBox2.Controls.Add(this.tbName);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(176, 20);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 20);
            this.tbName.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbEdges);
            this.groupBox3.Controls.Add(this.cbNegate);
            this.groupBox3.Controls.Add(this.cmbRotate);
            this.groupBox3.Controls.Add(this.cbRotatre);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 215);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(282, 142);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // cbRotatre
            // 
            this.cbRotatre.AutoSize = true;
            this.cbRotatre.Location = new System.Drawing.Point(7, 19);
            this.cbRotatre.Name = "cbRotatre";
            this.cbRotatre.Size = new System.Drawing.Size(80, 17);
            this.cbRotatre.TabIndex = 0;
            this.cbRotatre.Text = "Повернуть";
            this.cbRotatre.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbPosition);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbWmPath);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cbWatermark);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // cbWatermark
            // 
            this.cbWatermark.AutoSize = true;
            this.cbWatermark.Location = new System.Drawing.Point(6, 19);
            this.cbWatermark.Name = "cbWatermark";
            this.cbWatermark.Size = new System.Drawing.Size(78, 17);
            this.cbWatermark.TabIndex = 0;
            this.cbWatermark.Text = "Watermark";
            this.cbWatermark.UseVisualStyleBackColor = true;
            // 
            // cbRename
            // 
            this.cbRename.AutoSize = true;
            this.cbRename.Location = new System.Drawing.Point(7, 20);
            this.cbRename.Name = "cbRename";
            this.cbRename.Size = new System.Drawing.Size(107, 17);
            this.cbRename.TabIndex = 2;
            this.cbRename.Text = "Переименовать";
            this.cbRename.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Выбрать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbWmPath
            // 
            this.tbWmPath.Location = new System.Drawing.Point(176, 44);
            this.tbWmPath.Name = "tbWmPath";
            this.tbWmPath.Size = new System.Drawing.Size(100, 20);
            this.tbWmPath.TabIndex = 2;
            // 
            // cmbRotate
            // 
            this.cmbRotate.FormattingEnabled = true;
            this.cmbRotate.Items.AddRange(new object[] {
            "90",
            "180",
            "-90"});
            this.cmbRotate.Location = new System.Drawing.Point(155, 17);
            this.cmbRotate.Name = "cmbRotate";
            this.cmbRotate.Size = new System.Drawing.Size(121, 21);
            this.cmbRotate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Позиция";
            // 
            // cmbPosition
            // 
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Items.AddRange(new object[] {
            "Слева снизу",
            "Слева сверху",
            "Справа снизу",
            "Справа сверху"});
            this.cmbPosition.Location = new System.Drawing.Point(155, 73);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(121, 21);
            this.cmbPosition.TabIndex = 4;
            // 
            // cbNegate
            // 
            this.cbNegate.AutoSize = true;
            this.cbNegate.Location = new System.Drawing.Point(6, 57);
            this.cbNegate.Name = "cbNegate";
            this.cbNegate.Size = new System.Drawing.Size(68, 17);
            this.cbNegate.TabIndex = 2;
            this.cbNegate.Text = "Негатив";
            this.cbNegate.UseVisualStyleBackColor = true;
            // 
            // cbEdges
            // 
            this.cbEdges.AutoSize = true;
            this.cbEdges.Location = new System.Drawing.Point(6, 93);
            this.cbEdges.Name = "cbEdges";
            this.cbEdges.Size = new System.Drawing.Size(69, 17);
            this.cbEdges.TabIndex = 3;
            this.cbEdges.Text = "Контуры";
            this.cbEdges.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // PictureControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PictureControl";
            this.Size = new System.Drawing.Size(288, 360);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbRotatre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbWatermark;
        private System.Windows.Forms.CheckBox cbRename;
        private System.Windows.Forms.TextBox tbWmPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbRotate;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbEdges;
        private System.Windows.Forms.CheckBox cbNegate;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
