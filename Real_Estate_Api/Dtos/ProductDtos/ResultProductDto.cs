﻿namespace Real_Estate_Api.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int CategoryId { get; set; }
        public bool DealOfTheDay { get; set; }
        public DateTime AdvertisementDate { get; set; }
        public string CategoryName { get; set; }
    }
}
