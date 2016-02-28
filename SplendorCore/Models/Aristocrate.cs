namespace SplendorCore.Models
{
    #region

    using System.Runtime.Serialization;

    #endregion

    [DataContract]
    public class Aristocrate
    {
        #region Public Properties

        [DataMember]
        public Chips RequiredCards { get; set; }

        [DataMember]
        public int VictoryPoints { get; set; }

        #endregion
    }
}