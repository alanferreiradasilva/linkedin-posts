using NetCore.CachingDemo.Api.Models.Continents;

namespace NetCore.CachingDemo.Api.Seed
{
    public static class ContinentSeed
    {
        public static List<ContinentResponseModel> GetAllContinents()
        {
            return new List<ContinentResponseModel>()
            {
                new ContinentResponseModel { Id = 1, Name = "Africa", NumberOfCountries = 54 },
                new ContinentResponseModel { Id = 2, Name = "Antarctica", NumberOfCountries = 0 },
                new ContinentResponseModel { Id = 3, Name = "Asia", NumberOfCountries = 48 },
                new ContinentResponseModel { Id = 4, Name = "Europe", NumberOfCountries = 44 },
                new ContinentResponseModel { Id = 5, Name = "North America", NumberOfCountries = 23 },
                new ContinentResponseModel { Id = 6, Name = "South America", NumberOfCountries = 12 },
                new ContinentResponseModel { Id = 7, Name = "Oceania", NumberOfCountries = 14 }
            };
        }
    }
}
