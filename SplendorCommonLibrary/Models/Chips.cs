namespace SplendorCommonLibrary.Models
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class Chips : Dictionary<Color, int>
    {
        #region Constructors and Destructors

        public Chips()
        {
            foreach (var color in Enum.GetValues(typeof(Color)).Cast<Color>())
            {
                this.Add(color, 0);
            }
        }

        public Chips(int white, int blue, int green, int red, int black, int gold)
        {
            this.Add(Color.White, white);
            this.Add(Color.Blue, blue);
            this.Add(Color.Green, green);
            this.Add(Color.Red, red);
            this.Add(Color.Black, black);
            this.Add(Color.Gold, gold);
        }

        #endregion

        #region Public Properties

        public int Black
        {
            get
            {
                return this[Color.Black];
            }

            set
            {
                this[Color.Black] = value;
            }
        }

        public int Blue
        {
            get
            {
                return this[Color.Blue];
            }

            set
            {
                this[Color.Blue] = value;
            }
        }

        public int Gold
        {
            get
            {
                return this[Color.Gold];
            }

            set
            {
                this[Color.Gold] = value;
            }
        }

        public int Green
        {
            get
            {
                return this[Color.Green];
            }

            set
            {
                this[Color.Green] = value;
            }
        }

        public int Red
        {
            get
            {
                return this[Color.Red];
            }

            set
            {
                this[Color.Red] = value;
            }
        }

        public int White
        {
            get
            {
                return this[Color.White];
            }

            set
            {
                this[Color.White] = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        public static Chips operator +(Chips chipsA, Chips chipsB)
        {
            var result = new Chips();
            foreach (var a in chipsA)
            {
                result[a.Key] += a.Value;
            }

            foreach (var b in chipsB)
            {
                result[b.Key] += b.Value;
            }

            return result;
        }

        public static Chips operator -(Chips chipsA, Chips chipsB)
        {
            var result = new Chips();
            foreach (var a in chipsA)
            {
                result[a.Key] += a.Value;
            }

            foreach (var b in chipsB)
            {
                result[b.Key] -= b.Value;
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().IsSubclassOf(this.GetType()) || obj.GetType() == this.GetType())
            {
                var chips = (Chips)obj;
                return this.All(color => color.Value == chips[color.Key]);
            }

            return false;
        }

        public override int GetHashCode()
        {
            var hash = 13;
            foreach (var color in this)
            {
                hash = (hash * 9) + color.Value;
            }

            return hash;
        }

        #endregion
    }
}