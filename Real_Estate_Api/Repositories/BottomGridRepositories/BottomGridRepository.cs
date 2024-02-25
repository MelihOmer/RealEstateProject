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

        public async Task CreateBottomGridAsync(CreateBottomGridDto createBottomGridDto)
        {
            string query = "insert into BottomGrid (Icon,Title,Description) values (@icon,@title,@description)";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", createBottomGridDto.Icon);
            parameters.Add("@title", createBottomGridDto.Title);
            parameters.Add("@description", createBottomGridDto.Description);
            using (var connection = _context.CreateConnection())
            {
                var execute = await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteBottomGridAsync(int id)
        {
            string query = "delete BottomGrid where Id=@id";
            var param = new DynamicParameters();
            param.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, param);
            }
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

        public async Task<GetByIdBottomGridDto> GetBottomGridByIdAsync(int id)
        {
            string query = "select * from BottomGrid where Id = @id";
            var param = new DynamicParameters();
            param.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdBottomGridDto>(query, param);
                return values;
            }
        }

        public async Task UpdateBottomGridAsync(UpdateBottomGridDto updateBottomGridDto)
        {
            string query = "update  BottomGrid set Icon=@icon,Title=@title,Description=@description where Id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", updateBottomGridDto.Icon);
            parameters.Add("@title", updateBottomGridDto.Title);
            parameters.Add("@description", updateBottomGridDto.Description);
            parameters.Add("@id", updateBottomGridDto.Id);
            using (var connection = _context.CreateConnection())
            {
                var execute = await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
