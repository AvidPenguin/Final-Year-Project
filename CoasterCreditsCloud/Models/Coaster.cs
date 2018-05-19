using System.ComponentModel;

namespace CoasterCreditsCloud.Models
{
    public class Coaster
    {
        public int CoasterID { get; set; }
        public string CoasterName { get; set; }
        public string CoasterManufacturer { get; set; }
        public EnumCoasterStatus CoasterStatus { get; set; }
        public EnumCoasterType CoasterType { get; set; }
        public EnumCoasterStyle CoasterStyle { get; set; }
        public float CoasterHeight { get; set; } // Stored in ft, 0 = unknown
        public float CoasterLength { get; set; } // Stored in ft, 0 = unknown
        public float CoasterSpeed { get; set; } // Stored in mph, 0 = unknown
        public int CoasterInversions { get; set; }
        public int CoasterParkID { get; set; }

        public enum EnumCoasterStatus
        {
            [Description("Open")]
            Open,
            [Description("Under Construction")]
            UnderConstruction,
            [Description("SBNO")]
            SBNO,
            [Description("Removed")]
            Removed,
            [Description("Relocated")]
            Relocated
        }
        public enum EnumCoasterType
        {
            [Description("Wooden")]
            Wooden,
            [Description("Steel")]
            Steel,
            [Description("Hybrid")]
            Hybrid
        }
        public enum EnumCoasterStyle
        {
            [Description("Sitdown")]
            Sitdown,
            [Description("Inverted")]
            Inverted,
            [Description("Standup")]
            Standup,
            [Description("Flying")]
            Flying,
            [Description("Wing")]
            Wing,
            [Description("Swinging")]
            Swinging,
            [Description("Bobsled")]
            Bobsled
        }
    }
}
