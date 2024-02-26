namespace Reasl_Estate_UI.Dtos.ContactDtos
{
    public class Last4ContactResultDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public DateTime sendDate { get; set; }
    }
}
