using System.Reflection;
using HarmonyLib;
using Verse;

namespace PetMute
{
    [StaticConstructorOnStartup]
    public static class PetMute
    {
        static PetMute()
        {
            var harmony = new Harmony("Mlie.PetMute");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}