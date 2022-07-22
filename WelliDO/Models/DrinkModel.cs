using WelliDO.APIResponses;
using System.Collections.Generic;
using WelliDO.Clients;
using WelliDO.Configs;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public static string[] UserOptions = new string[] { "Brewery", "Wine Bar", "Night Club", "Cocktails", "Bowling", "Movie" };

        #endregion

        #region API Response Object Containers
        public NBResult[] Results { get; set; }
        public List<string> placeIDs { get; set; }
        public List<PlaceResult> Places { get; set; }
        #endregion

        public static void StoreUserInputs(DrinkModel model)
        {
            model.Radius = RadiusMilesToMeters(Convert.ToDouble(model.Radius));
            model.Results = GetNearbyLocations(model);
            model.placeIDs = GetListOfPlaceIDs(model);
            model.Places = GetListOfPlaceDetails(model);

        }
        public static string GetPhotoURL(string reference)
        {
            return _gMapsClient.CallPhotoAPI(reference);
        }
        public static List<string> GetListOfPlaceIDs(DrinkModel model)
        {
            List<string> placeIDs = new List<string>();
            foreach (var result in model.Results)
            {
                var placeID = result.place_id;
                placeIDs.Add(placeID);
            }
            return placeIDs;
        }
        public static IEnumerable<string> GetNearbyPlaceNames(DrinkModel model)
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
        public static List<PlaceResult> GetListOfPlaceDetails(DrinkModel model)
        {
            List<PlaceResult> placeResults = new List<PlaceResult>();
            foreach (var placeID in model.placeIDs)
            {
                var response = _gMapsClient.GetPlaceDetailsAsync(placeID).Result;
                placeResults.Add(response.result);
            }
            return placeResults;

        }
        public static NBResult[] GetNearbyLocations(DrinkModel model)
        {
            var response = _gMapsClient.GetNearbySearchWKeywordAsync(Lat, Lon, model.Radius, $"{model.Keywords}").Result;
            return response.results;
        }
        public static double RadiusToMileParser(string radiusAsString)
        {
            var radiusTester = Double.TryParse(radiusAsString, out double radius);
            return Math.Round((radius * 0.000621), 0);

        }
        public static string RadiusMilesToMeters(double radius)
        {
            return (radius * 1609.344).ToString();
        }
    }
}
