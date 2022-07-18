namespace WelliDO.APIResponses
{



    public class GMapsPlaceDetailsResponse
    {
        public object[] html_attributions { get; set; }
        public PlaceResult result { get; set; }
        public string status { get; set; }
    }

    public class PlaceResult
    {
        public PlaceAddress_Components[] address_components { get; set; }
        public string adr_address { get; set; }
        public string business_status { get; set; }
        public string formatted_address { get; set; }
        public string formatted_phone_number { get; set; }
        public PlaceGeometry geometry { get; set; }
        public string icon { get; set; }
        public string icon_background_color { get; set; }
        public string icon_mask_base_uri { get; set; }
        public string international_phone_number { get; set; }
        public string name { get; set; }
        public PlaceOpening_Hours opening_hours { get; set; }
        public PlacePhoto[] photos { get; set; }
        public string place_id { get; set; }
        public PlacePlus_Code plus_code { get; set; }
        public int rating { get; set; }
        public string reference { get; set; }
        public PlaceReview[] reviews { get; set; }
        public string[] types { get; set; }
        public string url { get; set; }
        public int user_ratings_total { get; set; }
        public int utc_offset { get; set; }
        public string vicinity { get; set; }
        public string website { get; set; }
    }

    public class PlaceGeometry
    {
        public PlaceLocation location { get; set; }
        public PlaceViewport viewport { get; set; }
    }

    public class PlaceLocation
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class PlaceViewport
    {
        public PlaceNortheast northeast { get; set; }
        public PlaceSouthwest southwest { get; set; }
    }

    public class PlaceNortheast
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class PlaceSouthwest
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class PlaceOpening_Hours
    {
        public bool open_now { get; set; }
        public PlacePeriod[] periods { get; set; }
        public string[] weekday_text { get; set; }
    }

    public class PlacePeriod
    {
        public PlaceClose close { get; set; }
        public PlaceOpen open { get; set; }
    }

    public class PlaceClose
    {
        public int day { get; set; }
        public string time { get; set; }
    }

    public class PlaceOpen
    {
        public int day { get; set; }
        public string time { get; set; }
    }

    public class PlacePlus_Code
    {
        public string compound_code { get; set; }
        public string global_code { get; set; }
    }

    public class PlaceAddress_Components
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public string[] types { get; set; }
    }

    public class PlacePhoto
    {
        public int height { get; set; }
        public string[] html_attributions { get; set; }
        public string photo_reference { get; set; }
        public int width { get; set; }
    }

    public class PlaceReview
    {
        public string author_name { get; set; }
        public string author_url { get; set; }
        public string language { get; set; }
        public string profile_photo_url { get; set; }
        public int rating { get; set; }
        public string relative_time_description { get; set; }
        public string text { get; set; }
        public int time { get; set; }
    }

}
