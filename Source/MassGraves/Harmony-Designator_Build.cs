using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;
using UnityEngine;
using HarmonyLib;

namespace MassGraves
{
    [HarmonyPatch(typeof(Designator_Build))]
    [HarmonyPatch("Visible", MethodType.Getter)]
    public static class Harmony_Designator_Build
    {
        public static bool Prefix(Designator_Build __instance, ref bool __result)
        {
            if ((__instance.PlacingDef == GraveDefOf.MassGrave && Controller.settings.UseAlt)
                || (__instance.PlacingDef == GraveDefOf.MassGraveAlt && !Controller.settings.UseAlt))
            {
                __result = false;
                return false;
            }
            return true;
        }
    }
}
