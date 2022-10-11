using HarmonyLib;
using Verse;

namespace PetMute;

[HarmonyPatch(typeof(LifeStageUtility), "GetNearestLifestageSound")]
public static class LifeStageUtility_GetNearestLifestageSound
{
    public static bool Prefix(ref Pawn pawn)
    {
        if (pawn == null)
        {
            return true;
        }

        if (pawn.RaceProps?.Animal == false)
        {
            return true;
        }

        switch (pawn.Faction?.IsPlayer == true)
        {
            case true when !LoadedModManager.GetMod<PetMuteMod>().GetSettings<PetMuteSettings>().TameAnimals:
            case false when !LoadedModManager.GetMod<PetMuteMod>().GetSettings<PetMuteSettings>().WildAnimals:
                return true;
            default:
                return false;
        }
    }
}