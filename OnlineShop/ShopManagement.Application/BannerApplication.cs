using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Banner;
using ShopManagement.Domain.BannerAgg;

namespace ShopManagement.Application
{
    public class BannerApplication : IBannerApplication
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly IFileUploader _fileUploader;

        public BannerApplication(IBannerRepository bannerRepository, IFileUploader fileUploader)
        {
            _bannerRepository = bannerRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateBanner command)
        {
            var operation = new OperationResult();

            var fileName = _fileUploader.Upload(command.Picture, "Banners");

            var startDate = command.StartDate.ToGeorgianDateTime();
            var endDate = command.EndDate.ToGeorgianDateTime();
            var banner = new Banner(fileName, command.PictureAlt, command.PictureTitle, command.Heading, command.Title,
                command.Link, command.BtnText, startDate, endDate);

            _bannerRepository.Create(banner);
            _bannerRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditBanner command)
        {
            var operation = new OperationResult();

            var banner = _bannerRepository.Get(command.Id);

            if (banner == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var fileName = _fileUploader.Upload(command.Picture, "Banners");
            var startDate = command.StartDate.ToGeorgianDateTime();
            var endDate = command.EndDate.ToGeorgianDateTime();
            banner.Edit(fileName, command.PictureAlt, command.PictureTitle, command.Heading, command.Title,
                command.Link, command.BtnText, startDate, endDate);
            _bannerRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();

            var banner = _bannerRepository.Get(id);

            if (banner == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            banner.Remove();
            _bannerRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();

            var banner = _bannerRepository.Get(id);

            if (banner == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            banner.Restore();
            _bannerRepository.SaveChanges();
            return operation.Succeeded();
        }

        public EditBanner GetDetails(long id)
        {
            return _bannerRepository.GetDetails(id);
        }

        public List<BannerViewModel> GetList()
        {
            return _bannerRepository.GetList();
        }
    }
}
