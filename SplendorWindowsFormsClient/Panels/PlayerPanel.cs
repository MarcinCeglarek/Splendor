namespace SplendorFormsClient.Panels
{
    #region

    using System;
    using System.Windows.Forms;

    using SplendorCore.Models;

    #endregion

    public partial class PlayerPanel : UserControl
    {
        #region Constructors and Destructors

        public PlayerPanel()
        {
            this.InitializeComponent();

            this.CardsBlack.BackColor = FormsColor.BackColor(Color.Black);
            this.CardsBlack.ForeColor = FormsColor.ForeColor(Color.Black);
            this.ChipsBlack.BackColor = FormsColor.BackColor(Color.Black);
            this.ChipsBlack.ForeColor = FormsColor.ForeColor(Color.Black);
            
            this.CardsBlue.BackColor = FormsColor.BackColor(Color.Blue);
            this.CardsBlue.ForeColor = FormsColor.ForeColor(Color.Blue);
            this.ChipsBlue.BackColor = FormsColor.BackColor(Color.Blue);
            this.ChipsBlue.ForeColor = FormsColor.ForeColor(Color.Blue);
            
            this.ChipsGold.BackColor = FormsColor.BackColor(Color.Gold);
            this.ChipsGold.ForeColor = FormsColor.ForeColor(Color.Gold);
            
            this.CardsGreen.BackColor = FormsColor.BackColor(Color.Green);
            this.CardsGreen.ForeColor = FormsColor.ForeColor(Color.Green);
            this.ChipsGreen.BackColor = FormsColor.BackColor(Color.Green);
            this.ChipsGreen.ForeColor = FormsColor.ForeColor(Color.Green);
            
            this.CardsRed.BackColor = FormsColor.BackColor(Color.Red);
            this.CardsRed.ForeColor = FormsColor.ForeColor(Color.Red);
            this.ChipsRed.BackColor = FormsColor.BackColor(Color.Red);
            this.ChipsRed.ForeColor = FormsColor.ForeColor(Color.Red);

            this.CardsWhite.BackColor = FormsColor.BackColor(Color.White);
            this.CardsWhite.ForeColor = FormsColor.ForeColor(Color.White);
            this.ChipsWhite.BackColor = FormsColor.BackColor(Color.White);
            this.ChipsWhite.ForeColor = FormsColor.ForeColor(Color.White);
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
                    this.reservedCard1.BackColor = FormsColor.BackColor(this.Player.ReservedCards[0].Color);

                    this.reservedCard2.Visible = true;
                    this.reservedCard2.BackColor = FormsColor.BackColor(this.Player.ReservedCards[1].Color);

                    this.reservedCard3.Visible = true;
                    this.reservedCard3.BackColor = FormsColor.BackColor(this.Player.ReservedCards[2].Color);
                }
                else if (this.Player.ReservedCards.Count == 2)
                {
                    this.reservedCard1.Visible = true;
                    this.reservedCard1.BackColor = FormsColor.BackColor(this.Player.ReservedCards[0].Color);

                    this.reservedCard2.Visible = true;
                    this.reservedCard2.BackColor = FormsColor.BackColor(this.Player.ReservedCards[1].Color);

                    this.reservedCard3.Visible = false;
                    this.reservedCard3.BackColor = DefaultBackColor;
                }
                else if (this.Player.ReservedCards.Count == 1)
                {
                    this.reservedCard1.Visible = true;
                    this.reservedCard1.BackColor = FormsColor.BackColor(this.Player.ReservedCards[0].Color);

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