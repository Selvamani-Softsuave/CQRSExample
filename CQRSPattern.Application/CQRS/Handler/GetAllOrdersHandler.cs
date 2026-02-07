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

namespace CQRSPattern.Application.CQRS.Handler
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDto>>
    {
        private readonly ApplicationContext _db;

        public GetAllOrdersHandler(ApplicationContext db)
        {
            _db = db;
        }

        

        public async  Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _db.Orders
                .AsNoTracking()
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    ProductName = o.ProductName,
                    Quantity = o.Quantity,
                    Price = o.Price
                })
                .ToListAsync();
        }
    }
}
