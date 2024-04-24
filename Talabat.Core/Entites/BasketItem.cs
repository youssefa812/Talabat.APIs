﻿namespace Talabat.Core.Entites
{
	public class BasketItem
	{
        public int Id { get; set; }
		public string ProductName { get; set; }
		public string PictureUrl { get; set; }
		public decimal Price { get; set; }
		public virtual string Category { get; set; }
		public virtual string Brand { get; set; }
        public int Quantity { get; set; }
    }
}