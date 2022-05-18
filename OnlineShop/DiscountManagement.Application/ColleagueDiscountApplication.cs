using System.Collections.Generic;
using _0_Framework.Application;
using DiscountManagement.Application.ColleagueDiscountAgg;
using DiscountManagement.Application.Contract.ColleagueDiscount;

namespace DiscountManagement.Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            this.colleagueDiscountRepository = colleagueDiscountRepository;
        }

        public OperationResult Define(DefineColleagueDiscount command)
        {
            var operation = new OperationResult();
            if (colleagueDiscountRepository.Exists(x =>
                x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return operation.Failed(ApplicationMessages.DuplicateRecord);
            var colleague = new ColleagueDiscount(command.ProductId, command.DiscountRate);
            colleagueDiscountRepository.Create(colleague);
            colleagueDiscountRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditColleagueDiscount command)
        {
            var operation = new OperationResult();
            var colleagueDiscount = colleagueDiscountRepository.Get(command.Id);
            if (colleagueDiscount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);


            if (colleagueDiscountRepository.Exists(x =>
                x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicateRecord);

            colleagueDiscount.Edit(command.Id, command.DiscountRate);

            colleagueDiscountRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var colleagueDiscount = colleagueDiscountRepository.Get(id);
            if (colleagueDiscount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);


            colleagueDiscount.Remove();

            colleagueDiscountRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var colleagueDiscount = colleagueDiscountRepository.Get(id);
            if (colleagueDiscount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);


            colleagueDiscount.Restore();

            colleagueDiscountRepository.SaveChanges();
            return operation.Succeeded();
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return colleagueDiscountRepository.GetDetails(id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            return colleagueDiscountRepository.Search(searchModel);
        }
    }
}
