using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using RimWorld;
using Verse;
using UnityEngine;
using HarmonyLib;

namespace MassGraves
{
    public class Controller : Mod
    {
        public static Settings settings;

        public Controller(ModContentPack content) : base(content)
        {
            settings = GetSettings<Settings>();
            var harmony = new Harmony("MassGraves.Harmony");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
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
