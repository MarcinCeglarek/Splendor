namespace SplendorFormsClient.Panels
{
    partial class CardPanel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Points = new System.Windows.Forms.Label();
            this.Color = new System.Windows.Forms.Label();
            this.L1 = new System.Windows.Forms.Label();
            this.L2 = new System.Windows.Forms.Label();
            this.L3 = new System.Windows.Forms.Label();
            this.L4 = new System.Windows.Forms.Label();
            this.L5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Points);
            this.panel1.Controls.Add(this.Color);
            this.panel1.Controls.Add(this.L1);
            this.panel1.Controls.Add(this.L2);
            this.panel1.Controls.Add(this.L3);
            this.panel1.Controls.Add(this.L4);
            this.panel1.Controls.Add(this.L5);
            this.panel1.Location = new System.Drawing.Point(4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 186);
            this.panel1.TabIndex = 7;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // Points
            // 
            this.Points.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Points.Location = new System.Drawing.Point(110, 21);
            this.Points.Name = "Points";
            this.Points.Size = new System.Drawing.Size(24, 31);
            this.Points.TabIndex = 13;
            this.Points.Text = "0";
            this.Points.Click += new System.EventHandler(this.Points_Click);
            // 
            // Color
            // 
            this.Color.Location = new System.Drawing.Point(-1, -1);
            this.Color.Name = "Color";
            this.Color.Size = new System.Drawing.Size(150, 75);
            this.Color.TabIndex = 12;
            this.Color.Click += new System.EventHandler(this.Color_Click);
            // 
            // L1
            // 
            this.L1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.L1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.L1.Location = new System.Drawing.Point(3, 162);
            this.L1.Name = "L1";
            this.L1.Size = new System.Drawing.Size(21, 19);
            this.L1.TabIndex = 11;
            this.L1.Text = "0";
            this.L1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.L1.Visible = false;
            this.L1.Click += new System.EventHandler(this.Black_Click);
            // 
            // L2
            // 
            this.L2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.L2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.L2.Location = new System.Drawing.Point(3, 142);
            this.L2.Name = "L2";
            this.L2.Size = new System.Drawing.Size(21, 19);
            this.L2.TabIndex = 10;
            this.L2.Text = "0";
            this.L2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.L2.Visible = false;
            this.L2.Click += new System.EventHandler(this.Red_Click);
            // 
            // L3
            // 
            this.L3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.L3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.L3.Location = new System.Drawing.Point(3, 122);
            this.L3.Name = "L3";
            this.L3.Size = new System.Drawing.Size(21, 19);
            this.L3.TabIndex = 9;
            this.L3.Text = "0";
            this.L3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.L3.Visible = false;
            this.L3.Click += new System.EventHandler(this.Green_Click);
            // 
            // L4
            // 
            this.L4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.L4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.L4.Location = new System.Drawing.Point(3, 102);
            this.L4.Name = "L4";
            this.L4.Size = new System.Drawing.Size(21, 19);
            this.L4.TabIndex = 8;
            this.L4.Text = "0";
            this.L4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.L4.Visible = false;
            this.L4.Click += new System.EventHandler(this.Blue_Click);
            // 
            // L5
            // 
            this.L5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.L5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.L5.Location = new System.Drawing.Point(3, 82);
            this.L5.Name = "L5";
            this.L5.Size = new System.Drawing.Size(21, 19);
            this.L5.TabIndex = 7;
            this.L5.Text = "0";
            this.L5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.L5.Visible = false;
            this.L5.Click += new System.EventHandler(this.White_Click);
            // 
            // CardPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "CardPanel";
            this.Size = new System.Drawing.Size(158, 196);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Points;
        private System.Windows.Forms.Label Color;
        private System.Windows.Forms.Label L1;
        private System.Windows.Forms.Label L2;
        private System.Windows.Forms.Label L3;
        private System.Windows.Forms.Label L4;
        private System.Windows.Forms.Label L5;
    }
}
