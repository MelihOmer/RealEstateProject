using Real_Estate_Api.Dtos.ContactDtos;

namespace Real_Estate_Api.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task<List<Last4ContactResultDto>> GetLast4ContactAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task DeleteContactAsync(int id);
        Task<GetByIdContactDto> GetContactByIdAsync(int id);
    }
}
