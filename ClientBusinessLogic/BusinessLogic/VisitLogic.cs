using ClientBusinessLogic.BindingModels;
using ClientBusinessLogic.Interfaces;
using ClientBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ClientBusinessLogic.BusinessLogic
{
    public class VisitLogic
    {
        private readonly IEntityStorage<VisitViewModel, VisitBindingModel> _visitStorage;

        public VisitLogic(IEntityStorage<VisitViewModel, VisitBindingModel> visitStorage)
        {
            _visitStorage = visitStorage;
        }

        public List<VisitViewModel> GetFullList()
        {
            return _visitStorage.GetFullList();
        }
        public List<VisitViewModel> GetFilteredList(VisitBindingModel binding)
        {
            return _visitStorage.GetFilteredList(binding);
        }
        public VisitViewModel GetElement(VisitBindingModel binding)
        {
            return _visitStorage.GetElement(binding);
        }

        public void CreateOrUpdate(VisitBindingModel binding)
        {
            var element = _visitStorage.GetElement(new VisitBindingModel { Date = binding.Date, ClientId = binding.ClientId, Comment = binding.Comment });


            if (element != null && element.Id != binding.Id)
                throw new Exception("Такой визит уже есть");

            if (binding.Id >= 1)
                _visitStorage.Update(binding);
            else
                _visitStorage.Insert(binding);
        }

        public void Delete(VisitBindingModel binding)
        {
            var element = _visitStorage.GetElement(new VisitBindingModel { Id = binding.Id });

            if (element == null)
                throw new Exception($"Элемент c id {binding.Id} найден");

            _visitStorage.Delete(binding);
        }
    }
}
