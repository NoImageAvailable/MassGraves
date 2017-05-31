using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;
using UnityEngine;

namespace MassGraves
{
    public class Building_MassGrave : Building_Grave
    {
        private int CorpseCount => innerContainer.Count;

        private bool CanAcceptCorpses => CorpseCount < Controller.settings.CorpseCapacity;

        public override bool Accepts(Thing thing)
        {
            return innerContainer.CanAcceptAnyOf(thing) && CanAcceptCorpses && GetStoreSettings().AllowedToAccept(thing);
        }

        public override string GetInspectString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(InspectStringPartsFromComps());
            stringBuilder.Append("MassGrave_Capacity".Translate() + ": " + CorpseCount.ToString() + "/" + Controller.settings.CorpseCapacity.ToString());
            return stringBuilder.ToString();
        }

        /* Kind of a hack, because we don't want the assign owner gizmo that simply using base.GetGizmos() would give us. Instead iterate through all the gizmos
         * produced by base classes of Building_Grave and only return them if they're not labeled 'Assign colonist'.
         */
        public override IEnumerable<Gizmo> GetGizmos()
        {
            var gizmos = base.GetGizmos();
            foreach(Gizmo giz in gizmos)
            {
                if((giz as Command_Action)?.defaultLabel!= "CommandGraveAssignColonistLabel".Translate())
                {
                    yield return giz;
                }
            }
        }
    }
}
