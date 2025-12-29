using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using SPT.Reflection.Patching;
using System.Reflection;
using System.Reflection.Emit;
using EFT.InventoryLogic;

namespace acidphantasm_armbandsforall.Patches
{
    internal class ReplaceInventoryPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(InventoryController), nameof(InventoryController.ReplaceInventory));
        }

        [PatchTranspiler]
        protected static IEnumerable<CodeInstruction> PatchTranspiler(IEnumerable<CodeInstruction> originalInstructions)
        {
            var instructions = new List<CodeInstruction>(originalInstructions);

            for (int i = 0; i < instructions.Count; i++)
            {
                var instr = instructions[i];

                if (instr.opcode == OpCodes.Bne_Un_S && instructions[i - 1].opcode == OpCodes.Ldc_I4_4)
                {
                    instructions[i] = new CodeInstruction(OpCodes.Br_S, instr.operand);
                }
            }

            return instructions.AsEnumerable();
        }
    }
    
    internal class IsAllowedToSeeEquipmentSlotPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(InventoryController), nameof(InventoryController.IsAllowedToSeeEquipmentSlot));
        }

        [PatchPrefix]
        protected static bool PatchPrefix(InventoryController __instance, Slot slot, EquipmentSlot slotName, ref bool __result)
        {
            if (slotName == EquipmentSlot.ArmBand)
            {
                __result = true;
                return false;
            }

            return true;
        }
    }
}
