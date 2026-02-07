using CQRSPattern.Application.CQRS.Query;
using CQRSPattern.Common.DTOs.ResponseDtos;
using CQRSPattern.Data.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CQRSPattern.Application.CQRS.Handler
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderDto?>
    {
        private readonly ApplicationContext _db;

        public GetOrderByIdHandler(ApplicationContext db)
        {
            _db = db;
        }

       

        public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _db.Orders
                 .AsNoTracking()
                 .Where(o => o.Id == request.OrderId)
                 .Select(o => new OrderDto
                 {
                     Id = o.Id,
                     ProductName = o.ProductName,
                     Quantity = o.Quantity,
                     Price = o.Price
                 })
                 .FirstOrDefaultAsync();
        }
    }
}
