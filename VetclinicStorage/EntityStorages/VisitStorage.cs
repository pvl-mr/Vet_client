﻿using ClientBusinessLogic.BindingModels;
using ClientBusinessLogic.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VetclinicStorage.Models;

namespace VetclinicStorage.EntityStorages
{
    public class VisitStorage : EntityStorage<VisitViewModel, VisitBindingModel, Visit>
    {
        private Func<Visit, VisitViewModel> selector;

        public VisitStorage()
        {
            selector = m => new VisitViewModel
            {
                Id = m.Id,
                Date = m.Date,
                Comment = m.Comment,
                Animals = m.VisitAnimals.ToDictionary(va => va.AnimalId, va => (va.Animal.Name, va.Animal.Breed)),
                Services = m.VisitServices.ToDictionary(vs => vs.ServiceId, vs => (vs.Service.Name, vs.Service.Description)),
                ClientId = m.ClientId
            };
        }

        protected override VisitViewModel CreateViewModel(Visit model)
        {
            return selector(model);
        }

        protected override Visit GetElement(VisitBindingModel binding, VetclinicDbContext context)
        {
            return context.Visits.Where(v => v.Id == binding.Id)
                .Include(v => v.VisitServices).ThenInclude(vs => vs.Service)
                .Include(v => v.VisitAnimals).ThenInclude(va => va.Animal)
                .SingleOrDefault(v => v.Id == binding.Id);
        }

        protected override List<VisitViewModel> GetFilteredList(VisitBindingModel binding, VetclinicDbContext context)
        {
            return context.Visits
                .Where(cl => cl.Id == binding.Id || cl.ClientId == binding.ClientId)
                .Where(md => (binding.DateFrom != null) ? (md.Date  >= binding.DateFrom && md.Date <= binding.DateTo) : true)
                .Include(v => v.VisitServices).ThenInclude(vs => vs.Service)
                .Include(v => v.VisitAnimals).ThenInclude(va => va.Animal)
                .Select(selector).ToList();
        }

        protected override List<VisitViewModel> GetFullList(VetclinicDbContext context)
        {
            return context.Visits
                .Include(v => v.VisitServices).ThenInclude(vs => vs.Service)
                .Include(v => v.VisitAnimals).ThenInclude(va => va.Animal)
                .Select(selector).ToList();
        }

        protected override Visit CreateModel(Visit model, VisitBindingModel binding)
        {
            model.Date = binding.Date;
            model.Comment = binding.Comment;
            model.ClientId = binding.ClientId;
            return model;
        }
        protected override void UpdateModel(Visit model, VisitBindingModel binding, VetclinicDbContext context)
        {
            CreateModel(model, binding);
            if (model.Id >= 1)
            {
                var visitAnimals = context.VisitAnimals.Where(va => va.VisitId == binding.Id).ToList();

                context.VisitAnimals.RemoveRange(visitAnimals.Where(va => !binding.AnimalIds.Contains(va.AnimalId)).ToList());

                foreach (var va in visitAnimals)
                {
                    binding.AnimalIds.Remove(va.AnimalId);
                }

                var visitServices = context.VisitServices.Where(va => va.VisitId == binding.Id).ToList();

                context.VisitServices.RemoveRange(visitServices.Where(va => !binding.ServiceIds.Contains(va.ServiceId)).ToList());

                foreach (var vs in visitServices)
                {
                    binding.ServiceIds.Remove(vs.ServiceId);
                }

                context.SaveChanges();
            }
            foreach (var serviceId in binding.ServiceIds)
            {
                context.VisitServices.Add(new VisitService
                {
                    VisitId = model.Id,
                    ServiceId = serviceId
                });
            }
            foreach (var animalId in binding.AnimalIds)
            {
                context.VisitAnimals.Add(new VisitAnimal
                {
                    VisitId = model.Id,
                    AnimalId = animalId
                });
            }
            context.SaveChanges();
        }
    }
}
