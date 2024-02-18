using Real_Estate_Api.Dtos.BottomGridDtos;

namespace Real_Estate_Api.Repositories.BottomGridRepositories
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
        Task CreateBottomGridAsync(CreateBottomGridDto createBottomGridDto);
        Task UpdateBottomGridAsync(UpdateBottomGridDto updateBottomGridDto);
        Task DeleteBottomGridAsync(int id);
        Task<GetByIdBottomGridDto> GetBottomGridByIdAsync(int id);
    }
}
