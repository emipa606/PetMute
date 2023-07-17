using System.Reflection;
using HarmonyLib;
using Verse;

namespace PetMute;

[StaticConstructorOnStartup]
public static class PetMute
{
    static PetMute()
    {
        new Harmony("Mlie.PetMute").PatchAll(Assembly.GetExecutingAssembly());
    }
}