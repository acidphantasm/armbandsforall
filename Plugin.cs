using System;
using acidphantasm_armbandsforall.Patches;
using BepInEx;

namespace acidphantasm_armbandsforall
{
    [BepInPlugin("com.acidphantasm.armbandsforall", "acidphantasm-armbandsforall", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            if (!VersionChecker.CheckEftVersion(Logger, Info, Config))
            {
                throw new Exception($"Invalid EFT Version");
            }
            
            new ReplaceInventoryPatch().Enable();
            new IsAllowedToSeeEquipmentSlotPatch().Enable();
        }
    }
}
