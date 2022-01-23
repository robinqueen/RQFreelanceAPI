using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace RQFreelanceAPI.Models
{
    public class HousingProperty
    {
       
            public int ID { get; set; }
            public int Price { get; set; }
            public string PropertyTypeID { get; set; }
            public string PropertyType { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zipcode { get; set; }
            public int LeaseLength { get; set; }
            public string LeaseType { get; set; }
            public List<HouseImages> HouseImages { get; set; } = new List<HouseImages>();

    }

    public class HouseImages
    {
        public int HouseID { get; set; }

        public ImageLocationType Type { get; set; }
        public int ImageLocationTypeID { get; set; }
        public string ImageFile { get; set; }

        public string ImageFilePath { get; set; }

        public enum ImageLocationType
        {
            Main =1,
            Yard =2,
            Porch =3,
            Deck =4,
            Livingroom =5,
            Bedroom =6,
            Office =7,
            Kitchen =8,
            Utility = 9,
            MasterBedroom =10,
            Bathroom = 11,
            MasterBathroom =12,
            Other =13

        }
    }
}
