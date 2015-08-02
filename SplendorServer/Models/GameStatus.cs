namespace SplendorServer.Models
{
    using System;
    using System.Collections.Generic;

    public class GameStatus
    {
        public GameStatus(Deck deck, IList<User> users)
        {
            this.Deck = deck;
            this.Users = users;

            var chipCount = 7;
            switch (users.Count)
            {
                case 2:
                    chipCount = 4;
                    break;
                case 3:
                    chipCount = 5;
                    break;
                case 4:
                    break;
                default:
                    throw new ArgumentException("User count is invalid (shoudl be from 2-4) " + users.Count);
            }

            this.Bank = new Chips() { White = chipCount, Blue = chipCount, Green = chipCount, Red = chipCount, Black = chipCount, Gold = 5 };
        }

        public IList<User> Users { get; set; }

        public Deck Deck { get; set; }

        public Chips Bank { get; set; }
    }
}