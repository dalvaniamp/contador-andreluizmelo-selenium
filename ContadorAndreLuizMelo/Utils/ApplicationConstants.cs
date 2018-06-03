using System.ComponentModel;

namespace ContadorAndreLuizMelo.Utils
{
    public sealed class ApplicationConstants
    {
        public enum WebDrivers
        {
            Vazio = -1,

            [Description("Mozilla Firefox")]
            Firefox,

            [Description("Google Chrome")]
            Chrome,

            [Description("Internet Explorer")]
            Internet_Explorer
        };
    }
}
