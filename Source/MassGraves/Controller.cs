using RimWorld;
using Verse;
using UnityEngine;

namespace MassGraves
{
    public class Controller : Mod
    {
        public static Settings settings;

        public Controller(ModContentPack content) : base(content)
        {
            settings = GetSettings<Settings>();
        }

        public override string SettingsCategory()
        {
            return "MassGrave_Settings".Translate();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            settings.DoWindowContents(inRect);
        }
    }
}
