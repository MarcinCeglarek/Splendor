namespace SplendorFormsClient.Panels
{
    #region

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
            get
            {
                return this.aristocrate;
            }

            set
            {
                this.aristocrate = value;

                if (this.aristocrate == null)
                {
                    return;
                }

                this.VictoryPoints.Text = this.aristocrate.VictoryPoints.ToString();

                var requiredCards = this.aristocrate.RequiredCards.Where(card => card.Value != 0).ToList();
                switch (requiredCards.Count)
                {
                    case 3:
                        this.L1.Visible = true;
                        this.L1.BackColor = FormsColor.BackColor(requiredCards[0].Key);
                        this.L1.ForeColor = FormsColor.ForeColor(requiredCards[0].Key);
                        this.L1.Text = requiredCards[0].Value.ToString();

                        this.L2.Visible = true;
                        this.L2.BackColor = FormsColor.BackColor(requiredCards[1].Key);
                        this.L2.ForeColor = FormsColor.ForeColor(requiredCards[1].Key);
                        this.L2.Text = requiredCards[1].Value.ToString();

                        this.L3.Visible = true;
                        this.L3.BackColor = FormsColor.BackColor(requiredCards[2].Key);
                        this.L3.ForeColor = FormsColor.ForeColor(requiredCards[2].Key);
                        this.L3.Text = requiredCards[2].Value.ToString();
                        break;
                    case 2:
                        this.L1.Visible = true;
                        this.L1.BackColor = FormsColor.BackColor(requiredCards[0].Key);
                        this.L1.ForeColor = FormsColor.ForeColor(requiredCards[0].Key);
                        this.L1.Text = requiredCards[0].Value.ToString();

                        this.L2.Visible = true;
                        this.L2.BackColor = FormsColor.BackColor(requiredCards[1].Key);
                        this.L2.ForeColor = FormsColor.ForeColor(requiredCards[1].Key);
                        this.L2.Text = requiredCards[1].Value.ToString();

                        this.L3.Visible = false;
                        break;
                    case 1:
                        this.L1.Visible = true;
                        this.L1.BackColor = FormsColor.BackColor(requiredCards[0].Key);
                        this.L1.ForeColor = FormsColor.ForeColor(requiredCards[0].Key);
                        this.L1.Text = requiredCards[0].Value.ToString();

                        this.L2.Visible = false;
                        this.L3.Visible = false;
                        break;
                }
            }
        }

        #endregion
    }
}