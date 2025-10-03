using MediatR;

namespace YoutubeApi.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<IList<GetAllProductsQueryResponse>>
    {
        // Şimdilik boş, ileride filtreleme için property'ler ekleyebiliriz
    }
}