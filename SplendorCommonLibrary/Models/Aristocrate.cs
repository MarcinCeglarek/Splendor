namespace SplendorCommonLibrary.Models
{
    #region

    using System.Runtime.Serialization;

    using SplendorCommonLibrary.Models.ChipsModels;

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