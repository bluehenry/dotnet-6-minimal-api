﻿namespace Coffee.MinApi
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public string PromoCode { get; set; }
        public decimal Total { get; set; }        
    }
}
