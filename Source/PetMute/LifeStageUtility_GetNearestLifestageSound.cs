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

        if (pawn.IsColonyMech && PetMuteMod.Instance.Settings.ColonyMechanoids)
        {
            return false;
        }

        if (pawn.RaceProps?.Animal == false)
        {
            return true;
        }

        if (pawn.Faction?.IsPlayer == true && !PetMuteMod.Instance.Settings.TameAnimals)
        {
            return true;
        }

        return pawn.Faction?.IsPlayer != true && !PetMuteMod.Instance.Settings.WildAnimals;
    }
}