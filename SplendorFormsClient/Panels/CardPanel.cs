namespace SplendorFormsClient.Panels
{
    #region

    using System;
    using System.Collections.Generic;
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
                    this.Visible = false;
                    return;
                }

                this.Visible = true;
                this.UpdateLabelValue(this.Points, this.card.VictoryPoints);
                this.Color.BackColor = FormsColor.BackColor(this.card.Color);
                this.Points.BackColor = FormsColor.BackColor(this.card.Color);
                this.Points.ForeColor = FormsColor.ForeColor(this.card.Color);
                var costList = this.card.Cost.Where(cost => cost.Value != 0).OrderByDescending(cost => (int)cost.Key).ToList();
                switch (costList.Count())
                {
                    case 1:
                        this.FillCardCost(this.L1, costList[0]);
                        this.FillCardCost(this.L2);
                        this.FillCardCost(this.L3);
                        this.FillCardCost(this.L4);
                        this.FillCardCost(this.L5);
                        break;
                    case 2:
                        this.FillCardCost(this.L1, costList[0]);
                        this.FillCardCost(this.L2, costList[1]);
                        this.FillCardCost(this.L3);
                        this.FillCardCost(this.L4);
                        this.FillCardCost(this.L5);
                        break;
                    case 3:
                        this.FillCardCost(this.L1, costList[0]);
                        this.FillCardCost(this.L2, costList[1]);
                        this.FillCardCost(this.L3, costList[2]);
                        this.FillCardCost(this.L4);
                        this.FillCardCost(this.L5);
                        break;
                    case 4:
                        this.FillCardCost(this.L1, costList[0]);
                        this.FillCardCost(this.L2, costList[1]);
                        this.FillCardCost(this.L3, costList[2]);
                        this.FillCardCost(this.L4, costList[3]);
                        this.FillCardCost(this.L5);

                        break;
                    case 5:
                        this.FillCardCost(this.L1, costList[0]);
                        this.FillCardCost(this.L2, costList[1]);
                        this.FillCardCost(this.L3, costList[2]);
                        this.FillCardCost(this.L4, costList[3]);
                        this.FillCardCost(this.L5, costList[4]);
                        break;
                }
            }
        }

        public int Tier
        {
            get
            {
                return int.Parse(this.Name.Substring(4, 1));
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

        private void FillCardCost(Label label, KeyValuePair<Color, int> cardCost = new KeyValuePair<Color, int>())
        {
            this.UpdateLabelValue(label, cardCost.Value);
            if (cardCost.Value > 0)
            {
                this.UpdateLabelColor(label, cardCost.Key);
            }
        }

        private void Green_Click(object sender, EventArgs e)
        {
            Program.MainWindow.PurchaseOrReserveCard(this.card);
        }

        private void Points_Click(object sender, EventArgs e)
        {
            Program.MainWindow.PurchaseOrReserveCard(this.card);
        }

        private void Red_Click(object sender, EventArgs e)
        {
            Program.MainWindow.PurchaseOrReserveCard(this.card);
        }

        private void UpdateLabelColor(Label label, Color color)
        {
            label.ForeColor = FormsColor.ForeColor(color);
            label.BackColor = FormsColor.BackColor(color);
        }

        private void UpdateLabelValue(Label label, int value)
        {
            if (value > 0)
            {
                label.Visible = true;
                label.Text = value.ToString();
            }
            else
            {
                label.Visible = false;
            }
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