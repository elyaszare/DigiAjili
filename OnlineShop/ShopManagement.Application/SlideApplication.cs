using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository slideRepository;

        public SlideApplication(ISlideRepository slideRepository)
        {
            this.slideRepository = slideRepository;
        }

        public OperationResult Create(CreateSlide command)
        {
            var operation = new OperationResult();
            var slide = new Slide(command.Picture, command.PictureAlt, command.PictureTitle, command.Heading,
                command.Title, command.Text, command.BtnText);
            slideRepository.Create(slide);
            slideRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditSlide command)
        {
            var operation = new OperationResult();
            var slide = slideRepository.Get(command.Id);
            if (slide == null) return operation.Failed(ApplicationMessages.RecordNotFound);
            slide.Edit(command.Picture, command.PictureAlt, command.PictureTitle, command.Heading, command.Title,
                command.Text, command.BtnText);
            slideRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var slide = slideRepository.Get(id);
            if (slide == null) return operation.Failed(ApplicationMessages.RecordNotFound);
            slide.Remove();
            slideRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var slide = slideRepository.Get(id);
            if (slide == null) return operation.Failed(ApplicationMessages.RecordNotFound);
            slide.Restore();
            slideRepository.SaveChanges();
            return operation.Succeeded();
        }

        public EditSlide GetDetails(long id)
        {
            return slideRepository.GetDetails(id);
        }

        public List<SlideViewModel> GetList()
        {
            return slideRepository.GetList();
        }
    }
}
