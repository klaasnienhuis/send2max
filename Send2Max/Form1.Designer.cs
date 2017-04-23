namespace Send2Max
{
    partial class Form1
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
            this.rad_scriptfile = new System.Windows.Forms.RadioButton();
            this.rad_oneliner = new System.Windows.Forms.RadioButton();
            this.txt_filepath = new System.Windows.Forms.TextBox();
            this.txt_oneliner = new System.Windows.Forms.TextBox();
            this.btn_pickfile = new System.Windows.Forms.Button();
            this.btn_send = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.lbx_maxwindows = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // rad_scriptfile
            // 
            this.rad_scriptfile.AutoSize = true;
            this.rad_scriptfile.Location = new System.Drawing.Point(12, 12);
            this.rad_scriptfile.Name = "rad_scriptfile";
            this.rad_scriptfile.Size = new System.Drawing.Size(68, 17);
            this.rad_scriptfile.TabIndex = 0;
            this.rad_scriptfile.TabStop = true;
            this.rad_scriptfile.Text = "Script file";
            this.rad_scriptfile.UseVisualStyleBackColor = true;
            this.rad_scriptfile.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rad_oneliner
            // 
            this.rad_oneliner.AutoSize = true;
            this.rad_oneliner.Location = new System.Drawing.Point(12, 36);
            this.rad_oneliner.Name = "rad_oneliner";
            this.rad_oneliner.Size = new System.Drawing.Size(64, 17);
            this.rad_oneliner.TabIndex = 1;
            this.rad_oneliner.TabStop = true;
            this.rad_oneliner.Text = "Oneliner";
            this.rad_oneliner.UseVisualStyleBackColor = true;
            this.rad_oneliner.CheckedChanged += new System.EventHandler(this.rad_oneliner_CheckedChanged);
            // 
            // txt_filepath
            // 
            this.txt_filepath.Location = new System.Drawing.Point(87, 12);
            this.txt_filepath.Name = "txt_filepath";
            this.txt_filepath.Size = new System.Drawing.Size(269, 20);
            this.txt_filepath.TabIndex = 2;
            // 
            // txt_oneliner
            // 
            this.txt_oneliner.Location = new System.Drawing.Point(87, 36);
            this.txt_oneliner.Name = "txt_oneliner";
            this.txt_oneliner.Size = new System.Drawing.Size(309, 20);
            this.txt_oneliner.TabIndex = 3;
            this.txt_oneliner.Text = "for in in objects do print o.name";
            // 
            // btn_pickfile
            // 
            this.btn_pickfile.Location = new System.Drawing.Point(362, 12);
            this.btn_pickfile.Name = "btn_pickfile";
            this.btn_pickfile.Size = new System.Drawing.Size(34, 20);
            this.btn_pickfile.TabIndex = 4;
            this.btn_pickfile.Text = "...";
            this.btn_pickfile.UseVisualStyleBackColor = true;
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(254, 124);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(142, 31);
            this.btn_send.TabIndex = 5;
            this.btn_send.Text = "Send script to 3ds Max";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbx_maxwindows
            // 
            this.lbx_maxwindows.Enabled = false;
            this.lbx_maxwindows.FormattingEnabled = true;
            this.lbx_maxwindows.Location = new System.Drawing.Point(87, 62);
            this.lbx_maxwindows.Name = "lbx_maxwindows";
            this.lbx_maxwindows.Size = new System.Drawing.Size(309, 56);
            this.lbx_maxwindows.TabIndex = 7;
            this.lbx_maxwindows.SelectedIndexChanged += new System.EventHandler(this.lbx_maxwindows_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 166);
            this.Controls.Add(this.lbx_maxwindows);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.btn_pickfile);
            this.Controls.Add(this.txt_oneliner);
            this.Controls.Add(this.txt_filepath);
            this.Controls.Add(this.rad_oneliner);
            this.Controls.Add(this.rad_scriptfile);
            this.Name = "Form1";
            this.Text = "Send2Max for C# - Klaas Nienhuis";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rad_scriptfile;
        private System.Windows.Forms.RadioButton rad_oneliner;
        private System.Windows.Forms.TextBox txt_filepath;
        private System.Windows.Forms.TextBox txt_oneliner;
        private System.Windows.Forms.Button btn_pickfile;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lbx_maxwindows;
    }
}

