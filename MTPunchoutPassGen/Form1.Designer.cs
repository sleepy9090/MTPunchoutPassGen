namespace MTPunchoutPassGen
{
    partial class FormMTPunchoutPassGen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMTPunchoutPassGen));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonMinorCircuit = new System.Windows.Forms.RadioButton();
            this.radioButtonMajorCircuit = new System.Windows.Forms.RadioButton();
            this.radioButtonWorldCircuit = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxWins = new System.Windows.Forms.ComboBox();
            this.comboBoxLosses = new System.Windows.Forms.ComboBox();
            this.comboBoxKOs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonGeneratePassword = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonWorldCircuit);
            this.groupBox1.Controls.Add(this.radioButtonMajorCircuit);
            this.groupBox1.Controls.Add(this.radioButtonMinorCircuit);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(98, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Title";
            // 
            // radioButtonMinorCircuit
            // 
            this.radioButtonMinorCircuit.AutoSize = true;
            this.radioButtonMinorCircuit.Location = new System.Drawing.Point(6, 19);
            this.radioButtonMinorCircuit.Name = "radioButtonMinorCircuit";
            this.radioButtonMinorCircuit.Size = new System.Drawing.Size(83, 17);
            this.radioButtonMinorCircuit.TabIndex = 0;
            this.radioButtonMinorCircuit.TabStop = true;
            this.radioButtonMinorCircuit.Text = "Minor Circuit";
            this.radioButtonMinorCircuit.UseVisualStyleBackColor = true;
            // 
            // radioButtonMajorCircuit
            // 
            this.radioButtonMajorCircuit.AutoSize = true;
            this.radioButtonMajorCircuit.Location = new System.Drawing.Point(6, 42);
            this.radioButtonMajorCircuit.Name = "radioButtonMajorCircuit";
            this.radioButtonMajorCircuit.Size = new System.Drawing.Size(83, 17);
            this.radioButtonMajorCircuit.TabIndex = 1;
            this.radioButtonMajorCircuit.TabStop = true;
            this.radioButtonMajorCircuit.Text = "Major Circuit";
            this.radioButtonMajorCircuit.UseVisualStyleBackColor = true;
            // 
            // radioButtonWorldCircuit
            // 
            this.radioButtonWorldCircuit.AutoSize = true;
            this.radioButtonWorldCircuit.Location = new System.Drawing.Point(6, 65);
            this.radioButtonWorldCircuit.Name = "radioButtonWorldCircuit";
            this.radioButtonWorldCircuit.Size = new System.Drawing.Size(85, 17);
            this.radioButtonWorldCircuit.TabIndex = 2;
            this.radioButtonWorldCircuit.TabStop = true;
            this.radioButtonWorldCircuit.Text = "World Circuit";
            this.radioButtonWorldCircuit.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBoxKOs);
            this.groupBox2.Controls.Add(this.comboBoxLosses);
            this.groupBox2.Controls.Add(this.comboBoxWins);
            this.groupBox2.Location = new System.Drawing.Point(116, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 98);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Record";
            // 
            // comboBoxWins
            // 
            this.comboBoxWins.FormattingEnabled = true;
            this.comboBoxWins.Location = new System.Drawing.Point(73, 15);
            this.comboBoxWins.Name = "comboBoxWins";
            this.comboBoxWins.Size = new System.Drawing.Size(121, 21);
            this.comboBoxWins.TabIndex = 0;
            // 
            // comboBoxLosses
            // 
            this.comboBoxLosses.FormattingEnabled = true;
            this.comboBoxLosses.Location = new System.Drawing.Point(73, 42);
            this.comboBoxLosses.Name = "comboBoxLosses";
            this.comboBoxLosses.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLosses.TabIndex = 1;
            // 
            // comboBoxKOs
            // 
            this.comboBoxKOs.FormattingEnabled = true;
            this.comboBoxKOs.Location = new System.Drawing.Point(73, 69);
            this.comboBoxKOs.Name = "comboBoxKOs";
            this.comboBoxKOs.Size = new System.Drawing.Size(121, 21);
            this.comboBoxKOs.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Wins:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Losses:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "K.O.s:";
            // 
            // buttonGeneratePassword
            // 
            this.buttonGeneratePassword.Location = new System.Drawing.Point(6, 19);
            this.buttonGeneratePassword.Name = "buttonGeneratePassword";
            this.buttonGeneratePassword.Size = new System.Drawing.Size(75, 23);
            this.buttonGeneratePassword.TabIndex = 2;
            this.buttonGeneratePassword.Text = "&Generate";
            this.buttonGeneratePassword.UseVisualStyleBackColor = true;
            this.buttonGeneratePassword.Click += new System.EventHandler(this.buttonGeneratePassword_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(177, 21);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(121, 20);
            this.textBoxPassword.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.buttonGeneratePassword);
            this.groupBox3.Controls.Add(this.textBoxPassword);
            this.groupBox3.Location = new System.Drawing.Point(12, 116);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 57);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "PASS KEY:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MTPunchoutPassGen.Properties.Resources.mt;
            this.pictureBox1.Location = new System.Drawing.Point(322, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 150);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // FormMTPunchoutPassGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 183);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMTPunchoutPassGen";
            this.Text = "Mike Tyson\'s Punch-Out Passgen (NES) - sleepy9090";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonWorldCircuit;
        private System.Windows.Forms.RadioButton radioButtonMajorCircuit;
        private System.Windows.Forms.RadioButton radioButtonMinorCircuit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxKOs;
        private System.Windows.Forms.ComboBox comboBoxLosses;
        private System.Windows.Forms.ComboBox comboBoxWins;
        private System.Windows.Forms.Button buttonGeneratePassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

