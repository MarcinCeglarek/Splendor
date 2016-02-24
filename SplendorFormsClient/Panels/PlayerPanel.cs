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
                this.PlayerName.Text = this.Player.Name;

                this.PopulateButton(this.CardsWhite, this.Player.Cards.White);
                this.PopulateButton(this.CardsBlue, this.Player.Cards.Blue);
                this.PopulateButton(this.CardsBlack, this.Player.Cards.Black);
                this.PopulateButton(this.CardsGreen, this.Player.Cards.Green);
                this.PopulateButton(this.CardsRed, this.Player.Cards.Red);

                this.PopulateButton(this.ChipsWhite, this.Player.Chips.White);
                this.PopulateButton(this.ChipsBlue, this.Player.Chips.Blue);
                this.PopulateButton(this.ChipsBlack, this.Player.Chips.Black);
                this.PopulateButton(this.ChipsGreen, this.Player.Chips.Green);
                this.PopulateButton(this.ChipsRed, this.Player.Chips.Red);
                this.PopulateButton(this.ChipsGold, this.Player.Chips.Gold);

                if (this.Player.VictoryPoints > 0)
                {
                    this.VictoryPoints.Visible = true;
                    this.VictoryPoints.Text = this.Player.VictoryPoints.ToString();
                }
                else
                {
                    this.VictoryPoints.Visible = false;
                }

                if (this.Player.ReservedCards.Count == 3)
                {
                    this.reservedCard1.Visible = true;
                    this.reservedCard1.BackColor = this.GetColor(this.Player.ReservedCards[0].Color);

                    this.reservedCard2.Visible = true;
                    this.reservedCard2.BackColor = this.GetColor(this.Player.ReservedCards[1].Color);

                    this.reservedCard3.Visible = true;
                    this.reservedCard3.BackColor = this.GetColor(this.Player.ReservedCards[2].Color);
                }
                else if (this.Player.ReservedCards.Count == 2)
                {
                    this.reservedCard1.Visible = true;
                    this.reservedCard1.BackColor = this.GetColor(this.Player.ReservedCards[0].Color);

                    this.reservedCard2.Visible = true;
                    this.reservedCard2.BackColor = this.GetColor(this.Player.ReservedCards[1].Color);

                    this.reservedCard3.Visible = false;
                    this.reservedCard3.BackColor = DefaultBackColor;
                }
                else if (this.Player.ReservedCards.Count == 1)
                {
                    this.reservedCard1.Visible = true;
                    this.reservedCard1.BackColor = this.GetColor(this.Player.ReservedCards[0].Color);

                    this.reservedCard2.Visible = false;
                    this.reservedCard2.BackColor = DefaultBackColor;

                    this.reservedCard3.Visible = false;
                    this.reservedCard3.BackColor = DefaultBackColor;
                }
                else
                {
                    this.reservedCard1.Visible = false;
                    this.reservedCard1.BackColor = DefaultBackColor;

                    this.reservedCard2.Visible = false;
                    this.reservedCard2.BackColor = DefaultBackColor;

                    this.reservedCard3.Visible = false;
                    this.reservedCard3.BackColor = DefaultBackColor;
                }
            }
        }

        #endregion

        #region Methods

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

        private void PopulateButton(Button button, int amount)
        {
            if (amount > 0)
            {
                button.Visible = true;
                button.Text = amount.ToString();
            }
            else
            {
                button.Visible = false;
            }
        }

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

        #endregion
    }
}