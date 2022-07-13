using WelliDO.Clients;
using WelliDO.Configs;
using System;
using System.Collections.Generic;

namespace WelliDO.Models

{
    public class PickerModel
    {

        private static GMapsClient _gMapsClient = new GMapsClient(new GMapsConfiguration());
        private static IPDataClient _ipDataClient = new IPDataClient(new IPDataConfiguration());

        public static float Lat = _ipDataClient.GetIPData().Result.latitude;
        public static float Lon = _ipDataClient.GetIPData().Result.longitude;
        //public string Location { get; set; }
        public static string Radius { get; set; } = "1609";
        //public string Name { get; set; }
        //public string Distance { get; set; }
        //public string Keyword { get; set; }

    
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

        
    }
}
