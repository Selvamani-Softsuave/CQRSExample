using CQRSPattern.Application.CQRS.Command;
using CQRSPattern.Data.Database;
using CQRSPattern.Data.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CQRSPattern.Application.CQRS.Handler
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly ApplicationContext _dbContext;

        public CreateOrderHandler(ApplicationContext context)
        {
            _dbContext = context;
        }
        public async Task<int> Handle(
         CreateOrderCommand request,
         CancellationToken cancellationToken)
        {
            var order = new Orders
            {
                Id = new int(),
                ProductName = request.ProductName,
                Quantity = request.Quantity,
                Price = request.Price
            };

            _dbContext.Orders.Add(order);
             await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
