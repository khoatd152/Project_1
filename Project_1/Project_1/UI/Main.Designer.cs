namespace Project_1.UI
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnQuit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboDBMS = new System.Windows.Forms.ComboBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTypeScript = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listTable = new System.Windows.Forms.CheckedListBox();
            this.cboNameDB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(163, 289);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(448, 23);
            this.progressBar1.Step = 25;
            this.progressBar1.TabIndex = 30;
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnQuit.ForeColor = System.Drawing.Color.Red;
            this.btnQuit.Location = new System.Drawing.Point(619, 206);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(158, 65);
            this.btnQuit.TabIndex = 29;
            this.btnQuit.Text = "Exit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(744, 144);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(33, 31);
            this.button2.TabIndex = 28;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(446, 150);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(292, 20);
            this.txtPath.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(351, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "File Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(351, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Choose DBMS";
            // 
            // cboDBMS
            // 
            this.cboDBMS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDBMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboDBMS.ForeColor = System.Drawing.Color.Blue;
            this.cboDBMS.FormattingEnabled = true;
            this.cboDBMS.Location = new System.Drawing.Point(549, 96);
            this.cboDBMS.Name = "cboDBMS";
            this.cboDBMS.Size = new System.Drawing.Size(189, 28);
            this.cboDBMS.TabIndex = 24;
            this.cboDBMS.SelectedIndexChanged += new System.EventHandler(this.cboDBMS_SelectedIndexChanged);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnGenerate.ForeColor = System.Drawing.Color.Red;
            this.btnGenerate.Location = new System.Drawing.Point(343, 206);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(158, 65);
            this.btnGenerate.TabIndex = 23;
            this.btnGenerate.Text = "Convert";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(350, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Types of data to script:";
            // 
            // cboTypeScript
            // 
            this.cboTypeScript.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboTypeScript.ForeColor = System.Drawing.Color.Purple;
            this.cboTypeScript.FormattingEnabled = true;
            this.cboTypeScript.Location = new System.Drawing.Point(549, 55);
            this.cboTypeScript.Name = "cboTypeScript";
            this.cboTypeScript.Size = new System.Drawing.Size(189, 28);
            this.cboTypeScript.TabIndex = 21;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.checkBox1.Location = new System.Drawing.Point(367, 9);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(185, 29);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "Check all tables";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // listTable
            // 
            this.listTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.listTable.FormattingEnabled = true;
            this.listTable.Location = new System.Drawing.Point(13, 57);
            this.listTable.Name = "listTable";
            this.listTable.Size = new System.Drawing.Size(319, 214);
            this.listTable.TabIndex = 19;
            // 
            // cboNameDB
            // 
            this.cboNameDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNameDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboNameDB.ForeColor = System.Drawing.Color.Red;
            this.cboNameDB.FormattingEnabled = true;
            this.cboNameDB.Location = new System.Drawing.Point(13, 7);
            this.cboNameDB.Name = "cboNameDB";
            this.cboNameDB.Size = new System.Drawing.Size(305, 28);
            this.cboNameDB.TabIndex = 17;
            this.cboNameDB.SelectedIndexChanged += new System.EventHandler(this.cboNameDB_SelectedIndexChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 327);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboDBMS);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTypeScript);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.listTable);
            this.Controls.Add(this.cboNameDB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDBMS;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTypeScript;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckedListBox listTable;
        private System.Windows.Forms.ComboBox cboNameDB;
    }
}