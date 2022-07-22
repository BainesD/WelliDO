using WelliDO.APIResponses;
using System.Collections.Generic;
using WelliDO.Clients;
using WelliDO.Configs;
using Microsoft.AspNetCore.Mvc;

namespace WelliDO.Models
{
    public class DrinkModel
    {
        #region API Client calls
        private static GMapsClient _gMapsClient = new GMapsClient(new GMapsConfiguration());
        private static IPDataClient _ipDataClient = new IPDataClient(new IPDataConfiguration());
        #endregion

        #region Model Environment
        public static float Lat = _ipDataClient.GetIPData().Result.latitude;
        public static float Lon = _ipDataClient.GetIPData().Result.longitude;
        public string Radius { get; set; } = "8069.9";
        public string Keywords { get; set; }
        public string[] UserOptions = new string[] {"Brewery", "Wine Bar", "Night Club", "Cocktails", "Bowling", "Movie"  };
        #endregion

        public static void StoreUserInputs(DrinkModel model)
        {

        }
        public static string GetPhotoURL(string reference)
        {
            return _gMapsClient.CallPhotoAPI(reference);
        }
        public static List<string> GetListOfPlaceIDs(FoodModel model)
        {
            List<string> placeIDs = new List<string>();
            foreach (var result in model.Results)
            {
                var placeID = result.place_id;
                placeIDs.Add(placeID);
            }
            return placeIDs;
        }
        public static IEnumerable<string> GetNearbyPlaceNames(FoodModel model)
        {
            var response = _gMapsClient.GetNearbySearchAsync(Lat, Lon, model.Radius).Result;
            var results = response.results;
            List<string> resultNames = new List<string>();
            foreach (var result in results)
            {
                resultNames.Add(result.name);
            }
            return resultNames;
        }
        public static List<PlaceResult> GetListOfPlaceDetails(FoodModel model)
        {
            List<PlaceResult> placeResults = new List<PlaceResult>();
            foreach (var placeID in model.placeIDs)
            {
                var response = _gMapsClient.GetPlaceDetailsAsync(placeID).Result;
                placeResults.Add(response.result);
            }
            return placeResults;

        }
        public static NBResult[] GetNearbyLocations(FoodModel model)
        {
            var response = _gMapsClient.GetNearbySearchWKeywordAsync(Lat, Lon, model.Radius, $"Local Drinks {model.Keywords}").Result;
            return response.results;
        }
    }
}
