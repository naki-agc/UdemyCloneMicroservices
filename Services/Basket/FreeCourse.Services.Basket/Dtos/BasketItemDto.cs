namespace FreeCourse.Services.Basket.Dtos
{
    public class BasketItemDto
    {
        public int Quantity { get; set; }
        public string CurseId { get; set; }
        public string CourseName{ get; set; }
        public decimal Price { get; set; }
    }
}
