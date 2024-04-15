using System;

namespace FreeCourse.Services.Discount.Models
{
    [Dapper.Contrib.Extensions.Table("dicount")] // bu tablouyu postgresql içindeki oluşacak tabloya mapliyorum
    //"discount" küçük harfle yazdık çünkü postgresqlde tablolar küçük harfle tutulur.
    public class Discount
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Rate { get; set; }
        public string Code { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
