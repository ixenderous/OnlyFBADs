
using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Api.ModOptions;

namespace OnlyFBADs
{
    public class Settings : ModSettings
    {
        public static readonly ModSettingBool ModEnabled = new(true)
        {
            description = "While enabled, only FBADs will give pops in sandbox."
        };

        public static readonly ModSettingBool IncludeRegularBads = new(false)
        {
            description = "Regular BADs will also give pops."
        };
    }
}
