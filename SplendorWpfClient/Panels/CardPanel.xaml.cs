namespace SplendorWpfClient.Panels
{
    #region

    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    using SplendorCore.Models;

    #endregion

    public partial class CardPanel : UserControl
    {
        #region Constructors and Destructors

        public CardPanel()
        {
            this.InitializeComponent();
        }

        private Card card;

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
                    this.Visibility = Visibility.Hidden;
                    return;
                }

                this.Visibility = Visibility.Visible;
                this.UpdateLabelValue(this.Color, this.card.VictoryPoints);

                var costList = this.card.Cost.Where(cost => cost.Value != 0).OrderByDescending(cost => (int)cost.Key).ToList();
                switch (costList.Count())
                {
                    case 1:
                        this.FillCardCost(this.C1, costList[0]);
                        this.FillCardCost(this.C2);
                        this.FillCardCost(this.C3);
                        this.FillCardCost(this.C4);
                        this.FillCardCost(this.C5);
                        break;
                    case 2:
                        this.FillCardCost(this.C1, costList[0]);
                        this.FillCardCost(this.C2, costList[1]);
                        this.FillCardCost(this.C3);
                        this.FillCardCost(this.C4);
                        this.FillCardCost(this.C5);
                        break;
                    case 3:
                        this.FillCardCost(this.C1, costList[0]);
                        this.FillCardCost(this.C2, costList[1]);
                        this.FillCardCost(this.C3, costList[2]);
                        this.FillCardCost(this.C4);
                        this.FillCardCost(this.C5);
                        break;
                    case 4:
                        this.FillCardCost(this.C1, costList[0]);
                        this.FillCardCost(this.C2, costList[1]);
                        this.FillCardCost(this.C3, costList[2]);
                        this.FillCardCost(this.C4, costList[3]);
                        this.FillCardCost(this.C5);

                        break;
                    case 5:
                        this.FillCardCost(this.C1, costList[0]);
                        this.FillCardCost(this.C2, costList[1]);
                        this.FillCardCost(this.C3, costList[2]);
                        this.FillCardCost(this.C4, costList[3]);
                        this.FillCardCost(this.C5, costList[4]);
                        break;
                }
            }
        }
        #endregion

        private void UpdateLabelValue(Label label, int value)
        {
            if (value > 0)
            {
                label.Visibility = Visibility.Visible;
                label.Content = value;
            }
            else
            {
                label.Visibility = Visibility.Hidden;
            }
        }

        private void FillCardCost(Label label, KeyValuePair<Color, int> cardCost = new KeyValuePair<Color, int>())
        {
            this.UpdateLabelValue(label, cardCost.Value);
            if (cardCost.Value > 0)
            {
                this.UpdateLabelColor(label, cardCost.Key);
            }
        }

        private void UpdateLabelColor(Label label, Color color)
        {
/*            label.Foreground = FormsColor.ForeColor(color);
            label.Background = FormsColor.BackColor(color);*/
        }

    }
}