using ClientBusinessLogic.BindingModels;
using ClientBusinessLogic.HelperModels;
using ClientBusinessLogic.Interfaces;
using ClientBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientBusinessLogic.BusinessLogic
{
    public class ClientReportLogic
    {
        private readonly IEntityStorage<VisitViewModel, VisitBindingModel> visitStorage;
        private readonly IEntityStorage<AnimalViewModel, AnimalBindingModel> animalStorage;
        private readonly IEntityStorage<MedicineDinamicViewModel, MedicineDinamicBindingModel> medicineDimamicStorage;

        public ClientReportLogic(IEntityStorage<VisitViewModel, VisitBindingModel> visitStorage, IEntityStorage<AnimalViewModel, AnimalBindingModel> animalStorage, IEntityStorage<MedicineDinamicViewModel, MedicineDinamicBindingModel> medicineDimamicStorage)
        {
            this.visitStorage = visitStorage;
            this.animalStorage = animalStorage;
            this.medicineDimamicStorage = medicineDimamicStorage;
        }

        private List<ReportVisitMedicinesViewModel> GetVisitMedicines(List<VisitViewModel> selectedVisits)
        {
            var medicines = medicineDimamicStorage.GetFullList();
            var list = new List<ReportVisitMedicinesViewModel>();

            foreach (var visit in selectedVisits)
            {
                var record = new ReportVisitMedicinesViewModel
                {
                    VisitDate = visit.Date,
                    Medicines = new List<MedicineDinamicViewModel>(),
                };

                var listMedicines = new List<MedicineDinamicViewModel>();

                foreach (var visitAnimal in visit.Animals)
                {
                    var animal = animalStorage.GetElement(new AnimalBindingModel
                    {
                        Id = visitAnimal.Key
                    });

                    foreach (var medicine in medicines)
                    {                  
                            if (medicine.AnimalId == animal.Id)
                            {
                                if (!listMedicines.Contains(medicine))
                                {
                                    listMedicines.Add(medicine);
                                }
                            }
                        
                    }
                }

                foreach (var medicine in listMedicines)
                {
                    var medicineRecord = medicineDimamicStorage.GetElement(new MedicineDinamicBindingModel
                    {
                        Id = medicine.Id
                    });
                    record.Medicines.Add(medicineRecord);
                }
                list.Add(record);
            }
            return list;
        }

        //Получение списка путешествий с расшифровкой по экскурсиям и гидам
        public List<ReportVisitsViewModel> GetVisitAnimalsMedicines(ReportVisitBindingModel model)
        {
            var visits = visitStorage.GetFilteredList(new VisitBindingModel
            {
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                ClientId = model.ClientId
            });

            var medicines = medicineDimamicStorage.GetFullList();

            var visitAnimalsMedicines = new List<ReportVisitsViewModel>();

            foreach (var visit in visits)
            {
                foreach (var visitAnimal in visit.Animals)
                {
                    foreach (var medicine in medicines)
                    {
                        
                            if (medicine.AnimalId == visitAnimal.Key)
                            {
                                var animal = animalStorage.GetElement(new AnimalBindingModel
                                {
                                    Id = medicine.AnimalId
                                });

                                visitAnimalsMedicines.Add(new ReportVisitsViewModel
                                {
                                    Date = visit.Date,
                                    AnimalName = animal.Name,
                                    MedicineName = medicine.MedicineName
                                });
                            }
                        
                    }
                }
            }
            return visitAnimalsMedicines;
        }

        public void SaveVisitMedicinesToWord(ReportVisitBindingModel model)
        {
            ClientSaveToWord.CreateDoc(new ClientWordExcelInfo
            {
                FileName = model.FileName,
                Title = "Список медикаментов по выбранным визитам",
                VisitMedicines = GetVisitMedicines(model.Visits)
            });
        }

        public void SaveVisitMedicinesToExcel(ReportVisitBindingModel model)
        {
            ClientSaveToExcel.CreateDoc(new ClientWordExcelInfo
            {
                FileName = model.FileName,
                Title = "Список медикаментов по выбранным визитам",
                VisitMedicines = GetVisitMedicines(model.Visits)
            });
        }

        public void SaveVisitAnimalsMedicinesToPdf(ReportVisitBindingModel model)
        {
            ClientSaveToPdf.CreateDoc(new ClientPdfInfo
            {
                FileName = model.FileName,
                Title = "Список животных и медикаментов по выбранным визитам",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                VisitAnimalsMedicines = GetVisitAnimalsMedicines(model)
            });
        }
    }
}
