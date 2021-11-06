using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();
            if (productRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicateRecord);
            var slug = command.Slug.Slugify();

            var product = new Product(command.Name, command.Code, command.ShortDescription, command.Description,
                command.Picture, command.PictureAlt, command.PictureTitle, command.UnitPrice, command.CategoryId,
                command.Keywords, command.MetaDescription, slug);
            productRepository.Create(product);
            productRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = productRepository.Get(command.Id);
            if (product == null) return operation.Failed(ApplicationMessages.RecordNotFound);
            if (productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicateRecord);

            var slug = command.Slug.Slugify();
            product.Edit(command.Name, command.Code, command.ShortDescription, command.Description,
                command.Picture, command.PictureAlt, command.PictureTitle, command.UnitPrice, command.CategoryId,
                command.Keywords, command.MetaDescription, slug);
            productRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Stock(long id)
        {
            var operation = new OperationResult();
            var product = productRepository.Get(id);
            if (product == null) return operation.Failed(ApplicationMessages.RecordNotFound);
            product.Stock();
            productRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult NotStock(long id)
        {
            var operation = new OperationResult();
            var product = productRepository.Get(id);
            if (product == null) return operation.Failed(ApplicationMessages.RecordNotFound);
            product.NotStock();
            productRepository.SaveChanges();
            return operation.Succeeded();
        }

        public EditProduct GetDetails(long id)
        {
            return productRepository.GetDetails(id);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return productRepository.Search(searchModel);
        }
    }
}
