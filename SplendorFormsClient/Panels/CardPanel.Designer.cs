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
            this.Black = new System.Windows.Forms.Label();
            this.Red = new System.Windows.Forms.Label();
            this.Green = new System.Windows.Forms.Label();
            this.Blue = new System.Windows.Forms.Label();
            this.White = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Points);
            this.panel1.Controls.Add(this.Color);
            this.panel1.Controls.Add(this.Black);
            this.panel1.Controls.Add(this.Red);
            this.panel1.Controls.Add(this.Green);
            this.panel1.Controls.Add(this.Blue);
            this.panel1.Controls.Add(this.White);
            this.panel1.Location = new System.Drawing.Point(4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 216);
            this.panel1.TabIndex = 7;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // Points
            // 
            this.Points.BackColor = System.Drawing.Color.White;
            this.Points.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Points.Location = new System.Drawing.Point(151, 23);
            this.Points.Name = "Points";
            this.Points.Size = new System.Drawing.Size(24, 31);
            this.Points.TabIndex = 13;
            this.Points.Text = "0";
            this.Points.Click += new System.EventHandler(this.Points_Click);
            // 
            // Color
            // 
            this.Color.BackColor = System.Drawing.Color.White;
            this.Color.Location = new System.Drawing.Point(-1, -1);
            this.Color.Name = "Color";
            this.Color.Size = new System.Drawing.Size(188, 75);
            this.Color.TabIndex = 12;
            this.Color.Click += new System.EventHandler(this.Color_Click);
            // 
            // Black
            // 
            this.Black.BackColor = System.Drawing.Color.Black;
            this.Black.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Black.ForeColor = System.Drawing.Color.White;
            this.Black.Location = new System.Drawing.Point(3, 193);
            this.Black.Name = "Black";
            this.Black.Size = new System.Drawing.Size(21, 19);
            this.Black.TabIndex = 11;
            this.Black.Text = "0";
            this.Black.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Black.Click += new System.EventHandler(this.Black_Click);
            // 
            // Red
            // 
            this.Red.BackColor = System.Drawing.Color.Red;
            this.Red.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Red.ForeColor = System.Drawing.Color.White;
            this.Red.Location = new System.Drawing.Point(3, 174);
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(21, 19);
            this.Red.TabIndex = 10;
            this.Red.Text = "0";
            this.Red.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Red.Click += new System.EventHandler(this.Red_Click);
            // 
            // Green
            // 
            this.Green.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Green.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Green.ForeColor = System.Drawing.Color.White;
            this.Green.Location = new System.Drawing.Point(3, 155);
            this.Green.Name = "Green";
            this.Green.Size = new System.Drawing.Size(21, 19);
            this.Green.TabIndex = 9;
            this.Green.Text = "0";
            this.Green.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Green.Click += new System.EventHandler(this.Green_Click);
            // 
            // Blue
            // 
            this.Blue.BackColor = System.Drawing.Color.Blue;
            this.Blue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Blue.ForeColor = System.Drawing.Color.White;
            this.Blue.Location = new System.Drawing.Point(3, 136);
            this.Blue.Name = "Blue";
            this.Blue.Size = new System.Drawing.Size(21, 19);
            this.Blue.TabIndex = 8;
            this.Blue.Text = "0";
            this.Blue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Blue.Click += new System.EventHandler(this.Blue_Click);
            // 
            // White
            // 
            this.White.BackColor = System.Drawing.Color.White;
            this.White.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.White.Location = new System.Drawing.Point(3, 117);
            this.White.Name = "White";
            this.White.Size = new System.Drawing.Size(21, 19);
            this.White.TabIndex = 7;
            this.White.Text = "0";
            this.White.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.White.Click += new System.EventHandler(this.White_Click);
            // 
            // CardPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "CardPanel";
            this.Size = new System.Drawing.Size(197, 224);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Points;
        private System.Windows.Forms.Label Color;
        private System.Windows.Forms.Label Black;
        private System.Windows.Forms.Label Red;
        private System.Windows.Forms.Label Green;
        private System.Windows.Forms.Label Blue;
        private System.Windows.Forms.Label White;
    }
}
