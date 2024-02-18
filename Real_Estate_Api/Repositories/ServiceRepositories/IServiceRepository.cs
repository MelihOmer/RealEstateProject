using Real_Estate_Api.Dtos.ServiceDtos;

namespace Real_Estate_Api.Repositories.ServiceRepositories
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServiceAsync();
        Task CreateServiceAsync(CreateServiceDto createServiceDto);
        Task UpdateServiceAsync(UpdateServiceDto updateServiceDto);
        Task DeleteServiceAsync(int id);
        Task<GetByIdServiceDto> GetServiceByIdAsync(int id);
    }
}
