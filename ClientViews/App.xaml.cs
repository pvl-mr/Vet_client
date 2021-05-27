using System;
using System.Configuration;
using System.Windows;
using ClientBusinessLogic.BusinessLogic;
using ClientBusinessLogic.HelperModels;
using ClientBusinessLogic.Interfaces;
using ClientBusinessLogic.ViewModels;
using VetclinicStorage.EntityStorages;
using Unity;
using Unity.Lifetime;
using ClientBusinessLogic.BindingModels;

namespace ClientViews
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ClientViewModel Client { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var container = BuildUnityContainer();

            MailLogic.MailConfig(new MailConfig
            {
                SmtpClientHost = ConfigurationManager.AppSettings["SmtpClientHost"],
                SmtpClientPort = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpClientPort"]),
                MailLogin = ConfigurationManager.AppSettings["MailLogin"],
                MailPassword = ConfigurationManager.AppSettings["MailPassword"],
                MailName = ConfigurationManager.AppSettings["MailName"]
            });

            var authWindow = container.Resolve<WindowSingIn>();
            authWindow.Show();
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();

            currentContainer.RegisterType<IEntityStorage<MedicineViewModel, MedicineBindingModel>, MedicineStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEntityStorage<MedicineDinamicViewModel, MedicineDinamicBindingModel>, MedicineDinamicStorage>(new HierarchicalLifetimeManager());
            /*
             currentContainer.RegisterType<IEntityStorage<RecommendationViewModel, RecommendationBindingModel>, RecommendationStorage>(new HierarchicalLifetimeManager());
             currentContainer.RegisterType<IEntityStorage<DoctorViewModel, DoctorBindingModel>, DoctorsStorage>(new HierarchicalLifetimeManager());
 */
            currentContainer.RegisterType<IEntityStorage<ServiceViewModel, ServiceBindingModel>, ServiceStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEntityStorage<ClientViewModel, ClientBindingModel>, ClientStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEntityStorage<AnimalViewModel, AnimalBindingModel>, AnimalStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEntityStorage<VaccinationViewModel, VaccinationBindingModel>, VaccinationStorage>(new HierarchicalLifetimeManager());
           currentContainer.RegisterType<IEntityStorage<VisitViewModel, VisitBindingModel>, VisitStorage>(new HierarchicalLifetimeManager());
           currentContainer.RegisterType<IEntityStorage<MedicineDinamicViewModel, MedicineDinamicBindingModel>, MedicineDinamicStorage>(new HierarchicalLifetimeManager());
           currentContainer.RegisterType<IReportStorage, ReportStorage>(new HierarchicalLifetimeManager());



            /*currentContainer.RegisterType<DoctorLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ServicesLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<RecommendationLogic>(new HierarchicalLifetimeManager());*/
            /*currentContainer.RegisterType<MedicineLogic>(new HierarchicalLifetimeManager());*/
            currentContainer.RegisterType<ClientReportLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<VisitLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<AnimalLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ServiceLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<MailLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ClientReportLogic>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
