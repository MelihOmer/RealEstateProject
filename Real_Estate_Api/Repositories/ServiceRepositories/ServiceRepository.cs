using Dapper;
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
            parameters.Add("@serviceStatus", createServiceDto.Status);
            using (var connection = _context.CreateConnection())
            {
                var execute = await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteServiceAsync(int id)
        {
            string query = "delete service where Id=@id";
            var param = new DynamicParameters();
            param.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, param);
            }
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

        public async Task<GetByIdServiceDto> GetServiceByIdAsync(int id)
        {
            string query = "select * from Service where Id = @id";
            var param = new DynamicParameters();
            param.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdServiceDto>(query,param);
                return values;
            }
        }

        public async Task UpdateServiceAsync(UpdateServiceDto updateServiceDto)
        {
            string query = "update  Service set Name=@name,Status=@status where Id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@name", updateServiceDto.Name);
            parameters.Add("@status", updateServiceDto.Status);
            parameters.Add("@id", updateServiceDto.Id);
            using (var connection = _context.CreateConnection())
            {
                var execute = await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
