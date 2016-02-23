namespace SplendorFormsClient.Panels
{
    using SplendorCore.Models;

    partial class PlayerPanel
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.CardsBlack = new System.Windows.Forms.Button();
            this.CardsRed = new System.Windows.Forms.Button();
            this.CardsGreen = new System.Windows.Forms.Button();
            this.CardsBlue = new System.Windows.Forms.Button();
            this.CardsWhite = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ChipsBlack = new System.Windows.Forms.Button();
            this.ChipsRed = new System.Windows.Forms.Button();
            this.ChipsGreen = new System.Windows.Forms.Button();
            this.ChipsBlue = new System.Windows.Forms.Button();
            this.ChipsWhite = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 250);
            this.panel1.TabIndex = 0;
            // 
            // CardsBlack
            // 
            this.CardsBlack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CardsBlack.BackColor = System.Drawing.Color.Black;
            this.CardsBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CardsBlack.ForeColor = System.Drawing.Color.White;
            this.CardsBlack.Location = new System.Drawing.Point(218, 12);
            this.CardsBlack.Name = "CardsBlack";
            this.CardsBlack.Size = new System.Drawing.Size(44, 23);
            this.CardsBlack.TabIndex = 7;
            this.CardsBlack.Text = "0";
            this.CardsBlack.UseVisualStyleBackColor = false;
            // 
            // CardsRed
            // 
            this.CardsRed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CardsRed.BackColor = System.Drawing.Color.Red;
            this.CardsRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CardsRed.ForeColor = System.Drawing.Color.White;
            this.CardsRed.Location = new System.Drawing.Point(165, 12);
            this.CardsRed.Name = "CardsRed";
            this.CardsRed.Size = new System.Drawing.Size(44, 23);
            this.CardsRed.TabIndex = 6;
            this.CardsRed.Text = "0";
            this.CardsRed.UseVisualStyleBackColor = false;
            // 
            // CardsGreen
            // 
            this.CardsGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CardsGreen.BackColor = System.Drawing.Color.Green;
            this.CardsGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CardsGreen.ForeColor = System.Drawing.Color.White;
            this.CardsGreen.Location = new System.Drawing.Point(112, 12);
            this.CardsGreen.Name = "CardsGreen";
            this.CardsGreen.Size = new System.Drawing.Size(44, 23);
            this.CardsGreen.TabIndex = 5;
            this.CardsGreen.Text = "0";
            this.CardsGreen.UseVisualStyleBackColor = false;
            // 
            // CardsBlue
            // 
            this.CardsBlue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CardsBlue.BackColor = System.Drawing.Color.Blue;
            this.CardsBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CardsBlue.ForeColor = System.Drawing.Color.White;
            this.CardsBlue.Location = new System.Drawing.Point(59, 12);
            this.CardsBlue.Name = "CardsBlue";
            this.CardsBlue.Size = new System.Drawing.Size(44, 23);
            this.CardsBlue.TabIndex = 4;
            this.CardsBlue.Text = "0";
            this.CardsBlue.UseVisualStyleBackColor = false;
            this.CardsBlue.Click += new System.EventHandler(this.CardsBlue_Click);
            // 
            // CardsWhite
            // 
            this.CardsWhite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CardsWhite.BackColor = System.Drawing.Color.White;
            this.CardsWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CardsWhite.Location = new System.Drawing.Point(6, 12);
            this.CardsWhite.Name = "CardsWhite";
            this.CardsWhite.Size = new System.Drawing.Size(44, 23);
            this.CardsWhite.TabIndex = 3;
            this.CardsWhite.Text = "0";
            this.CardsWhite.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CardsWhite);
            this.groupBox1.Controls.Add(this.CardsBlue);
            this.groupBox1.Controls.Add(this.CardsGreen);
            this.groupBox1.Controls.Add(this.CardsRed);
            this.groupBox1.Controls.Add(this.CardsBlack);
            this.groupBox1.Location = new System.Drawing.Point(6, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 41);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cards";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(12, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(0, 0);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chips";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ChipsBlack);
            this.groupBox3.Controls.Add(this.ChipsRed);
            this.groupBox3.Controls.Add(this.ChipsGreen);
            this.groupBox3.Controls.Add(this.ChipsBlue);
            this.groupBox3.Controls.Add(this.ChipsWhite);
            this.groupBox3.Location = new System.Drawing.Point(6, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 41);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chips";
            // 
            // ChipsBlack
            // 
            this.ChipsBlack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChipsBlack.BackColor = System.Drawing.Color.Black;
            this.ChipsBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ChipsBlack.ForeColor = System.Drawing.Color.White;
            this.ChipsBlack.Location = new System.Drawing.Point(218, 12);
            this.ChipsBlack.Name = "ChipsBlack";
            this.ChipsBlack.Size = new System.Drawing.Size(44, 23);
            this.ChipsBlack.TabIndex = 27;
            this.ChipsBlack.Text = "0";
            this.ChipsBlack.UseVisualStyleBackColor = false;
            // 
            // ChipsRed
            // 
            this.ChipsRed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChipsRed.BackColor = System.Drawing.Color.Red;
            this.ChipsRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ChipsRed.ForeColor = System.Drawing.Color.White;
            this.ChipsRed.Location = new System.Drawing.Point(165, 12);
            this.ChipsRed.Name = "ChipsRed";
            this.ChipsRed.Size = new System.Drawing.Size(44, 23);
            this.ChipsRed.TabIndex = 26;
            this.ChipsRed.Text = "0";
            this.ChipsRed.UseVisualStyleBackColor = false;
            // 
            // ChipsGreen
            // 
            this.ChipsGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChipsGreen.BackColor = System.Drawing.Color.Green;
            this.ChipsGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ChipsGreen.ForeColor = System.Drawing.Color.White;
            this.ChipsGreen.Location = new System.Drawing.Point(112, 12);
            this.ChipsGreen.Name = "ChipsGreen";
            this.ChipsGreen.Size = new System.Drawing.Size(44, 23);
            this.ChipsGreen.TabIndex = 25;
            this.ChipsGreen.Text = "0";
            this.ChipsGreen.UseVisualStyleBackColor = false;
            // 
            // ChipsBlue
            // 
            this.ChipsBlue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChipsBlue.BackColor = System.Drawing.Color.Blue;
            this.ChipsBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ChipsBlue.ForeColor = System.Drawing.Color.White;
            this.ChipsBlue.Location = new System.Drawing.Point(59, 12);
            this.ChipsBlue.Name = "ChipsBlue";
            this.ChipsBlue.Size = new System.Drawing.Size(44, 23);
            this.ChipsBlue.TabIndex = 24;
            this.ChipsBlue.Text = "0";
            this.ChipsBlue.UseVisualStyleBackColor = false;
            // 
            // ChipsWhite
            // 
            this.ChipsWhite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChipsWhite.BackColor = System.Drawing.Color.White;
            this.ChipsWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ChipsWhite.Location = new System.Drawing.Point(6, 12);
            this.ChipsWhite.Name = "ChipsWhite";
            this.ChipsWhite.Size = new System.Drawing.Size(44, 23);
            this.ChipsWhite.TabIndex = 23;
            this.ChipsWhite.Text = "0";
            this.ChipsWhite.UseVisualStyleBackColor = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Location = new System.Drawing.Point(7, 120);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(272, 125);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Reserved Cards";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(5, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 100);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(94, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 100);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(183, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 100);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // PlayerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "PlayerPanel";
            this.Size = new System.Drawing.Size(287, 256);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CardsBlack;
        private System.Windows.Forms.Button CardsRed;
        private System.Windows.Forms.Button CardsGreen;
        private System.Windows.Forms.Button CardsBlue;
        private System.Windows.Forms.Button CardsWhite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ChipsBlack;
        private System.Windows.Forms.Button ChipsRed;
        private System.Windows.Forms.Button ChipsGreen;
        private System.Windows.Forms.Button ChipsBlue;
        private System.Windows.Forms.Button ChipsWhite;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
