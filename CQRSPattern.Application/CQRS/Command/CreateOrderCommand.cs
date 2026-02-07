using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSPattern.Application.CQRS.Command
{
    public record CreateOrderCommand(
    string ProductName,
    int Quantity,
    decimal Price
) : IRequest<int>;
}
