namespace SplendorWindowsFormsClient.Panels
{
    partial class AristocratePanel
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.VictoryPoints = new System.Windows.Forms.Label();
            this.L3 = new System.Windows.Forms.Label();
            this.L2 = new System.Windows.Forms.Label();
            this.L1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.VictoryPoints);
            this.panel1.Controls.Add(this.L3);
            this.panel1.Controls.Add(this.L2);
            this.panel1.Controls.Add(this.L1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(112, 120);
            this.panel1.TabIndex = 1;
            // 
            // VictoryPoints
            // 
            this.VictoryPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.VictoryPoints.Location = new System.Drawing.Point(70, 10);
            this.VictoryPoints.Name = "VictoryPoints";
            this.VictoryPoints.Size = new System.Drawing.Size(30, 31);
            this.VictoryPoints.TabIndex = 4;
            this.VictoryPoints.Text = "0";
            this.VictoryPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // L3
            // 
            this.L3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.L3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.L3.Location = new System.Drawing.Point(3, 48);
            this.L3.Name = "L3";
            this.L3.Size = new System.Drawing.Size(19, 20);
            this.L3.TabIndex = 3;
            this.L3.Text = "0";
            this.L3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // L2
            // 
            this.L2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.L2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.L2.Location = new System.Drawing.Point(3, 71);
            this.L2.Name = "L2";
            this.L2.Size = new System.Drawing.Size(19, 20);
            this.L2.TabIndex = 2;
            this.L2.Text = "0";
            this.L2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // L1
            // 
            this.L1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.L1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.L1.Location = new System.Drawing.Point(3, 94);
            this.L1.Name = "L1";
            this.L1.Size = new System.Drawing.Size(19, 20);
            this.L1.TabIndex = 1;
            this.L1.Text = "0";
            this.L1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AristocratePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "AristocratePanel";
            this.Size = new System.Drawing.Size(120, 126);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label VictoryPoints;
        private System.Windows.Forms.Label L3;
        private System.Windows.Forms.Label L2;
        private System.Windows.Forms.Label L1;

    }
}
