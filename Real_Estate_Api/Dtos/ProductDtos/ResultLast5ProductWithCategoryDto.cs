namespace Real_Estate_Api.Dtos.ProductDtos
{
    public class ResultLast5ProductWithCategoryDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string categoryName { get; set; }
        public DateTime AdvertisementDate { get; set; }
    }
}
