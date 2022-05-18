//IProductPictureApplication Implementation

using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository)
        {
            this.productPictureRepository = productPictureRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var operation = new OperationResult();
            if (productPictureRepository.Exists(x => x.Picture == command.Picture && x.ProductId == command.ProductId))
                return operation.Failed(ApplicationMessages.DuplicateRecord);

            var productpicture = new ProductPicture(command.ProductId, command.Picture, command.PictureAlt,
                command.PictureTitle);
            productPictureRepository.Create(productpicture);
            productPictureRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operation = new OperationResult();

            var productpicture = productPictureRepository.Get(command.Id);
            if (productpicture == null) return operation.Failed(ApplicationMessages.RecordNotFound);

            if (productPictureRepository.Exists(x => x.Picture == command.Picture && x.Id == command.Id))
                return operation.Failed(ApplicationMessages.DuplicateRecord);
            productpicture.Edit(command.Id, command.Picture, command.PictureAlt, command.PictureTitle);
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
