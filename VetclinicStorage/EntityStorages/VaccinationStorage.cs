using ClientBusinessLogic.BindingModels;
using ClientBusinessLogic.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VetclinicStorage.Models;

namespace VetclinicStorage.EntityStorages
{
    public class VaccinationStorage : EntityStorage<VaccinationViewModel, VaccinationBindingModel, Vaccination>
    {
        private Func<Vaccination, VaccinationViewModel> selector;

        public VaccinationStorage()
        {
            selector = m => new VaccinationViewModel {
                Id = m.Id,
                Date = m.Date,
                Name = m.Name,
                Description = m.Description,
                AnimalName = m.Animal.Name,
                AnimalId = m.AnimalId
            };
        }

        protected override VaccinationViewModel CreateViewModel(Vaccination model)
        {
            return selector(model);
        }

        protected override Vaccination GetElement(VaccinationBindingModel binding, VetclinicDbContext context)
        {
            return context.Vaccinations.Include(m => m.Client).Include(m => m.Animal).SingleOrDefault(m => m.Id == binding.Id);
        }

        protected override List<VaccinationViewModel> GetFilteredList(VaccinationBindingModel binding, VetclinicDbContext context)
        {
            return context.Vaccinations.Include(m => m.Client).Include(m => m.Animal).Where(m => m.Id == binding.Id || m.Name == binding.Name || m.ClientId == binding.ClientId).Select(selector).ToList();
        }

        protected override List<VaccinationViewModel> GetFullList(VetclinicDbContext context)
        {
            return context.Vaccinations.Include(m => m.Client).Include(m => m.Animal).Select(selector).ToList();
        }

        protected override Vaccination CreateModel(Vaccination model, VaccinationBindingModel binding)
        {
            model.Date = binding.Date;
            model.Name = binding.Name;
            model.Description = binding.Description;
            model.ClientId = binding.ClientId;
            model.AnimalId = binding.AnimalId;
            return model;
        }
        protected override void UpdateModel(Vaccination model, VaccinationBindingModel binding, VetclinicDbContext context)
        {
            if (binding.Id < 1)
                return;
            CreateModel(model, binding);
        }
    }
}
