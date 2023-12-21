using System.Data.Common;
using Urfu23.Core.DataStorage;
using Urfu23.Core.Model;
using Urfu23.Core.SharedKernel.CQS;
using Urfu23.Core.SharedKernel.Repository;
using Urfu23.Core.SharedKernel.Result;
using WebApplication2.Api2.Model;

namespace WebApplication2.Api2.Features;

public class GetProductListQuery  : Query<ProductListDto>
{
    
}

public class GetProductListQueryHandler : QueryHandler<GetProductListQuery, ProductListDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IReadOnlyRepository<Product> _readOnlyRepository;

    public GetProductListQueryHandler(IProductRepository productRepository, IReadOnlyRepository<Product> readOnlyRepository)
    {
        _productRepository = productRepository;
        _readOnlyRepository = readOnlyRepository;
    }
    
    
    public override async Task<Result<ProductListDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ProductListItemDto Convert(Product x)
            {
                return new ProductListItemDto(x.Name, x.Price);
            }

            var products = await _readOnlyRepository.ListAsync(cancellationToken);
            var productDtos = products.Select(Convert).ToList();

            return Successfull(new ProductListDto(productDtos));
        }
        catch (DbException dbException)
        {
            //return Error(new ReadDataBaseError());
            //return Error(ReadDataBaseError.Instance);
            var readDataBaseError = new ReadDataBaseError();
            readDataBaseError.Data[nameof(dbException.Message)] = dbException.Message;

            return Error(readDataBaseError);
        }
    }
    
    public class ReadDataBaseError  : Error
    {
        public static ReadDataBaseError Instance => new();
        public override string Type => nameof(ReadDataBaseError);

        public ReadDataBaseError()
        {
            
        }
    }
}