namespace Real_Estate_Api.Repositories.StatisticRepositories
{
    public interface IStatisticRepository
    {
        Task<int> CategoryCount();
        Task<int> ActiveCategoryCount();
        Task<int> PassiveCategoryCount();
        Task<int> ProductCount();
        Task<int> ApartmentCount();
        Task<string> EmployeeNameByMaxProductCount();
        Task<string> CategoryNameByMaxProductCount();
        Task<decimal> AverageProductPriceByRent();
        Task<decimal> AverageProductPriceBySale();
        Task<string> CityNameByMaxProductCount();
        Task<int> DifferentCityCount();
        Task<decimal> LastProductPrice();
        Task<string> NewestBuildingYear();
        Task<string> OldestBuildingYear();
        Task<int> AverageRoomCount();
        Task<int> ActiveEmployeeCount();
    }
}
