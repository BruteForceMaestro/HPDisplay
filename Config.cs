using Exiled.API.Interfaces;
using System.ComponentModel;

namespace HPDisplay
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("Whether to display the Artificial HP (Armor). Ex.: SCP-173's AHP")]
        public bool DisplayAHP { get; set; } = true;
    }
}
