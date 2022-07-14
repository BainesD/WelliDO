namespace WelliDO.APIResponses
{

    public class GMapsNearbySearchResponse
    {
        public object[] html_attributions { get; set; }
        public NBResult[] results { get; set; }
        public string status { get; set; }
    }

    public class NBResult
    {
        public string business_status { get; set; }
        public NBGeometry geometry { get; set; }
        public string icon { get; set; }
        public string icon_background_color { get; set; }
        public string icon_mask_base_uri { get; set; }
        public string name { get; set; }
        public NBOpening_Hours opening_hours { get; set; }
        public NBPhoto[] photos { get; set; }
        public string place_id { get; set; }
        public NBPlus_Code plus_code { get; set; }
        public int price_level { get; set; }
        public float rating { get; set; }
        public string reference { get; set; }
        public string scope { get; set; }
        public string[] types { get; set; }
        public int user_ratings_total { get; set; }
        public string vicinity { get; set; }
    }

    public class NBGeometry
    {
        public NBLocation location { get; set; }
        public NBViewport viewport { get; set; }
    }

    public class NBLocation
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class NBViewport
    {
        public NBNortheast northeast { get; set; }
        public NBSouthwest southwest { get; set; }
    }

    public class NBNortheast
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class NBSouthwest
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class NBOpening_Hours
    {
        public bool open_now { get; set; }
    }

    public class NBPlus_Code
    {
        public string compound_code { get; set; }
        public string global_code { get; set; }
    }

    public class NBPhoto
    {
        public int height { get; set; }
        public string[] html_attributions { get; set; }
        public string photo_reference { get; set; }
        public int width { get; set; }
    }


}

