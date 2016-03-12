﻿namespace SplendorWpfClient.ViewModels
{
    #region

    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Media;

    using SplendorCore.Models;

    using Color = SplendorCore.Models.Color;

    #endregion

    public class PlayerViewModel : AbstractViewModel
    {
        #region Fields

        private Player player;

        #endregion

        #region Constructors and Destructors

        public PlayerViewModel()
        {
            this.ReservedCards = new ObservableCollection<CardViewModel>();
        }

        #endregion

        #region Public Properties

        public bool IsActivePlayer { get; set; }

        public SolidColorBrush BorderColor
        {
            get { return this.IsActivePlayer ? new SolidColorBrush(Colors.Fuchsia) : new SolidColorBrush(Colors.Gray); }
        }

        public IEnumerable<ChipsViewModel> Cards { get { return this.IsPlayerPresent ? this.player.Cards.Select(card => new ChipsViewModel(card, Color.White)) : new List<ChipsViewModel>(); } }

        public IEnumerable<ChipsViewModel> Chips { get { return this.IsPlayerPresent ? this.player.Chips.Select(card => new ChipsViewModel(card, Color.White)) : new List<ChipsViewModel>(); } }

        public bool IsPlayerPresent { get { return this.player != null; } }

        public string Name { get { return this.IsPlayerPresent ? this.player.Name : string.Empty; } }

        public Player Player
        {
            set
            {
                this.player = value;
                if (this.player != null)
                {
                    foreach (var reservedCard in this.player.ReservedCards)
                    {
                        this.ReservedCards.Add(new CardViewModel() { Card = reservedCard });
                    }
                }

                this.OnPropertyChanged("IsPlayerPresent");
                this.OnPropertyChanged("Chips");
                this.OnPropertyChanged("Cards");
                this.OnPropertyChanged("ReservedCards");
            }
        }

        public ObservableCollection<CardViewModel> ReservedCards { get; set; }

        #endregion
    }
}