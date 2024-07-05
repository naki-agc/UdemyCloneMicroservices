using FreeCourse.Services.Order.Application.Dtos;
using FreeCourse.Services.Order.Application.Mapping;
using FreeCourse.Services.Order.Application.Queries;
using FreeCourse.Services.Order.Infrastructure;
using FreeCourse.Shared.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FreeCourse.Services.Order.Application.Handlers
{
    public class GetOrderByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, Response<List<OrderDto>>> //veritabanına gidip soruguyu alacak sınıf burası olacak
    {

        private readonly OrderDbContext _context;
        //GENERİC REPOSİTORY YA DA REPOSİTORY PATTERN KULLANABİLİRİZ O ZAMAN CONTEXT YERİNE ONLARI ENJEKTE EDEBİLİRİZ
        //FAKAT _CONTEXT DAHA PERFORMAN VE HIZLI SORGULAR YAZABİLİRİZ DENDİ.

        public GetOrderByUserIdQueryHandler(OrderDbContext context)
        { 
            _context = context;
        }

        public async Task<Response<List<OrderDto>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders.Include(x => x.OrderItems).Where(x => x.BuyerId == request.UserId).ToListAsync();

            if (!orders.Any())
            {
                return Response<List<OrderDto>>.Success(new List<OrderDto>(), 200); //404 dönmektense boş bir sınıf döndürdük.
            }

            var ordersDto = ObjectMapper.Mapper.Map<List<OrderDto>>(orders);

            return Response<List<OrderDto>>.Success(ordersDto, 200);

        }
    }
}
