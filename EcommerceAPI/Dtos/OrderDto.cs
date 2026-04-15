namespace EcommerceAPI.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public List<OrderItemDto> Items { get; set; } = new();
    }
    
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total => Quantity * Price;
    }
    
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public List<OrderItemCreateDto> Items { get; set; } = new();
    }
    
    public class OrderItemCreateDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}