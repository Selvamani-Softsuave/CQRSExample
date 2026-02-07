using CQRSPattern.Common.DTOs.ResponseDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSPattern.Application.CQRS.Query
{
    public record GetOrderByIdQuery(int OrderId) : IRequest<OrderDto?>;
}
