namespace SplendorCommonLibrary.Models.ChipsModels
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SplendorCommonLibrary.Data;

    #endregion

    public class Chips : List<Chip>
    {
        #region Public Properties

        public int Black
        {
            get
            {
                return this.Single(o => o.Color == Color.Black).Value;
            }

            set
            {
                if (this.Any(o => o.Color == Color.Black))
                {
                    this.Single(o => o.Color == Color.Black).Value = value;
                }
                else
                {
                    this.Add(new BlackChip(value));
                }
            }
        }

        public int Blue
        {
            get
            {
                return this.Single(o => o.Color == Color.Blue).Value;
            }

            set
            {
                if (this.Any(o => o.Color == Color.Blue))
                {
                    this.Single(o => o.Color == Color.Blue).Value = value;
                }
                else
                {
                    this.Add(new BlueChip(value));
                }
            }
        }

        public int Gold
        {
            get
            {
                return this.Single(o => o.Color == Color.Gold).Value;
            }

            set
            {
                if (this.Any(o => o.Color == Color.Gold))
                {
                    this.Single(o => o.Color == Color.Gold).Value = value;
                }
                else
                {
                    this.Add(new GoldChip(value));
                }
            }
        }

        public int Green
        {
            get
            {
                return this.Single(o => o.Color == Color.Green).Value;
            }

            set
            {
                if (this.Any(o => o.Color == Color.Green))
                {
                    this.Single(o => o.Color == Color.Green).Value = value;
                }
                else
                {
                    this.Add(new GreenChip(value));
                }
            }
        }

        public int Red
        {
            get
            {
                return this.Single(o => o.Color == Color.Red).Value;
            }

            set
            {
                if (this.Any(o => o.Color == Color.Red))
                {
                    this.Single(o => o.Color == Color.Red).Value = value;
                }
                else
                {
                    this.Add(new RedChip(value));
                }
            }
        }

        public int White
        {
            get
            {
                return this.Single(o => o.Color == Color.White).Value;
            }

            set
            {
                if (this.Any(o => o.Color == Color.White))
                {
                    this.Single(o => o.Color == Color.White).Value = value;
                }
                else
                {
                    this.Add(new WhiteChip(value));
                }
            }
        }

        #endregion

        #region Public Methods and Operators

        public static Chips operator +(Chips chipsA, Chips chipsB)
        {
            var result = new Chips();
            foreach (var a in chipsA)
            {
                var c = (Chip)Activator.CreateInstance(typeof(Chip).Assembly.FullName, Constants.ChipClassPath + a.GetType().Name).Unwrap();
                c.Value = a.Value;
                result.Add(c);
            }

            foreach (var b in chipsB)
            {
                if (result.Any(c => c.Color == b.Color))
                {
                    result.Single(c => c.Color == b.Color).Value += b.Value;
                }
                else
                {
                    var c = (Chip)Activator.CreateInstance(typeof(Chip).Assembly.FullName, Constants.ChipClassPath + b.GetType().Name).Unwrap();
                    c.Value = b.Value;
                    result.Add(c);
                }
            }

            return result;
        }

        public static Chips operator -(Chips chipsA, Chips chipsB)
        {
            var negativeB = new Chips();
            foreach (var b in chipsB)
            {
                var c = (Chip)Activator.CreateInstance(typeof(Chip).Assembly.FullName, Constants.ChipClassPath + b.GetType().Name).Unwrap();
                c.Value = -b.Value;
                negativeB.Add(c);
            }

            return chipsA + negativeB;
        }

        #endregion
    }
}