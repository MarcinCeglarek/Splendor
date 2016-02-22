namespace SplendorFormsClient.Panels
{
    using System.Windows.Forms;

    using SplendorCore.Models;

    public partial class CardPanel : UserControl
    {
        private Card card;

        public CardPanel()
        {
            InitializeComponent();
        }

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

                this.Black.Text = this.card.Cost.Black.ToString();
                this.Blue.Text = this.card.Cost.Blue.ToString();
                this.White.Text = this.card.Cost.White.ToString();
                this.Green.Text = this.card.Cost.Green.ToString();
                this.Red.Text = this.card.Cost.Red.ToString();
                this.Points.Text = this.card.VictoryPoints.ToString();
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
    }
}
