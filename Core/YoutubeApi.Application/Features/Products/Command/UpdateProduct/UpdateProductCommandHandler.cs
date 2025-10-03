using AutoMapper;
using MediatR;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        public IUnitOfWork _unitOfWork { get; }
        public IMapper _mapper { get; }

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);

            var updateProduct = _mapper.Map<UpdateProductCommandRequest, Product>(request);

            var productCategories = await _unitOfWork.GetReadRepository<ProductCategory>()
                .GetAllAsync(x => x.ProductId == request.Id);

            await _unitOfWork.GetWriteRepository<ProductCategory>()
                .HardDeleteRangeAsync(productCategories);

            foreach (var categoryId in request.CategoryIds)
                await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                {
                    CategoryId = categoryId,
                    ProductId = request.Id
                });

            await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(updateProduct);
            await _unitOfWork.SaveAsync();

        }
    }
}
