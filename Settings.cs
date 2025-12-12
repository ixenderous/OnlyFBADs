
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

        public static readonly ModSettingBool PatchNinjagon = new(false)
        {
            description = "While enabled, disables Ninjagon's Grand Sabo passive in sandbox to stop it gaining pops from non (F)BADs. ModEnabled must also be true. Applies when joining a match."
        };
    }
}
