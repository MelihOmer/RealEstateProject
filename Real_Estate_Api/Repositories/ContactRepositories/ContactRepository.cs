using Dapper;
using Real_Estate_Api.Dtos.ContactDtos;
using Real_Estate_Api.Models.DapperContext;

namespace Real_Estate_Api.Repositories.ContactRepositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task CreateContactAsync(CreateContactDto createContactDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteContactAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            string query = "select * from contact";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultContactDto>(query);
                return values.ToList();
            }
        }

        public Task<GetByIdContactDto> GetContactByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Last4ContactResultDto>> GetLast4ContactAsync()
        {
            string query = "select top(4)* from contact order by Id desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<Last4ContactResultDto>(query);
                return values.ToList();
            }
        }
    }
}
