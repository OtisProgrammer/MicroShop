using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Ordering.Application.Common;
using Ordering.Application.Orders.Commands;
using Ordering.Domain.Common;
using Ordering.Domain.OrderItems.Entities;
using Ordering.Domain.Orders.Entities;

namespace Ordering.Application.Orders.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CommandResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var commandResult = new CommandResult();
            try
            {
                var order = new Order()
                {
                    Address = request.Address,
                    Code = new Random().Next(11111, 99999).ToString(),
                    Description = request.Description,
                    UserId = 2,
                    OrderItems = request.Items.Select(o=>new OrderItem()
                    {
                        Count = o.Count,
                        Price = 100000,
                        ProductId = o.ProductId,
                    }).ToList()
                };
                await _unitOfWork.OrderRepository.Create(order);
                await _unitOfWork.Commit();
                commandResult.Message = "عملیات با موفقیت انجام شد";
                commandResult.MessageCode = (int)HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                commandResult.Message = "عملیات با شکست مواجه شد";
                commandResult.MessageCode = (int)HttpStatusCode.InternalServerError;
            }
            return commandResult;
        }
    }
}
