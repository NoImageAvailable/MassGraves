using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;
using UnityEngine;

namespace MassGraves
{
    public class Settings : ModSettings
    {
        private int corpseCapacity = 20;
        private bool useAlt = false;

        public int CorpseCapacity => corpseCapacity;
        public bool UseAlt => useAlt;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref corpseCapacity, "corpseCapacity", 20);
            Scribe_Values.Look(ref useAlt, "useAlt", false);
        }

        public void DoWindowContents(Rect canvas)
        {
            Listing_Standard list = new Listing_Standard();
            list.ColumnWidth = canvas.width / 3;
            list.Begin(canvas);
            Text.Font = GameFont.Medium;
            list.Label("MassGrave_Capacity".Translate());
            Text.Font = GameFont.Small;
            string str = corpseCapacity.ToString();
            list.TextFieldNumeric(ref corpseCapacity, ref str, 1);
            list.Gap();
            list.CheckboxLabeled("MassGrave_UseAlt".Translate(), ref useAlt);
            list.End();
        }
    }
}
