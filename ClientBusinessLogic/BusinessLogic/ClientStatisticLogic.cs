using ClientBusinessLogic.BindingModels;
using ClientBusinessLogic.Interfaces;
using ClientBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ClientBusinessLogic.BusinessLogic
{
    public class ClientStatisticLogic
    {
        private readonly IEntityStorage<VisitViewModel, VisitBindingModel> visitStorage;
        private readonly IEntityStorage<ServiceViewModel, ServiceBindingModel> serviceStorage;

        public ClientStatisticLogic(IEntityStorage<VisitViewModel, VisitBindingModel> visitStorage, IEntityStorage<ServiceViewModel, ServiceBindingModel> serviceStorage)
        {
            this.visitStorage = visitStorage;
            this.serviceStorage = serviceStorage;
        }

        public List<Tuple<string, int>> GetCountByMonths(int clientId)
        {
            var listAllVisits = new List<VisitViewModel>();

            if (clientId != 0)
            {
                listAllVisits = visitStorage.GetFilteredList(new VisitBindingModel
                {
                    ClientId = clientId
                });
            }
            else
            {
                listAllVisits = visitStorage.GetFullList();
            }

            var countByMonths = listAllVisits.OrderBy(rec => rec.Date.Month).GroupBy(rec => new { rec.Date.Month })
                .Select(rec => new Tuple<string, int>(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(rec.Key.Month), rec.Count())).ToList();

            return countByMonths;
        }

        public List<Tuple<string, int>> GetAnimalsInfo(int clinetId)
        {
            var listAllVisits = visitStorage.GetFullList().Where(rec => rec.ClientId == clinetId).ToList();

            var result = new List<Tuple<string, int>>();

            foreach (var visit in listAllVisits)
            {
                foreach (var animal in visit.Animals)
                {
                    var record = result.Where(rec => rec.Item1.Equals(animal.Value)).Select(rec => new Tuple<string, int>(rec.Item1, rec.Item2)).ToList();

                    if (record.Count > 0)
                    {
                        result.Remove(record[0]);
                        record[0] = new Tuple<string, int>(animal.Value.petName, record[0].Item2 + 1);
                        result.Add(record[0]);
                    }

                    else
                    {
                        result.Add(new Tuple<string, int>(animal.Value.ToString(), 1));
                    }
                }
            }
            foreach (var obj in result)
            {
                Console.WriteLine("Item1 " + obj.Item1);
                Console.WriteLine("Item2 " + obj.Item2);
                Console.WriteLine("------------------");
            }
            
            return result.OrderByDescending(rec => rec.Item2).Take(5).ToList();
        }

        public List<Tuple<string, int>> GetCountriesInfo(int clientId)
        {
            var listAllVisits = visitStorage.GetFilteredList(new VisitBindingModel
            {
                ClientId = clientId
            });

            var result = new List<Tuple<string, int>>();

            foreach (var visit in listAllVisits)
            {
                foreach (var visitService in visit.Services)
                {
                    var service = serviceStorage.GetElement(new ServiceBindingModel
                    {
                        Id = visitService.Key
                    });

                    var record = result.Where(rec => rec.Item1.Equals(service.Name)).Select(rec => new Tuple<string, int>(rec.Item1, rec.Item2)).ToList();

                    if (record.Count > 0)
                    {
                        result.Remove(record[0]);
                        record[0] = new Tuple<string, int>(service.Name, record[0].Item2 + 1);
                        result.Add(record[0]);
                    }

                    else
                    {
                        result.Add(new Tuple<string, int>(service.Name, 1));
                    }
                }
            }
            return result.OrderByDescending(rec => rec.Item2).ToList();
        }
    }
}
