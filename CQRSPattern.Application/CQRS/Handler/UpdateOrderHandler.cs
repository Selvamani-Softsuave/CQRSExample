using CQRSPattern.Application.CQRS.Command;
using CQRSPattern.Data.Database;
using CQRSPattern.Data.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSPattern.Application.CQRS.Handler
{
    public class UpdateOrderHandler: IRequestHandler<UpdateOrderCommand>
    {
        private readonly ApplicationContext _dbContext;

        public UpdateOrderHandler(ApplicationContext context)
        {
            _dbContext = context;
        }

        public async Task Handle(
         UpdateOrderCommand request,
         CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders
                .FindAsync(new object[] { request.OrderId }, cancellationToken);

            if (order == null)
                throw new Exception("Order not found");

            order.Quantity = request.Quantity;
            order.Price = request.Price;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
