using UnityEngine;
using Verse;

namespace PetMute
{
    [StaticConstructorOnStartup]
    internal class PetMuteMod : Mod
    {
        /// <summary>
        ///     The private settings
        /// </summary>
        private PetMuteSettings settings;

        /// <summary>
        ///     Cunstructor
        /// </summary>
        /// <param name="content"></param>
        public PetMuteMod(ModContentPack content) : base(content)
        {
        }

        /// <summary>
        ///     The instance-settings for the mod
        /// </summary>
        private PetMuteSettings Settings
        {
            get
            {
                if (settings == null)
                {
                    settings = GetSettings<PetMuteSettings>();
                }

                return settings;
            }
            set => settings = value;
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
            if (!Settings.TameAnimals && !Settings.WildAnimals)
            {
                listing_Standard.Label("PM.DoNothing.Label".Translate());
            }

            listing_Standard.End();
            Settings.Write();
        }
    }
}