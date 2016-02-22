namespace SplendorFormsClient.Panels
{
    #region

    using System.Windows.Forms;

    using SplendorCore.Models;

    #endregion

    public partial class PlayerPanel : UserControl
    {
        #region Constructors and Destructors

        public PlayerPanel(Player player)
        {
            this.Player = player;
            this.InitializeComponent();
        }

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
            }
        }

        #endregion
    }
}