namespace SoftBox.DataBase.Entities;

    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public int DisplayOrder { get; set; }   
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        //public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }

