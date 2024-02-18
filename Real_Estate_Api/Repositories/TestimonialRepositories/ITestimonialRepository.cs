using Real_Estate_Api.Dtos.TestimonialDtos;

namespace Real_Estate_Api.Repositories.TestimonialRepositories
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
    }
}
