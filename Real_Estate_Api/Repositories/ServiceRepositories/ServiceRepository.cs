using Dapper;
using Real_Estate_Api.Dtos.CategoryDtos;
using Real_Estate_Api.Dtos.ServiceDtos;
using Real_Estate_Api.Models.DapperContext;

namespace Real_Estate_Api.Repositories.ServiceRepositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _context;

        public ServiceRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task CreateServiceAsync(CreateServiceDto createServiceDto)
        {
            string query = "insert into Service (Name,Status) values (@serviceName,@serviceStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceName", createServiceDto.Name);
            parameters.Add("@serviceStatus", true);
            using (var connection = _context.CreateConnection())
            {
                var execute = await connection.ExecuteAsync(query, parameters);
            }
        }

        public Task DeleteServiceAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultServiceDto>> GetAllServiceAsync()
        {
            string query = "select * from Service";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
            }
        }

        public Task<GetByIdServiceDto> GetServiceByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateServiceAsync(UpdateServiceDto updateServiceDto)
        {
            throw new NotImplementedException();
        }
    }
}
