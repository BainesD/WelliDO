using WelliDO.Clients;
using WelliDO.Configs;
using System;
using System.Collections.Generic;
using WelliDO.APIResponses;
using Microsoft.AspNetCore.Mvc;

namespace WelliDO.Models

{
    public class PickerModel
    {

        private static GMapsClient _gMapsClient = new GMapsClient(new GMapsConfiguration());
        private static IPDataClient _ipDataClient = new IPDataClient(new IPDataConfiguration());

        public static float Lat = _ipDataClient.GetIPData().Result.latitude;
        public static float Lon = _ipDataClient.GetIPData().Result.longitude;

        [BindProperty]
        public static string Radius { get; set; } = "8046.72";
      
        
        public static NBResult[] Results { get; set; } = GetNearbyLocations("locally owned food");//need keyword input from forms
        public static List<string> placeIDs { get; set; } = GetListOfPlaceIDs();
        public static List<PlaceResult> Places { get; set; } = GetListOfPlaceDetails();


    public static List<string> GetListOfPlaceIDs()
        {
            List<string> placeIDs = new List<string>();
            foreach(var result in Results)
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
            var tenPM = new TimeSpan(22,0,0);
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
        public static string GetPhotoURL(string reference)
        {
            return _gMapsClient.CallPhotoAPI(reference);
        }

        public static IEnumerable<string> GetNearbyPlaceNames()
        {
            var response = _gMapsClient.GetNearbySearchAsync(Lat, Lon, Radius).Result;
            var results = response.results;
            List<string> resultNames = new List<string>();
            foreach (var result in results)
            {
                resultNames.Add(result.name);
            }
            return resultNames;
        }

        public static List<PlaceResult> GetListOfPlaceDetails()
        {
            List<PlaceResult> placeResults = new List<PlaceResult>();
            foreach (var placeID in placeIDs)
            {
               var response = _gMapsClient.GetPlaceDetailsAsync(placeID).Result;
                placeResults.Add(response.result);
            }
            return placeResults;
            
        }
        public static NBResult[] GetNearbyLocations(string keyword)
        {
            var response = _gMapsClient.GetNearbySearchWKeywordAsync(Lat, Lon, Radius, keyword).Result;
            return response.results;
        }
        public static double RadiusToMileParser(string radiusAsString)
        {
            var radiusTester = Double.TryParse(radiusAsString, out double radius);
            return Math.Round((radius * 0.000621),0);

        }
    }
}
