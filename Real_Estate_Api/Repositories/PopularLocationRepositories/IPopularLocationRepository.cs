using Real_Estate_Api.Dtos.PopulerLocationDtos;

namespace Real_Estate_Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync();
        Task CreatePopularLocationAsync(CreatePopularLocationDto createPopularLocationDto);
        Task UpdatePopularLocationAsync(UpdatePopularLocationDto updatePopularLocationDto);
        Task DeletePopularLocationAsync(int id);
        Task<GetByIdPopularLocationDto> GetPopularLocationByIdAsync(int id);
    }
}
