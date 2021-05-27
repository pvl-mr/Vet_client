using ClientBusinessLogic.BindingModels;
using ClientBusinessLogic.Interfaces;
using ClientBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ClientBusinessLogic.BusinessLogic
{
    public class AnimalLogic
    {
        private readonly IEntityStorage<AnimalViewModel, AnimalBindingModel> _animalStorage;

        public AnimalLogic(IEntityStorage<AnimalViewModel, AnimalBindingModel> animalStorage)
        {
            _animalStorage = animalStorage;
        }

        public List<AnimalViewModel> GetFullList()
        {
            return _animalStorage.GetFullList();
        }
        public List<AnimalViewModel> GetFilteredList(AnimalBindingModel binding)
        {
            return _animalStorage.GetFilteredList(binding);
        }
        public AnimalViewModel GetElement(AnimalBindingModel binding)
        {
            return _animalStorage.GetElement(binding);
        }

        public void CreateOrUpdate(AnimalBindingModel binding)
        {
            var element = _animalStorage.GetElement(new AnimalBindingModel { Name = binding.Name, Type = binding.Type, Breed = binding.Breed });


            if (element != null && element.Id != binding.Id)
                throw new Exception("Такой питомец уже есть");

            if (binding.Id >= 1)
                _animalStorage.Update(binding);
            else
                _animalStorage.Insert(binding);
        }

        public void Delete(AnimalBindingModel binding)
        {
            var element = _animalStorage.GetElement(new AnimalBindingModel { Id = binding.Id });

            if (element == null)
                throw new Exception($"Элемент c id {binding.Id} найден");

            _animalStorage.Delete(binding);
        }
    }
}
