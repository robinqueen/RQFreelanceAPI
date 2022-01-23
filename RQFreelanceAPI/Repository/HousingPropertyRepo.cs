

using Dapper;
using RQFreelanceAPI.Models;
using RQFreelanceAPI.Repository.Interfaces;

namespace RQFreelanceAPI.Repository
{
    public class HousingPropertyRepo : IHousingPropertyRepo
    {
        private readonly DapperContext _context;
        public HousingPropertyRepo(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<HousingProperty>> GetHousingProperties()
        {
            try
            {
                var query = @"  select 
                            HousingProperty.ID, PropertyType.Type asPropertyType,
                            HousingProperty.Price, HousingProperty.AddressLine1,
                            HousingProperty.AddressLine2, HousingProperty.City, HousingProperty.State,
                            HousingProperty.Zipcode, HousingProperty.LeaseLength, LeaseType.Type as LeaseType,
                            HouseImages.HouseID, ImageLocationType, ImageFile, ImageFilePath
                            FROM APIDB.dbo.HousingProperty HousingProperty
                            LEFT JOIN APIDB.dbo.HouseImages HouseImages
                            ON HousingProperty.ID = HouseImages.HouseID
                            LEFT JOIN APIDB.dbo.PropertyType PropertyType
                            ON HousingProperty.PropertyTypeID = PropertyType.ID
                            LEFT JOIN APIDB.dbo.LeaseType LeaseType
                            ON HousingProperty.LeaseTypeID = LeaseType.ID
							LEFT JOIN APIDB.dbo.ImageLocationType ImageLocationType
                            ON HouseImages.ImageLocationTypeID = ImageLocationType.ID";

                Dictionary<int, HousingProperty> HousingPropertyDictionary = new Dictionary<int, HousingProperty>();


                using (var connection = _context.CreateConnection())
                {
                    await connection.QueryAsync<HousingProperty, HouseImages, HousingProperty>(query,
                                        (housingProperty, housingImage) =>
                                        {
                                            HousingProperty _housingProperty = new HousingProperty();

                                            if (!HousingPropertyDictionary.TryGetValue(housingProperty.ID, out _housingProperty))
                                            {
                                                HousingPropertyDictionary.Add(housingProperty.ID, _housingProperty = housingProperty);
                                            }

                                            if (_housingProperty.HouseImages == null)
                                            {
                                                _housingProperty.HouseImages = new List<HouseImages>();
                                            }
                                            _housingProperty.HouseImages.Add(housingImage);
                                            return _housingProperty;
                                        }
                                            , splitOn: "HouseID");

                    return HousingPropertyDictionary.Values.ToList();
                }
                
            }
            catch (Exception ex)
            {
                return new List<HousingProperty>();
            }



            

        }


        public async Task InsertImages(HouseImages houseImage)
        {
            try
            {
                var query = @"INSERT INTO APIDB.dbo.HouseImages (HouseID, ImageLocationTypeID, ImageFile,ImageFilePath) VALUES (@HouseID, @ImageLocationTypeID, @ImageFile, @ImageFilePath)";
                using (var connection = _context.CreateConnection())
                {
                    connection.Execute(query, new { houseImage.HouseID, houseImage.ImageLocationTypeID, houseImage.ImageFile, houseImage.ImageFilePath });
                }
            } catch (Exception ex)
            {

            }
            
        }
    }
}
