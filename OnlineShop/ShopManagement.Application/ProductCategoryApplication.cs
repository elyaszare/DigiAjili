using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            if (productCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failed("این گروه محصول وجود دارد نمی توانید گروه تکراری داشته باشید");

            var slug = command.Slug.Slugify();
            var productcategory = new ProductCategory(command.Name, command.Description, command.Picture,
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
                return operation.Failed("رکوردی با اطلاعات درخواست شده یافت نشد!!");

            if (productCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد!! لطفا دوباره تلاش کنید");

            var slug = command.Slug.Slugify();
            produCtcategory.Edit(command.Name, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.Keywords, command.MetaDescription, slug);
            productCategoryRepository.SaveChanges();
            return operation.Succeeded();
        }

        public EditProductCategory GetDetail(long id)
        {
            return productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return productCategoryRepository.Search(searchModel);
        }
    }
}
