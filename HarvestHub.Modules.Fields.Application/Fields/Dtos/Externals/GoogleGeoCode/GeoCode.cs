﻿namespace HarvestHub.Modules.Fields.Application.Fields.Dtos.Externals.GoogleGeoCode
{
    public class PlusCode
    {
        public string Compound_code { get; set; }
        public string Global_code { get; set; }
    }

    public class AddressComponent
    {
        public string Long_name { get; set; }
        public string Short_name { get; set; }
        public List<string> Types { get; set; }
    }

    public class Northeast
    {
        public double Lat { get; set; }
        public double lng { get; set; }
    }

    public class Southwest
    {
        public double Lat { get; set; }
        public double lng { get; set; }
    }

    public class Bounds
    {
        public Northeast Northeast { get; set; }
        public Southwest Southwest { get; set; }
    }

    public class Location
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class Geometry
    {
        public Bounds Bounds { get; set; }
        public Location Location { get; set; }
        public string Location_type { get; set; }
    }

    public class Result
    {
        public List<AddressComponent> Address_components { get; set; }
        public string Formatted_address { get; set; }
        public Geometry Geometry { get; set; }
        public string Place_id { get; set; }
        public PlusCode Plus_code { get; set; }
        public List<string> Types { get; set; }
    }

    public class GeoCode
    {
        public PlusCode Plus_code { get; set; }
        public List<Result> Results { get; set; }
        public string Status { get; set; }
    }
}
