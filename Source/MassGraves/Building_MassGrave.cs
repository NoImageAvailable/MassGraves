using System;
using System.Collections.Generic;
using System.Text;
using RimWorld;
using Verse;

namespace MassGraves
{
    public class Building_MassGrave : Building_Grave
    {
        public int CorpseCount => innerContainer.Count;

        public bool CanAcceptCorpses => CorpseCount < Controller.settings.CorpseCapacity;

        // Overwrite this so we can have multiple pawns putting corpses in graves
        public new int MaxAssignedPawnsCount
        {
            get
            {
                return Math.Max(1, Controller.settings.CorpseCapacity - CorpseCount);
            }
        }

        // Need to overwrite this to allow for changing settings after placing the first corpse
        public new bool StorageTabVisible
        {
            get
            {
                return this.CanAcceptCorpses;
            }
        }

        public override bool Accepts(Thing thing)
        {
            // CanAcceptAnyOf is from Building_Casket.cs which is too far up the inheritance tree to call directly
            return this.innerContainer.CanAcceptAnyOf(thing, true) && this.GetStoreSettings().AllowedToAccept(thing) && CanAcceptCorpses;
        }

        public override string GetInspectString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(InspectStringPartsFromComps());
            stringBuilder.Append("MassGrave_Capacity".Translate() + ": " + CorpseCount.ToString() + "/" + Controller.settings.CorpseCapacity.ToString());
            return stringBuilder.ToString();
        }

        public override IEnumerable<Gizmo> GetGizmos()
        {
            var gizmos = base.GetGizmos();
            // StorageTabVisible is not virtual, so check if we need to still apply it
            if (!base.StorageTabVisible && this.StorageTabVisible)
            {
                foreach (Gizmo g2 in StorageSettingsClipboard.CopyPasteGizmosFor(this.GetStoreSettings()))
                {
                    yield return g2;
                }
            }

            /*
             * Kind of a hack, because we don't want the assign owner gizmo that simply using base.GetGizmos() would give us. Instead iterate through all the gizmos
             * produced by base classes of Building_Grave and only return them if they're not labeled 'Assign colonist'.
             */
            foreach (Gizmo giz in gizmos)
            {
                if ((giz as Command_Action)?.defaultLabel != "CommandGraveAssignColonistLabel".Translate())
                {
                    yield return giz;
                }
            }
        }
    }
}
