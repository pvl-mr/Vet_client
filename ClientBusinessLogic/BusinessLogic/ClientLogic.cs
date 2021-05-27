using ClientBusinessLogic.BindingModels;
using ClientBusinessLogic.Interfaces;
using ClientBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ClientBusinessLogic.BusinessLogic
{
    public class ClientLogic
    {
        private readonly IEntityStorage<ClientViewModel, ClientBindingModel> _clientStorage;

        public ClientLogic(IEntityStorage<ClientViewModel, ClientBindingModel> clientStorage)
        {
            _clientStorage = clientStorage;
        }

        public List<ClientViewModel> GetFullList()
        {
            return _clientStorage.GetFullList();
        }
        public List<ClientViewModel> GetFilteredList(ClientBindingModel binding)
        {
            return _clientStorage.GetFilteredList(binding);
        }
        public ClientViewModel GetElement(ClientBindingModel binding)
        {
            return _clientStorage.GetElement(binding);
        }

        public void CreateOrUpdate(ClientBindingModel binding)
        {
            var element = _clientStorage.GetElement(new ClientBindingModel { Email = binding.Email });


            if (element != null && element.Id != binding.Id)
                throw new Exception("Такой пользователь уже зарегистрирован");

            if (binding.Id >= 1)
                _clientStorage.Update(binding);
            else
                _clientStorage.Insert(binding);
        }

        public void Delete(ClientBindingModel binding)
        {
            var element = _clientStorage.GetElement(new ClientBindingModel { Id = binding.Id });

            if (element == null)
                throw new Exception($"Элемент c id {binding.Id} найден");

            _clientStorage.Delete(binding);
        }
    }
}
