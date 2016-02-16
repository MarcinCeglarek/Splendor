namespace SplendorFormsClient.Panels
{
    #region

    using System.Drawing;
    using System.Windows.Forms;

    using SplendorCore.Models;

    using Color = System.Drawing.Color;

    #endregion

    public partial class PlayerPanel : UserControl
    {
        #region Fields

        public Player CurrentPlayer { get; set; }

        #endregion

        #region Constructors and Destructors

        public PlayerPanel(Player currentPlayer)
        {
            this.CurrentPlayer = currentPlayer;
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        private void PlayerPanel_Paint(object sender, PaintEventArgs e)
        {
            if (this.player == this.CurrentPlayer)
            {
                this.panel1.BackColor = Color.FromArgb(255, 192, 192);
            }
            else
            {
                this.panel1.BackColor = SystemColors.Control;
            }

            if (this.player != null)
            {
                this.CardsWhite.Text = this.player.Cards.White.ToString();
                this.CardsBlue.Text = this.player.Cards.Blue.ToString();
                this.CardsBlack.Text = this.player.Cards.Black.ToString();
                this.CardsGreen.Text = this.player.Cards.Green.ToString();
                this.CardsRed.Text = this.player.Cards.Red.ToString();

                this.ChipsWhite.Text = this.player.Chips.White.ToString();
                this.ChipsBlue.Text = this.player.Chips.Blue.ToString();
                this.ChipsBlack.Text = this.player.Chips.Black.ToString();
                this.ChipsGreen.Text = this.player.Chips.Green.ToString();
                this.ChipsRed.Text = this.player.Chips.Red.ToString();
            }
        }

        #endregion
    }
}