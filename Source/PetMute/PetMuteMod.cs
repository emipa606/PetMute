using Mlie;
using UnityEngine;
using Verse;

namespace PetMute;

[StaticConstructorOnStartup]
internal class PetMuteMod : Mod
{
    private static string currentVersion;

    public static PetMuteMod Instance;

    /// <summary>
    ///     The private settings
    /// </summary>
    public readonly PetMuteSettings Settings;

    /// <summary>
    ///     Cunstructor
    /// </summary>
    /// <param name="content"></param>
    public PetMuteMod(ModContentPack content) : base(content)
    {
        Instance = this;
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
        Settings = GetSettings<PetMuteSettings>();
    }

    /// <summary>
    ///     The title for the mod-settings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "Pet Mute";
    }

    /// <summary>
    ///     The settings-window
    ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        listing_Standard.Gap();
        listing_Standard.CheckboxLabeled("PM.WildAnimals.Label".Translate(), ref Settings.WildAnimals,
            "PM.WildAnimals.Tooltip".Translate());
        listing_Standard.CheckboxLabeled("PM.TameAnimals.Label".Translate(), ref Settings.TameAnimals,
            "PM.TameAnimals.Tooltip".Translate());
        if (ModLister.BiotechInstalled)
        {
            listing_Standard.CheckboxLabeled("PM.ColonyMechanoids.Label".Translate(), ref Settings.ColonyMechanoids,
                "PM.ColonyMechanoids.Tooltip".Translate());
        }

        if (!Settings.TameAnimals && !Settings.WildAnimals && !Settings.ColonyMechanoids)
        {
            listing_Standard.Label("PM.DoNothing.Label".Translate());
        }

        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("PM.ModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }
}