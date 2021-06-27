using Verse;

namespace PetMute
{
    /// <summary>
    ///     Definition of the settings for the mod
    /// </summary>
    internal class PetMuteSettings : ModSettings
    {
        public bool TameAnimals = true;
        public bool WildAnimals = true;

        /// <summary>
        ///     Saving and loading the values
        /// </summary>
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref WildAnimals, "WildAnimals", true);
            Scribe_Values.Look(ref TameAnimals, "TameAnimals", true);
        }
    }
}