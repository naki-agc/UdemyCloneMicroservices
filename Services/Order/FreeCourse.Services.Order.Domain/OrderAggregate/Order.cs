using FreeCourse.Services.Order.Domain.Core;
using FreeCourse.Services.Order.Domain.Core.FreeCourse.Services.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Services.Order.Domain.OrderAggregate
{
    public class Order:Entity,IAggregateRoot
    {
        public DateTime CreatedDate { get; private set; }
        public Address Address{ get; private set; }
        public string BuyerId { get; private set; }

        //bu public olursa birisi data ekleyebilir olmaz ben sadece okuma yapsın istiyorum
        private readonly List<OrderItem> _orderItems; // backing field sadece okuma yazma verir ef core fielddir bu get seti olan property yoksa fieldtır
        
        
        //birbirine kapsülledim
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Order() { }

        //order üretmek için bir constructer aşağıdadır.
        public Order(string buyerId,Address address)
        {
            _orderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
            BuyerId = buyerId;
        }



        public void AddOrderItem(string productId,string productName, decimal price, string pictureUrl)
        {
            var existProduct = _orderItems.Any(x=> x.ProductId == productId);

            if (!existProduct)
            {
                var newOrderItem = new OrderItem(productId, productName, pictureUrl, price);
                _orderItems.Add(newOrderItem);
            }
        }


        //yardımcı bir field 
        public decimal GetTotalPrice => _orderItems.Sum(x => x.Price);


    }
}
