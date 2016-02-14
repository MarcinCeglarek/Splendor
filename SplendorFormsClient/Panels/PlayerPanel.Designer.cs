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

        private Player player;

        public string Name { get; set; }

        public Player Player
        {
            get
            {
                return this.player;
            }
            set
            {
                this.player = value;
                this.Update();
            }
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CardsWhite = new System.Windows.Forms.Button();
            this.CardsBlue = new System.Windows.Forms.Button();
            this.CardsGreen = new System.Windows.Forms.Button();
            this.CardsRed = new System.Windows.Forms.Button();
            this.CardsBlack = new System.Windows.Forms.Button();
            this.ChipsBlack = new System.Windows.Forms.Button();
            this.ChipsRed = new System.Windows.Forms.Button();
            this.ChipsGreen = new System.Windows.Forms.Button();
            this.ChipsBlue = new System.Windows.Forms.Button();
            this.ChipsWhite = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ChipsBlack);
            this.panel1.Controls.Add(this.ChipsRed);
            this.panel1.Controls.Add(this.ChipsGreen);
            this.panel1.Controls.Add(this.ChipsBlue);
            this.panel1.Controls.Add(this.ChipsWhite);
            this.panel1.Controls.Add(this.CardsBlack);
            this.panel1.Controls.Add(this.CardsRed);
            this.panel1.Controls.Add(this.CardsGreen);
            this.panel1.Controls.Add(this.CardsBlue);
            this.panel1.Controls.Add(this.CardsWhite);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 267);
            this.panel1.TabIndex = 0;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cards";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Chips";
            // 
            // CardsWhite
            // 
            this.CardsWhite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CardsWhite.BackColor = System.Drawing.Color.White;
            this.CardsWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CardsWhite.Location = new System.Drawing.Point(3, 49);
            this.CardsWhite.Name = "CardsWhite";
            this.CardsWhite.Size = new System.Drawing.Size(51, 23);
            this.CardsWhite.TabIndex = 3;
            this.CardsWhite.Text = "0";
            this.CardsWhite.UseVisualStyleBackColor = false;
            // 
            // CardsBlue
            // 
            this.CardsBlue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CardsBlue.BackColor = System.Drawing.Color.Blue;
            this.CardsBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CardsBlue.ForeColor = System.Drawing.Color.White;
            this.CardsBlue.Location = new System.Drawing.Point(60, 49);
            this.CardsBlue.Name = "CardsBlue";
            this.CardsBlue.Size = new System.Drawing.Size(51, 23);
            this.CardsBlue.TabIndex = 4;
            this.CardsBlue.Text = "0";
            this.CardsBlue.UseVisualStyleBackColor = false;
            // 
            // CardsGreen
            // 
            this.CardsGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CardsGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.CardsGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CardsGreen.ForeColor = System.Drawing.Color.White;
            this.CardsGreen.Location = new System.Drawing.Point(117, 49);
            this.CardsGreen.Name = "CardsGreen";
            this.CardsGreen.Size = new System.Drawing.Size(51, 23);
            this.CardsGreen.TabIndex = 5;
            this.CardsGreen.Text = "0";
            this.CardsGreen.UseVisualStyleBackColor = false;
            // 
            // CardsRed
            // 
            this.CardsRed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CardsRed.BackColor = System.Drawing.Color.Red;
            this.CardsRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CardsRed.ForeColor = System.Drawing.Color.White;
            this.CardsRed.Location = new System.Drawing.Point(174, 49);
            this.CardsRed.Name = "CardsRed";
            this.CardsRed.Size = new System.Drawing.Size(51, 23);
            this.CardsRed.TabIndex = 6;
            this.CardsRed.Text = "0";
            this.CardsRed.UseVisualStyleBackColor = false;
            // 
            // CardsBlack
            // 
            this.CardsBlack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CardsBlack.BackColor = System.Drawing.Color.Black;
            this.CardsBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CardsBlack.ForeColor = System.Drawing.Color.White;
            this.CardsBlack.Location = new System.Drawing.Point(231, 49);
            this.CardsBlack.Name = "CardsBlack";
            this.CardsBlack.Size = new System.Drawing.Size(47, 23);
            this.CardsBlack.TabIndex = 7;
            this.CardsBlack.Text = "0";
            this.CardsBlack.UseVisualStyleBackColor = false;
            // 
            // ChipsBlack
            // 
            this.ChipsBlack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChipsBlack.BackColor = System.Drawing.Color.Black;
            this.ChipsBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ChipsBlack.ForeColor = System.Drawing.Color.White;
            this.ChipsBlack.Location = new System.Drawing.Point(231, 111);
            this.ChipsBlack.Name = "ChipsBlack";
            this.ChipsBlack.Size = new System.Drawing.Size(47, 23);
            this.ChipsBlack.TabIndex = 12;
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
            this.ChipsRed.Location = new System.Drawing.Point(174, 111);
            this.ChipsRed.Name = "ChipsRed";
            this.ChipsRed.Size = new System.Drawing.Size(51, 23);
            this.ChipsRed.TabIndex = 11;
            this.ChipsRed.Text = "0";
            this.ChipsRed.UseVisualStyleBackColor = false;
            // 
            // ChipsGreen
            // 
            this.ChipsGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChipsGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ChipsGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ChipsGreen.ForeColor = System.Drawing.Color.White;
            this.ChipsGreen.Location = new System.Drawing.Point(117, 111);
            this.ChipsGreen.Name = "ChipsGreen";
            this.ChipsGreen.Size = new System.Drawing.Size(51, 23);
            this.ChipsGreen.TabIndex = 10;
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
            this.ChipsBlue.Location = new System.Drawing.Point(60, 111);
            this.ChipsBlue.Name = "ChipsBlue";
            this.ChipsBlue.Size = new System.Drawing.Size(51, 23);
            this.ChipsBlue.TabIndex = 9;
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
            this.ChipsWhite.Location = new System.Drawing.Point(3, 111);
            this.ChipsWhite.Name = "ChipsWhite";
            this.ChipsWhite.Size = new System.Drawing.Size(51, 23);
            this.ChipsWhite.TabIndex = 8;
            this.ChipsWhite.Text = "0";
            this.ChipsWhite.UseVisualStyleBackColor = false;
            // 
            // PlayerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "PlayerPanel";
            this.Size = new System.Drawing.Size(287, 273);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CardsBlack;
        private System.Windows.Forms.Button CardsRed;
        private System.Windows.Forms.Button CardsGreen;
        private System.Windows.Forms.Button CardsBlue;
        private System.Windows.Forms.Button CardsWhite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ChipsBlack;
        private System.Windows.Forms.Button ChipsRed;
        private System.Windows.Forms.Button ChipsGreen;
        private System.Windows.Forms.Button ChipsBlue;
        private System.Windows.Forms.Button ChipsWhite;
    }
}
