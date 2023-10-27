using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Objects;
using StardewValley.TerrainFeatures;

// ReSharper disable InconsistentNaming

namespace CropGrowthAdjustments.Patching
{
    internal class HarmonyPatches
    {
        /// <summary> Patch for the HoeDirt.dayUpdate method </summary>
        public static bool HoeDirtDayUpdate(HoeDirt __instance, GameLocation environment, Vector2 tileLocation)
        {
            try
            {
                return HarmonyPatchExecutors.HoeDirtDayUpdate(__instance, environment, tileLocation);
            }
            catch (Exception e)
            {
                ModEntry.ModMonitor.Log($"Failed in { nameof(HoeDirtDayUpdate) }:\n{ e }", LogLevel.Error);
                
                // run the original method if the patch fails
                return true;
            }
        }

        /// <summary> Patch for the IndoorPot.DayUpdate method </summary>
        public static bool IndoorPotDayUpdate(IndoorPot __instance, GameLocation location)
        {
            try
            {
                return HarmonyPatchExecutors.IndoorPotDayUpdate(__instance, location);
            }
            catch (Exception e)
            {
                ModEntry.ModMonitor.Log($"Failed in { nameof(IndoorPotDayUpdate) }:\n{ e }", LogLevel.Error);
                
                // run the original method if the patch fails
                return true;
            }
        }

        /// <summary> Patch for the Crop.newDay method. </summary>
        public static void CropNewDay(Crop __instance, int state, int fertilizer, int xTile, int yTile,
            GameLocation environment)
        {
            try
            {
                HarmonyPatchExecutors.CropNewDay(__instance, state, fertilizer, xTile, yTile, environment);
            }
            catch (Exception e)
            {
                ModEntry.ModMonitor.Log($"Failed in { nameof(CropNewDay) }:\n{ e }", LogLevel.Error);
            }
        }
    }
}