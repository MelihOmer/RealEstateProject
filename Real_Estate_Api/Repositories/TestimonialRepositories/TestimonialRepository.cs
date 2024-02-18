using Dapper;
using Real_Estate_Api.Dtos.TestimonialDtos;
using Real_Estate_Api.Models.DapperContext;

namespace Real_Estate_Api.Repositories.TestimonialRepositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly AppDbContext _context;

        public TestimonialRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            string query = "select * from Testimonial";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTestimonialDto>(query);
                return values.ToList();
            }
        }
    }
}
