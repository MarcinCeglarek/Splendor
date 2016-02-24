namespace SplendorFormsClient.Panels
{
    #region

    using System;
    using System.Windows.Forms;

    using SplendorCore.Models;

    using Color = System.Drawing.Color;

    #endregion

    public partial class PlayerPanel : UserControl
    {
        #region Constructors and Destructors

        public PlayerPanel()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        public Player Player { get; set; }

        #endregion

        #region Public Methods and Operators

        public void RefreshValues()
        {
            if (this.Player != null)
            {
                this.CardsWhite.Text = this.Player.Cards.White.ToString();
                this.CardsBlue.Text = this.Player.Cards.Blue.ToString();
                this.CardsBlack.Text = this.Player.Cards.Black.ToString();
                this.CardsGreen.Text = this.Player.Cards.Green.ToString();
                this.CardsRed.Text = this.Player.Cards.Red.ToString();


                this.ChipsWhite.Text = this.Player.Chips.White.ToString();
                this.ChipsBlue.Text = this.Player.Chips.Blue.ToString();
                this.ChipsBlack.Text = this.Player.Chips.Black.ToString();
                this.ChipsGreen.Text = this.Player.Chips.Green.ToString();
                this.ChipsRed.Text = this.Player.Chips.Red.ToString();
                this.ChipsGold.Text = this.Player.Chips.Gold.ToString();

                if (this.Player.ReservedCards.Count == 3)
                {
                    this.reservedCard1.Enabled = true;
                    this.reservedCard1.BackColor = this.GetColor(this.Player.ReservedCards[0].Color);

                    this.reservedCard2.Enabled = true;
                    this.reservedCard2.BackColor = this.GetColor(this.Player.ReservedCards[1].Color);

                    this.reservedCard3.Enabled = true;
                    this.reservedCard3.BackColor = this.GetColor(this.Player.ReservedCards[2].Color);
                }
                else if (this.Player.ReservedCards.Count == 2)
                {
                    this.reservedCard1.Enabled = true;
                    this.reservedCard1.BackColor = this.GetColor(this.Player.ReservedCards[0].Color);

                    this.reservedCard2.Enabled = true;
                    this.reservedCard2.BackColor = this.GetColor(this.Player.ReservedCards[1].Color);

                    this.reservedCard3.Enabled = false;
                    this.reservedCard3.BackColor = DefaultBackColor;
                }
                else if (this.Player.ReservedCards.Count == 1)
                {
                    this.reservedCard1.Enabled = true;
                    this.reservedCard1.BackColor = this.GetColor(this.Player.ReservedCards[0].Color);

                    this.reservedCard2.Enabled = false;
                    this.reservedCard2.BackColor = DefaultBackColor;

                    this.reservedCard3.Enabled = false;
                    this.reservedCard3.BackColor = DefaultBackColor;
                }
                else
                {
                    this.reservedCard1.Enabled = false;
                    this.reservedCard1.BackColor = DefaultBackColor;

                    this.reservedCard2.Enabled = false;
                    this.reservedCard2.BackColor = DefaultBackColor;

                    this.reservedCard3.Enabled = false;
                    this.reservedCard3.BackColor = DefaultBackColor;
                }
            }
        }

        #endregion

        #region Methods

        private void CardsBlue_Click(object sender, EventArgs e)
        {
        }

        private Color GetColor(SplendorCore.Models.Color color)
        {
            switch (color)
            {
                case SplendorCore.Models.Color.Black:
                    return Color.Black;
                    break;
                case SplendorCore.Models.Color.Blue:
                    return Color.Blue;
                    break;
                case SplendorCore.Models.Color.Gold:
                    return Color.Gold;
                    break;
                case SplendorCore.Models.Color.Green:
                    return Color.Green;
                    break;
                case SplendorCore.Models.Color.Red:
                    return Color.Red;
                    break;
                case SplendorCore.Models.Color.White:
                    return Color.White;
            }

            throw new NotSupportedException();
        }

        #endregion

        private void reservedCard1_Click(object sender, EventArgs e)
        {
            Program.MainWindow.BuyReservedCard(this.Player.ReservedCards[0]);
        }

        private void reservedCard2_Click(object sender, EventArgs e)
        {
            Program.MainWindow.BuyReservedCard(this.Player.ReservedCards[1]);
        }

        private void reservedCard3_Click(object sender, EventArgs e)
        {
            Program.MainWindow.BuyReservedCard(this.Player.ReservedCards[2]);
        }
    }
}