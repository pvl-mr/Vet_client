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
        private readonly IEntityStorage<MedicineViewModel, MedicineBindingModel> medicineStorage;
        private readonly IReportStorage reportStorage;

        public ClientReportLogic(IEntityStorage<VisitViewModel, VisitBindingModel> visitStorage, IEntityStorage<AnimalViewModel, AnimalBindingModel> animalStorage, IEntityStorage<MedicineViewModel, MedicineBindingModel> medicineStorage, IReportStorage reportStorage)
        {
            this.visitStorage = visitStorage;
            this.animalStorage = animalStorage;
            this.medicineStorage = medicineStorage;
            this.reportStorage = reportStorage;
        }

        private List<ReportVisitMedicinesViewModel> GetVisitMedicines(List<VisitViewModel> selectedVisits)
        {
            var list = new List<ReportVisitMedicinesViewModel>();

            foreach (var visit in selectedVisits)
            {
                list.Add(reportStorage.GetVisitMedicines(new VisitBindingModel
                {
                    Id = visit.Id,
                    Date = visit.Date,
                    Comment = visit.Comment
                }));
            }
            return list;
        }

        //Получение списка визитов с расшифровкой по животным и медикаментом
        public List<ReportVisitsViewModel> GetVisitAnimalsMedicines(ReportVisitBindingModel model, int _ClientId)
        {
            var list = reportStorage.GetFullListVisits(model, _ClientId);
            return list;
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

        public void SaveVisitAnimalsMedicinesToPdf(ReportVisitBindingModel model, int _ClientId)
        {
            ClientSaveToPdf.CreateDoc(new ClientPdfInfo
            {
                FileName = model.FileName,
                Title = "Список животных и медикаментов по выбранным визитам",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                VisitAnimalsMedicines = GetVisitAnimalsMedicines(model, _ClientId)
            });
        }
    }
}
