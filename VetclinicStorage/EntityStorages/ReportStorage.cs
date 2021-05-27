using ClientBusinessLogic.BindingModels;
using ClientBusinessLogic.Interfaces;
using ClientBusinessLogic.ViewModels;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace VetclinicStorage.EntityStorages
{
    public class ReportStorage  : IReportStorage
    {
        public ReportVisitMedicinesViewModel GetVisitMedicines(VisitBindingModel model)
        {
            using (var context = new VetclinicDbContext())
            {
                var medicines = from visit in context.Visits
                             where visit.Id == model.Id
                             join visitAnimal in context.VisitAnimals
                             on visit.Id equals visitAnimal.VisitId
                             join medicineAnimal in context.MedicinesDinamics
                             on visitAnimal.AnimalId equals medicineAnimal.AnimalId
                             join medicine in context.Medicines
                             on medicineAnimal.MedicineId equals medicine.Id
                             select new MedicineViewModel
                             {
                                 Name = medicine.Name,
                                 Description = medicine.Description,
                                                              };
                return new ReportVisitMedicinesViewModel
                {
                    VisitDate = model.Date,
                    Medicines = medicines.ToList()
                };
            }
        }
    }
}
