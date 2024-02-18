using Real_Estate_Api.Dtos.WhoWeAreDetailDtos;
using Real_Estate_Api.Dtos.WhoWeAreDtos;

namespace Real_Estate_Api.Repositories.WhoWeAreRepositories
{
    public interface IWhoWeAreDetailRepository
    {
        Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync();
        Task CreateWhoWeAreDetailAsync(CreateWhoWeAreDetailDto createWhoWeAreDetailDto);
        Task UpdateWhoWeAreDetailAsync(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto);
        Task DeleteWhoWeAreDetailAsync(int id);
        Task<GetByIdWhoWeAreDetailDto> GetWhoWeAreDetailByIdAsync(int id);
    }
}
