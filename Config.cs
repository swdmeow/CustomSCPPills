namespace CustomSCPPills
{
    using Exiled.API.Interfaces;
    using System.Collections.Generic;
    using System.ComponentModel;

    public sealed class Config : IConfig
    {
        [Description("Plugin enabled or not")]
        public bool IsEnabled { get; set; } = true;

        [Description("Debug enabled or not")]
        public bool Debug { get; set; } = false;
        [Description("Minimal number to spawn pills")]
        public int MinNumber { get; set; } = 8;
        [Description("Maximum number to spawn pills")]
        public int MaxNumber { get; set; } = 12;

    }
}