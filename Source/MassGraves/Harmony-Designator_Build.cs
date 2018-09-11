using RimWorld;
using Verse;
using Harmony;
using System.Reflection;

namespace MassGraves
{
    [StaticConstructorOnStartup]
    public static class HarmonyLoader {
        static HarmonyLoader()
        {
            HarmonyInstance.Create("MassGraves.Harmony").PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(Designator_Build), "Visible", MethodType.Getter)]
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

    [HarmonyPatch(typeof(Building_Grave), "StorageTabVisible", MethodType.Getter)]
    public static class Harmony_Storage_Tab_Visible {
        public static bool Prefix(Building_Grave __instance, ref bool __result)
        {
            if (__instance is Building_MassGrave massGrave)
            {
                // This method is not virtual so we have to replace the root definition :(
                __result = massGrave.StorageTabVisible;
                return false;
            }
            return true;
        }
    }
}
