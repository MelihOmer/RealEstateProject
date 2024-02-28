namespace Reasl_Estate_UI.Dtos.ProductDtos
{
    public class ResultProductAdvertListWithCategoryByEmployeeDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string categoryName { get; set; }
        public string coverImage { get; set; }
        public string type { get; set; }
        public string adress { get; set; }
        public bool dealOfTheDay { get; set; }
        public DateTime advertisementDate { get; set; }
    }
}
