namespace SplendorFormsClient.Panels
{
    #region

    using System;
    using System.Linq;
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

                var costList = this.card.Cost.Where(cost => cost.Value != 0).ToList();
                switch (costList.Count())
                {
                    case 1:
                        this.ColorizeLabel(this.L1, costList[0].Key);
                        this.PopulateLabel(this.L1, costList[0].Value);
                        this.PopulateLabel(this.L2, 0);
                        this.PopulateLabel(this.L3, 0);
                        this.PopulateLabel(this.L4, 0);
                        this.PopulateLabel(this.L5, 0);
                        break;
                    case 2:
                        this.ColorizeLabel(this.L1, costList[0].Key);
                        this.PopulateLabel(this.L1, costList[0].Value);
                        this.ColorizeLabel(this.L2, costList[1].Key);
                        this.PopulateLabel(this.L2, costList[1].Value);
                        this.PopulateLabel(this.L3, 0);
                        this.PopulateLabel(this.L4, 0);
                        this.PopulateLabel(this.L5, 0);
                        break;
                    case 3:
                        this.ColorizeLabel(this.L1, costList[0].Key);
                        this.PopulateLabel(this.L1, costList[0].Value);
                        this.ColorizeLabel(this.L2, costList[1].Key);
                        this.PopulateLabel(this.L2, costList[1].Value);
                        this.ColorizeLabel(this.L3, costList[2].Key);
                        this.PopulateLabel(this.L3, costList[2].Value);
                        this.PopulateLabel(this.L4, 0);
                        this.PopulateLabel(this.L5, 0);
                        break;
                    case 4:
                        this.ColorizeLabel(this.L1, costList[0].Key);
                        this.PopulateLabel(this.L1, costList[0].Value);
                        this.ColorizeLabel(this.L2, costList[1].Key);
                        this.PopulateLabel(this.L2, costList[1].Value);
                        this.ColorizeLabel(this.L3, costList[2].Key);
                        this.PopulateLabel(this.L3, costList[2].Value);
                        this.ColorizeLabel(this.L4, costList[3].Key);
                        this.PopulateLabel(this.L4, costList[3].Value);
                        this.PopulateLabel(this.L5, 0);

                        break;
                    case 5:
                        this.ColorizeLabel(this.L1, costList[0].Key);
                        this.PopulateLabel(this.L1, costList[0].Value);
                        this.ColorizeLabel(this.L2, costList[1].Key);
                        this.PopulateLabel(this.L2, costList[1].Value);
                        this.ColorizeLabel(this.L3, costList[2].Key);
                        this.PopulateLabel(this.L3, costList[2].Value);
                        this.ColorizeLabel(this.L4, costList[3].Key);
                        this.PopulateLabel(this.L4, costList[3].Value);
                        this.ColorizeLabel(this.L5, costList[4].Key);
                        this.PopulateLabel(this.L5, costList[4].Value);
                        break;
                }

                this.PopulateLabel(this.Points, this.card.VictoryPoints);

                switch (this.card.Color)
                {
                    case SplendorCore.Models.Color.Black:
                        this.Color.BackColor = FormsColor.BackColor(SplendorCore.Models.Color.Black);
                        this.Points.BackColor = FormsColor.BackColor(SplendorCore.Models.Color.Black);
                        this.Points.ForeColor = FormsColor.ForeColor(SplendorCore.Models.Color.Black);
                        break;
                    case SplendorCore.Models.Color.Blue:
                        this.Color.BackColor = FormsColor.BackColor(SplendorCore.Models.Color.Blue);
                        this.Points.BackColor = FormsColor.BackColor(SplendorCore.Models.Color.Blue);
                        this.Points.ForeColor = FormsColor.ForeColor(SplendorCore.Models.Color.Blue);
                        break;
                    case SplendorCore.Models.Color.White:
                        this.Color.BackColor = FormsColor.BackColor(SplendorCore.Models.Color.White);
                        this.Points.BackColor = FormsColor.BackColor(SplendorCore.Models.Color.White);
                        this.Points.ForeColor = FormsColor.ForeColor(SplendorCore.Models.Color.White);
                        break;
                    case SplendorCore.Models.Color.Red:
                        this.Color.BackColor = FormsColor.BackColor(SplendorCore.Models.Color.Red);
                        this.Points.BackColor = FormsColor.BackColor(SplendorCore.Models.Color.Red);
                        this.Points.ForeColor = FormsColor.ForeColor(SplendorCore.Models.Color.Red);
                        break;
                    case SplendorCore.Models.Color.Green:
                        this.Color.BackColor = FormsColor.BackColor(SplendorCore.Models.Color.Green);
                        this.Points.BackColor = FormsColor.BackColor(SplendorCore.Models.Color.Green);
                        this.Points.ForeColor = FormsColor.ForeColor(SplendorCore.Models.Color.Green);
                        break;
                }
            }
        }

        private void ColorizeLabel(Label label, Color color)
        {
            label.ForeColor = FormsColor.ForeColor(color);
            label.BackColor = FormsColor.BackColor(color);
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