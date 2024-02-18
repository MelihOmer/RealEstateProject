using Real_Estate_Api.Dtos.PopulerLocationDtos;

namespace Real_Estate_Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync();
    }
}
