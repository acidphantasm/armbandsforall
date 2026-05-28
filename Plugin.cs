using System;
using ArmbandsForAll.Patches;
using BepInEx;

namespace ArmbandsForAll
{
    [BepInPlugin("com.acidphantasm.armbandsforall", "acidphantasm-armbandsforall", "1.0.1")]
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
