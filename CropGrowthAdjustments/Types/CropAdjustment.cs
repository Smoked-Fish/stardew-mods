using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using StardewModdingAPI;
using StardewValley;

namespace CropGrowthAdjustments.Types
{
    public class CropAdjustment
    {
        public string CropProduceName { get; set; }
        public string CropProduceItemId { get; set; } = "-1";
        public string SeasonsToGrowIn { get; set; }
        public string SeasonsToProduceIn { get; set; }
        public string LocationsWithDefaultSeasonBehavior { get; set; }
        public List<SpecialSprites> SpecialSpritesForSeasons { get; set; } = null;
        
        [JsonIgnore]
        public int RowInCropSpriteSheet { get; set; }
        [JsonIgnore]
        public string InitialTexture { get; set; }
        
        public List<Season> GetSeasonsToGrowIn()
        {
            return ParseSeasons(SeasonsToGrowIn);
        }
        
        public List<Season> GetSeasonsToProduceIn()
        {
            return ParseSeasons(SeasonsToProduceIn);
        }

        private List<Season> ParseSeasons(string seasonsString)
        {
            var split = seasonsString.Split(',');
            var result = new List<Season>();
            foreach (var seasonString in split)
            {
                switch (seasonString.Trim().ToLower())
                {
                    case "spring": 
                        result.Add(Season.Spring);
                        break;
                    case "summer": 
                        result.Add(Season.Summer);
                        break;
                    case "fall": 
                        result.Add(Season.Fall);
                        break;
                    case "winter": 
                        result.Add(Season.Winter);
                        break;
                    default:
                        ModEntry.ModMonitor.Log($"Unknown season in Crop Adjustment: {seasonString}", LogLevel.Warn);
                        break;
                }
            }
            
            return result;
        }
        
        public List<string> GetLocationsWithDefaultSeasonBehavior()
        {
            if (LocationsWithDefaultSeasonBehavior != null)
                return LocationsWithDefaultSeasonBehavior.Split(',').ToList().Select(e => e.Trim()).ToList();

            return new List<string>();
        }
    }
}