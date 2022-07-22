using WelliDO.Clients;
using WelliDO.Configs;
using System;
using System.Collections.Generic;
using WelliDO.APIResponses;
using Microsoft.AspNetCore.Mvc;

namespace WelliDO.Models
{
    public class FoodModel

    {
        public FoodModel()
        {

        }
        #region API Client calls
        private static GMapsClient _gMapsClient = new GMapsClient(new GMapsConfiguration());
        private static IPDataClient _ipDataClient = new IPDataClient(new IPDataConfiguration());
        #endregion

        #region Model Environment
        public static float Lat = _ipDataClient.GetIPData().Result.latitude;
        public static float Lon = _ipDataClient.GetIPData().Result.longitude;
        public string Radius { get; set; } = "8069.9";
        public string Keywords { get; set; }

        //public enum RandomKeyword {Burgers, Tacos, Donuts, Sushi, Pizza }
        #endregion

        #region API Response Object Containers
        public NBResult[] Results { get; set; } 
        public List<string> placeIDs { get; set; } 
        public List<PlaceResult> Places { get; set; }
        #endregion

        public static void StoreUserInputs(FoodModel model)
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
        public static string GetMealName()
        {
            #region Specific Time of Day vars
            var currentDate = DateTime.Now;
            var fullDay = new TimeSpan(24, 0, 0);
            var threeAM = new TimeSpan(3, 0, 0);
            var sixAM = new TimeSpan(6, 0, 0);
            var nineAM = new TimeSpan(9, 0, 0);
            var threePM = new TimeSpan(15, 0, 0);
            var tenPM = new TimeSpan(22, 0, 0);
            #endregion

            #region IF Statements
            if ((currentDate.DayOfWeek == DayOfWeek.Sunday || currentDate.DayOfWeek == DayOfWeek.Saturday) && currentDate.TimeOfDay >= sixAM && currentDate.TimeOfDay < threePM)
                return "for Brunch";
            if (currentDate.TimeOfDay >= threeAM && currentDate.TimeOfDay < nineAM)
                return "for Breakfast";
            if (currentDate.TimeOfDay >= nineAM && currentDate.TimeOfDay < threePM)
                return "for Lunch";
            if (currentDate.TimeOfDay >= threePM && currentDate.TimeOfDay < tenPM)
                return "for Dinner";
            if (currentDate.TimeOfDay >= tenPM && currentDate.TimeOfDay < threeAM.Add(fullDay))
                return "your Late Night Craving";
            return "To Eat";
            #endregion

        }
        public static IEnumerable<string> GetNearbyPlaceNames(FoodModel model)
        {
            var response = _gMapsClient.GetNearbySearchAsync(Lat, Lon, model.Radius, model.Keywords).Result;
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
            var response = _gMapsClient.GetNearbySearchWKeywordAsync(Lat, Lon, model.Radius, $"Local Food {model.Keywords}").Result;
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
