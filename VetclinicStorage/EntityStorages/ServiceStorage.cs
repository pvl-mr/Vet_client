﻿using ClientBusinessLogic.BindingModels;
using ClientBusinessLogic.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VetclinicStorage.Models;

namespace VetclinicStorage.EntityStorages
{
    public class ServiceStorage : EntityStorage<ServiceViewModel, ServiceBindingModel, Service>
    {
        Func<Service, ServiceViewModel> selector;

        public ServiceStorage()
        {
            selector = s => new ServiceViewModel
            {
                Id = s.Id,
                Description = s.Description,
                Name = s.Name,
                DoctorId = s.DoctorId,
                Medicines = s.ServiceMedicines.ToDictionary(sm => sm.MedicineId, sm => (sm.Medicine.Name, sm.Medicine.Description))
            };
        }

        protected override ServiceViewModel CreateViewModel(Service model)
        {
            return selector(model);
        }

        protected override Service GetElement(ServiceBindingModel binding, VetclinicDbContext context)
        {
            return context.Services.Where(s => s.Id == binding.Id || s.Name == binding.Name)
              .Include(s => s.ServiceMedicines).ThenInclude(sm => sm.Medicine)
              .SingleOrDefault();
        }

        protected override List<ServiceViewModel> GetFilteredList(ServiceBindingModel binding, VetclinicDbContext context)
        {
            return context.Services.Where(s => s.Name == binding.Name)
             .Include(s => s.ServiceMedicines).ThenInclude(sm => sm.Medicine)
             .Select(selector).ToList();
        }

        protected override List<ServiceViewModel> GetFullList(VetclinicDbContext context)
        {
            return context.Services
            .Include(s => s.ServiceMedicines).ThenInclude(sm => sm.Medicine)
            .Select(selector).ToList();
        }

        protected override Service CreateModel(Service emptyModel, ServiceBindingModel binding)
        {
            emptyModel.Name = binding.Name;
            emptyModel.Description = binding.Description;
            emptyModel.DoctorId = binding.DoctorId;
            return emptyModel;
        }

        protected override void UpdateModel(Service model, ServiceBindingModel binding, VetclinicDbContext context)
        {
            CreateModel(model, binding);

            // serviceMedicine - список записей ДО ОБНОВЛЕНИЯ
            // binding.Medicines - словарь с записями НОВОЙ ИНФОРМАЦИИ

            var serviceMedicine = context.ServiceMedicines.Where(sm => sm.ServiceId == model.Id).ToList();

            context.ServiceMedicines.RemoveRange(serviceMedicine.Where(sm => !binding.Medicines.ContainsKey(sm.MedicineId)).ToList());

            foreach (var sm in serviceMedicine)
            {
                binding.Medicines.Remove(sm.MedicineId);
            }

            context.SaveChanges();

            foreach (var medicineId in binding.Medicines.Keys)
            {
                context.ServiceMedicines.Add(new ServiceMedicine
                {
                    ServiceId = model.Id,
                    MedicineId = medicineId
                });
            }
            context.SaveChanges();
        }
    }
}
