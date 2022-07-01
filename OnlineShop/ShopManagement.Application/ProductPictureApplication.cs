//IProductPictureApplication Implementation

using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IFileUploader fileUploader;
        private readonly IProductRepository _productRepository;
        private readonly IProductPictureRepository productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository,
            IProductRepository productRepository, IFileUploader fileUploader)
        {
            this.productPictureRepository = productPictureRepository;
            _productRepository = productRepository;
            this.fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var operation = new OperationResult();

            var product = _productRepository.GetProductWithCategoryBy(command.ProductId);
            var path = $"{product.Category.Slug}//{product.Slug}";
            var fileName = fileUploader.Upload(command.Picture, path);

            var productpicture = new ProductPicture(command.ProductId, fileName, command.PictureAlt,
                command.PictureTitle);
            productPictureRepository.Create(productpicture);
            productPictureRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operation = new OperationResult();

            var productpicture = productPictureRepository.GetWithProductAndCategory(command.Id);
            if (productpicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);


            var path = $"{productpicture.Product.Category.Slug}//{productpicture.Product.Slug}";
            var fileName = fileUploader.Upload(command.Picture, path);

            productpicture.Edit(command.ProductId, fileName, command.PictureAlt, command.PictureTitle);
            productPictureRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();

            var productpicture = productPictureRepository.Get(id);
            if (productpicture == null) return operation.Failed(ApplicationMessages.RecordNotFound);
            productpicture.Remove();
            productPictureRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();

            var productpicture = productPictureRepository.Get(id);
            if (productpicture == null) return operation.Failed(ApplicationMessages.RecordNotFound);
            productpicture.Restore();
            productPictureRepository.SaveChanges();
            return operation.Succeeded();
        }

        public EditProductPicture GetDetails(long id)
        {
            return productPictureRepository.GetDetails(id);
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return productPictureRepository.Search(searchModel);
        }
    }
}
