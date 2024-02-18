using Dapper;
using Real_Estate_Api.Dtos.BottomGridDtos;
using Real_Estate_Api.Models.DapperContext;

namespace Real_Estate_Api.Repositories.BottomGridRepositories
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly AppDbContext _context;

        public BottomGridRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task CreateBottomGridAsync(CreateBottomGridDto createBottomGridDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBottomGridAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
        {
            string query = "select * from BottomGrid";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBottomGridDto>(query);
                return values.ToList();
            }
        }

        public Task<GetByIdBottomGridDto> GetBottomGridByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBottomGridAsync(UpdateBottomGridDto updateBottomGridDto)
        {
            throw new NotImplementedException();
        }
    }
}
