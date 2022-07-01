//IProductApplication Implementation

using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IProductRepository productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductApplication(IProductRepository productRepository, IFileUploader fileUploader,
            IProductCategoryRepository productCategoryRepository)
        {
            this.productRepository = productRepository;
            _fileUploader = fileUploader;
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();
            if (productRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicateRecord);
            var slug = command.Slug.Slugify();

            var categorySlug = _productCategoryRepository.GetSlugBy(command.CategoryId);

            var picturePath = $"{categorySlug}/{slug}";

            var fileName = _fileUploader.Upload(command.Picture, picturePath);
            var product = new Product(command.Name, command.Code, command.ShortDescription, command.Description,
                fileName, command.PictureAlt, command.PictureTitle, command.CategoryId,
                command.Keywords, command.MetaDescription, slug);
            productRepository.Create(product);
            productRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = productRepository.GetProductWithCategoryBy(command.Id);
            if (product == null) return operation.Failed(ApplicationMessages.RecordNotFound);
            if (productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicateRecord);

            var slug = command.Slug.Slugify();


            var picturePath = $"{product.Category.Slug}/{slug}";

            var fileName = _fileUploader.Upload(command.Picture, picturePath);

            product.Edit(command.Name, command.Code, command.ShortDescription, command.Description,
                fileName, command.PictureAlt, command.PictureTitle, command.CategoryId,
                command.Keywords, command.MetaDescription, slug);
            productRepository.SaveChanges();
            return operation.Succeeded();
        }

        public EditProduct GetDetails(long id)
        {
            return productRepository.GetDetails(id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return productRepository.GetProducts();
        }


        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return productRepository.Search(searchModel);
        }
    }
}
