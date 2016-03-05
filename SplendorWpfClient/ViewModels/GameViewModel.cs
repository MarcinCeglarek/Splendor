namespace SplendorWpfClient.ViewModels
{
    #region

    using SplendorCore.Models;

    #endregion

    internal class GameViewModel
    {
        #region Public Properties

        public bool CanGameBeStarted { get { return this.Game != null && !this.Game.HasStarted && this.Game.Players.Count >= 2; } }

        public bool CanPlayerBeAdded { get { return this.Game != null && this.Game.Players.Count < 4; } }

        public Game Game { get; set; }

        #endregion
    }
}