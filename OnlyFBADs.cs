using MelonLoader;
using BTD_Mod_Helper;
using Il2CppAssets.Scripts.Models;
using OnlyFBADs;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

[assembly: MelonInfo(typeof(OnlyFBADs.OnlyFBADs), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace OnlyFBADs;

public class OnlyFBADs : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<OnlyFBADs>("OnlyFBADs loaded!");
    }

    public override void OnNewGameModel(GameModel result)
    {
        base.OnNewGameModel(result);

        if (Settings.ModEnabled && InGameData.CurrentGame.IsSandbox && Settings.PatchNinjagon)
        {
            var ninjagon = result.GetParagonTower("NinjaMonkey");
            if (ninjagon == null)
            {
                ModHelper.Msg<OnlyFBADs>("Failed to find Ninjagon");
                return;
            }
            
            var model = ninjagon.GetDescendant<DamagePercentOfMaxModel>();
            if (model != null)
            {
                model.percent = 0;
                ModHelper.Msg<OnlyFBADs>("Patched ninjagon");
            }
            else
            {
                ModHelper.Msg<OnlyFBADs>("Failed to patch ninjagon");
            }
        }
    }

    public override void OnBloonEmitted(Spawner spawner, BloonModel bloonModel, int round, int index, float startingDist, ref Bloon bloon)
    {
        base.OnBloonEmitted(spawner, bloonModel, round, index, startingDist, ref bloon);

        if (!Settings.ModEnabled || !InGameData.CurrentGame.IsSandbox)
            return;

        bool isFBAD = bloonModel.name == "BadFortified";
        bool isBAD = bloonModel.name == "Bad";
        
        if (!isFBAD && !(Settings.IncludeRegularBads && isBAD))
        {
            bloon.lowestLayerNumber = 0;
        }
    }
}