namespace MandachordEncode
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
            this.btnRead = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.lblm1 = new System.Windows.Forms.Label();
            this.lblm2 = new System.Windows.Forms.Label();
            this.lblm3 = new System.Windows.Forms.Label();
            this.lblm4 = new System.Windows.Forms.Label();
            this.lblm5 = new System.Windows.Forms.Label();
            this.lblb5 = new System.Windows.Forms.Label();
            this.lblb4 = new System.Windows.Forms.Label();
            this.lblb3 = new System.Windows.Forms.Label();
            this.lblb2 = new System.Windows.Forms.Label();
            this.lblb1 = new System.Windows.Forms.Label();
            this.lblp3 = new System.Windows.Forms.Label();
            this.lblp2 = new System.Windows.Forms.Label();
            this.lblp1 = new System.Windows.Forms.Label();
            this.txtSong = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(12, 38);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(150, 23);
            this.btnRead.TabIndex = 0;
            this.btnRead.Text = "Read Melody to Text";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(168, 38);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(150, 23);
            this.btnWrite.TabIndex = 1;
            this.btnWrite.Text = "Write Text to Melody";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // lblm1
            // 
            this.lblm1.AutoSize = true;
            this.lblm1.Location = new System.Drawing.Point(12, 275);
            this.lblm1.Name = "lblm1";
            this.lblm1.Size = new System.Drawing.Size(46, 13);
            this.lblm1.TabIndex = 2;
            this.lblm1.Text = "melody1";
            // 
            // lblm2
            // 
            this.lblm2.AutoSize = true;
            this.lblm2.Location = new System.Drawing.Point(12, 288);
            this.lblm2.Name = "lblm2";
            this.lblm2.Size = new System.Drawing.Size(46, 13);
            this.lblm2.TabIndex = 3;
            this.lblm2.Text = "melody2";
            // 
            // lblm3
            // 
            this.lblm3.AutoSize = true;
            this.lblm3.Location = new System.Drawing.Point(12, 301);
            this.lblm3.Name = "lblm3";
            this.lblm3.Size = new System.Drawing.Size(46, 13);
            this.lblm3.TabIndex = 4;
            this.lblm3.Text = "melody3";
            // 
            // lblm4
            // 
            this.lblm4.AutoSize = true;
            this.lblm4.Location = new System.Drawing.Point(12, 314);
            this.lblm4.Name = "lblm4";
            this.lblm4.Size = new System.Drawing.Size(46, 13);
            this.lblm4.TabIndex = 5;
            this.lblm4.Text = "melody4";
            // 
            // lblm5
            // 
            this.lblm5.AutoSize = true;
            this.lblm5.Location = new System.Drawing.Point(12, 327);
            this.lblm5.Name = "lblm5";
            this.lblm5.Size = new System.Drawing.Size(46, 13);
            this.lblm5.TabIndex = 6;
            this.lblm5.Text = "melody5";
            // 
            // lblb5
            // 
            this.lblb5.AutoSize = true;
            this.lblb5.Location = new System.Drawing.Point(64, 327);
            this.lblb5.Name = "lblb5";
            this.lblb5.Size = new System.Drawing.Size(36, 13);
            this.lblb5.TabIndex = 11;
            this.lblb5.Text = "base5";
            // 
            // lblb4
            // 
            this.lblb4.AutoSize = true;
            this.lblb4.Location = new System.Drawing.Point(64, 314);
            this.lblb4.Name = "lblb4";
            this.lblb4.Size = new System.Drawing.Size(36, 13);
            this.lblb4.TabIndex = 10;
            this.lblb4.Text = "base4";
            // 
            // lblb3
            // 
            this.lblb3.AutoSize = true;
            this.lblb3.Location = new System.Drawing.Point(64, 301);
            this.lblb3.Name = "lblb3";
            this.lblb3.Size = new System.Drawing.Size(36, 13);
            this.lblb3.TabIndex = 9;
            this.lblb3.Text = "base3";
            // 
            // lblb2
            // 
            this.lblb2.AutoSize = true;
            this.lblb2.Location = new System.Drawing.Point(64, 288);
            this.lblb2.Name = "lblb2";
            this.lblb2.Size = new System.Drawing.Size(35, 13);
            this.lblb2.TabIndex = 8;
            this.lblb2.Text = "bass2";
            // 
            // lblb1
            // 
            this.lblb1.AutoSize = true;
            this.lblb1.Location = new System.Drawing.Point(64, 275);
            this.lblb1.Name = "lblb1";
            this.lblb1.Size = new System.Drawing.Size(35, 13);
            this.lblb1.TabIndex = 7;
            this.lblb1.Text = "bass1";
            // 
            // lblp3
            // 
            this.lblp3.AutoSize = true;
            this.lblp3.Location = new System.Drawing.Point(105, 301);
            this.lblp3.Name = "lblp3";
            this.lblp3.Size = new System.Drawing.Size(64, 13);
            this.lblp3.TabIndex = 14;
            this.lblp3.Text = "percussion3";
            // 
            // lblp2
            // 
            this.lblp2.AutoSize = true;
            this.lblp2.Location = new System.Drawing.Point(105, 288);
            this.lblp2.Name = "lblp2";
            this.lblp2.Size = new System.Drawing.Size(64, 13);
            this.lblp2.TabIndex = 13;
            this.lblp2.Text = "percussion2";
            // 
            // lblp1
            // 
            this.lblp1.AutoSize = true;
            this.lblp1.Location = new System.Drawing.Point(105, 275);
            this.lblp1.Name = "lblp1";
            this.lblp1.Size = new System.Drawing.Size(64, 13);
            this.lblp1.TabIndex = 12;
            this.lblp1.Text = "percussion1";
            // 
            // txtSong
            // 
            this.txtSong.Location = new System.Drawing.Point(12, 12);
            this.txtSong.Name = "txtSong";
            this.txtSong.Size = new System.Drawing.Size(810, 20);
            this.txtSong.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 73);
            this.Controls.Add(this.txtSong);
            this.Controls.Add(this.lblp3);
            this.Controls.Add(this.lblp2);
            this.Controls.Add(this.lblp1);
            this.Controls.Add(this.lblb5);
            this.Controls.Add(this.lblb4);
            this.Controls.Add(this.lblb3);
            this.Controls.Add(this.lblb2);
            this.Controls.Add(this.lblb1);
            this.Controls.Add(this.lblm5);
            this.Controls.Add(this.lblm4);
            this.Controls.Add(this.lblm3);
            this.Controls.Add(this.lblm2);
            this.Controls.Add(this.lblm1);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.btnRead);
            this.Name = "Form1";
            this.Text = "WARFRAME - Mandachord Encoder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Label lblm1;
        private System.Windows.Forms.Label lblm2;
        private System.Windows.Forms.Label lblm3;
        private System.Windows.Forms.Label lblm4;
        private System.Windows.Forms.Label lblm5;
        private System.Windows.Forms.Label lblb5;
        private System.Windows.Forms.Label lblb4;
        private System.Windows.Forms.Label lblb3;
        private System.Windows.Forms.Label lblb2;
        private System.Windows.Forms.Label lblb1;
        private System.Windows.Forms.Label lblp3;
        private System.Windows.Forms.Label lblp2;
        private System.Windows.Forms.Label lblp1;
        private System.Windows.Forms.TextBox txtSong;
    }
}

