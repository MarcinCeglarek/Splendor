namespace SplendorWindowsFormsClient.Panels
{
    #region

    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    using SplendorCore.Models;

    #endregion

    public partial class AristocratePanel : UserControl
    {
        #region Fields

        private Aristocrate aristocrate;

        #endregion

        #region Constructors and Destructors

        public AristocratePanel()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        public Aristocrate Aristocrate
        {
            get { return this.aristocrate; }

            set
            {
                this.aristocrate = value;

                if (this.aristocrate == null)
                {
                    return;
                }

                this.VictoryPoints.Text = this.aristocrate.VictoryPoints.ToString();
                var requiredCards = this.aristocrate.RequiredCards.Where(card => card.Value != 0).OrderByDescending(card => (int)card.Key).ToList();

                switch (requiredCards.Count)
                {
                    case 3:
                        this.UpdateCostLabel(this.L1, requiredCards[0]);
                        this.UpdateCostLabel(this.L2, requiredCards[1]);
                        this.UpdateCostLabel(this.L3, requiredCards[2]);
                        break;
                    case 2:
                        this.UpdateCostLabel(this.L1, requiredCards[0]);
                        this.UpdateCostLabel(this.L2, requiredCards[1]);
                        this.L3.Visible = false;
                        break;
                    case 1:
                        this.UpdateCostLabel(this.L1, requiredCards[0]);
                        this.L2.Visible = false;
                        this.L3.Visible = false;
                        break;
                }
            }
        }

        #endregion

        #region Methods

        private void UpdateCostLabel(Label label, KeyValuePair<Color, int> requiredCard)
        {
            label.Visible = true;
            label.BackColor = FormsColor.BackColor(requiredCard.Key);
            label.ForeColor = FormsColor.ForeColor(requiredCard.Key);
            label.Text = requiredCard.Value.ToString();
        }

        #endregion
    }
}