using Dapper;
using Real_Estate_Api.Dtos.WhoWeAreDetailDtos;
using Real_Estate_Api.Dtos.WhoWeAreDtos;
using Real_Estate_Api.Models.DapperContext;

namespace Real_Estate_Api.Repositories.WhoWeAreRepositories
{
    public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
    {
        private readonly AppDbContext _context;

        public WhoWeAreDetailRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateWhoWeAreDetailAsync(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            string query = "insert into WhoWeAreDetail (Title,SubTitle,Description1,Description2) values (@title,@subTtile,@description1,@description2)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createWhoWeAreDetailDto.Title);
            parameters.Add("@subTtile", createWhoWeAreDetailDto.SubTitle);
            parameters.Add("@description1", createWhoWeAreDetailDto.Description1);
            parameters.Add("@description2", createWhoWeAreDetailDto.Description2);
 
            using (var connection = _context.CreateConnection())
            {
                var execute = await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteWhoWeAreDetailAsync(int id)
        {
            string query = "delete from WhoWeAreDetail where Id=@whowearedetailId";
            var parameters = new DynamicParameters();
            parameters.Add("@whowearedetailId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
        {
            string query = "select * from WhoWeAreDetail";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdWhoWeAreDetailDto> GetWhoWeAreDetailByIdAsync(int id)
        {
            string query = "select * from WhoWeAreDetail where Id=@whoWeAreDetailId";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@whoWeAreDetailId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdWhoWeAreDetailDto>(query, parameters);
                return values;
            }
        }

        public async Task UpdateWhoWeAreDetailAsync(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            string query = "update WhoWeAreDetail set Title=@title,SubTitle=@subTitle,Description1=@description1,Description2=@description2 where Id=@whoWeAreDetailId";
            var parameters = new DynamicParameters();
            parameters.Add("@title", updateWhoWeAreDetailDto.Title);
            parameters.Add("@SubTitle", updateWhoWeAreDetailDto.SubTitle);
            parameters.Add("@Description1", updateWhoWeAreDetailDto.Description1);
            parameters.Add("@Description2", updateWhoWeAreDetailDto.Description2);
            parameters.Add("@whoWeAreDetailId", updateWhoWeAreDetailDto.Id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
