using ClientBusinessLogic.BindingModels;
using ClientBusinessLogic.Interfaces;
using ClientBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ClientBusinessLogic.BusinessLogic
{
    public class VaccinationLogic
    {
        private readonly IEntityStorage<VaccinationViewModel, VaccinationBindingModel> _vaccinationStorage;

        public VaccinationLogic(IEntityStorage<VaccinationViewModel, VaccinationBindingModel> vaccinationStorage)
        {
            _vaccinationStorage = vaccinationStorage;
        }

        public List<VaccinationViewModel> GetFullList()
        {
            return _vaccinationStorage.GetFullList();
        }
        public List<VaccinationViewModel> GetFilteredList(VaccinationBindingModel binding)
        {
            return _vaccinationStorage.GetFilteredList(binding);
        }
        public VaccinationViewModel GetElement(VaccinationBindingModel binding)
        {
            return _vaccinationStorage.GetElement(binding);
        }

        public void CreateOrUpdate(VaccinationBindingModel binding)
        {
            var element = _vaccinationStorage.GetElement(new VaccinationBindingModel { Name = binding.Name, Date = binding.Date, Description = binding.Description});


            if (element != null && element.Id != binding.Id)
                throw new Exception("Такая прививка уже есть");

            if (binding.Id >= 1)
                _vaccinationStorage.Update(binding);
            else
                _vaccinationStorage.Insert(binding);
        }

        public void Delete(VaccinationBindingModel binding)
        {
            var element = _vaccinationStorage.GetElement(new VaccinationBindingModel { Id = binding.Id });

            if (element == null)
                throw new Exception($"Элемент c id {binding.Id} найден");
            _vaccinationStorage.Delete(binding);
        }
    }
}

