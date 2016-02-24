namespace SplendorFormsClient.Panels
{
    #region

    using System;
    using System.Windows.Forms;

    using SplendorCore.Models;

    #endregion

    public partial class CardPanel : UserControl
    {
        #region Fields

        private Card card;

        #endregion

        #region Constructors and Destructors

        public CardPanel()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        public Card Card
        {
            get
            {
                return this.card;
            }

            set
            {
                this.card = value;

                if (this.card == null)
                {
                    return;
                }

                this.PopulateLabel(this.Black, this.card.Cost.Black);
                this.PopulateLabel(this.Blue, this.card.Cost.Blue);
                this.PopulateLabel(this.White, this.card.Cost.White);
                this.PopulateLabel(this.Green, this.card.Cost.Green);
                this.PopulateLabel(this.Red, this.card.Cost.Red);
                this.PopulateLabel(this.Points, this.card.VictoryPoints);

                switch (this.card.Color)
                {
                    case SplendorCore.Models.Color.Black:
                        this.Color.BackColor = System.Drawing.Color.Black;
                        this.Points.BackColor = System.Drawing.Color.Black;
                        this.Points.ForeColor = System.Drawing.Color.White;
                        break;
                    case SplendorCore.Models.Color.Blue:
                        this.Color.BackColor = System.Drawing.Color.Blue;
                        this.Points.BackColor = System.Drawing.Color.Blue;
                        this.Points.ForeColor = System.Drawing.Color.White;
                        break;
                    case SplendorCore.Models.Color.White:
                        this.Color.BackColor = System.Drawing.Color.White;
                        this.Points.BackColor = System.Drawing.Color.White;
                        this.Points.ForeColor = System.Drawing.Color.Black;
                        break;
                    case SplendorCore.Models.Color.Red:
                        this.Color.BackColor = System.Drawing.Color.Red;
                        this.Points.BackColor = System.Drawing.Color.Red;
                        this.Points.ForeColor = System.Drawing.Color.White;
                        break;
                    case SplendorCore.Models.Color.Green:
                        this.Color.BackColor = System.Drawing.Color.Green;
                        this.Points.BackColor = System.Drawing.Color.Green;
                        this.Points.ForeColor = System.Drawing.Color.White;
                        break;
                }
            }
        }

        #endregion

        #region Methods

        private void Black_Click(object sender, EventArgs e)
        {
            Program.MainWindow.PurchaseOrReserveCard(this.card);
        }

        private void Blue_Click(object sender, EventArgs e)
        {
            Program.MainWindow.PurchaseOrReserveCard(this.card);
        }

        private void Color_Click(object sender, EventArgs e)
        {
            Program.MainWindow.PurchaseOrReserveCard(this.card);
        }

        private void Green_Click(object sender, EventArgs e)
        {
            Program.MainWindow.PurchaseOrReserveCard(this.card);
        }

        private void Points_Click(object sender, EventArgs e)
        {
            Program.MainWindow.PurchaseOrReserveCard(this.card);
        }

        private void PopulateLabel(Label label, int amount)
        {
            if (amount > 0)
            {
                label.Visible = true;
                label.Text = amount.ToString();
            }
            else
            {
                label.Visible = false;
            }
        }

        private void Red_Click(object sender, EventArgs e)
        {
            Program.MainWindow.PurchaseOrReserveCard(this.card);
        }

        private void White_Click(object sender, EventArgs e)
        {
            Program.MainWindow.PurchaseOrReserveCard(this.card);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Program.MainWindow.PurchaseOrReserveCard(this.card);
        }

        #endregion
    }
}