using CQRSPattern.Application.CQRS.Command;
using CQRSPattern.Data.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CQRSPattern.Application.CQRS.Handler
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly ApplicationContext _dbContext;

        public DeleteOrderHandler(ApplicationContext context)
        {
            _dbContext = context;
        }

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.FindAsync(request.OrderId);

            if (order == null)
                throw new Exception("Order not found");

            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
        }
    }
}
