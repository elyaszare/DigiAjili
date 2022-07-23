
//IProductCategoryApplication Implementation

using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IProductCategoryRepository productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository,
            IFileUploader fileUploader)
        {
            this.productCategoryRepository = productCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            if (productCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicateRecord);

            var slug = command.Slug.Slugify();
            var picturePath = $"{command.Slug}";
            var fileName = _fileUploader.Upload(command.Picture, picturePath);
            var productcategory = new ProductCategory(command.Name, command.Description, fileName,
                command.PictureAlt, command.PictureTitle, command.Keywords, command.MetaDescription, slug);
            productCategoryRepository.Create(productcategory);
            productCategoryRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operation = new OperationResult();
            var produCtcategory = productCategoryRepository.Get(command.Id);

            if (produCtcategory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (productCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicateRecord);

            var slug = command.Slug.Slugify();
            var picturePath = $"{command.Slug}";
            var fileName = _fileUploader.Upload(command.Picture, picturePath);
            produCtcategory.Edit(command.Name, command.Description, fileName,
                command.PictureAlt, command.PictureTitle, command.Keywords, command.MetaDescription, slug);
            productCategoryRepository.SaveChanges();
            return operation.Succeeded();
        }
        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var category = productCategoryRepository.Get(id);
            if (category == null) return operation.Failed(ApplicationMessages.RecordNotFound);
            category.Remove();
            productCategoryRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var category = productCategoryRepository.Get(id);
            if (category == null) return operation.Failed(ApplicationMessages.RecordNotFound);
            category.Restore();
            productCategoryRepository.SaveChanges();
            return operation.Succeeded();
        }
        public EditProductCategory GetDetail(long id)
        {
            return productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return productCategoryRepository.GetProductCategories();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return productCategoryRepository.Search(searchModel);
        }
    }
}
