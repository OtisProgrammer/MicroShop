using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.Application.Common;
using Catalog.Application.Products.Commands;
using Catalog.Domain.Common;
using Catalog.Domain.Products.Entities;
using MediatR;

namespace Catalog.Application.Products.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CommandResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CommandResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var commandResult = new CommandResult();
            try
            {
                var newProduct = _mapper.Map<Product>(request);
                await _unitOfWork.ProductRepository.Create(newProduct);
                await _unitOfWork.Commit();
                commandResult.Message = "عملیات با موفقیت انجام شد";
                commandResult.MessageCode = (int)HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                commandResult.Message = "عملیات با شکستت مواجه شد";
                commandResult.MessageCode = (int)HttpStatusCode.InternalServerError;
            }
            return commandResult;
        }
    }
}
