using Modelo.Api.ViewModels;
using Modelo.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Modelo.Api.Application.Extensions
{
    public static class ClientViewModelExtension
    {
        public static ClientViewModel ToViewModel(this Client cliente)
        {
            return new ClientViewModel()
            {
                Id = cliente.Id,
                Name = cliente.Name,
                Email = cliente.Email,
                LastName = cliente.LastName,
                Phone = cliente.Phone
            };
        }

        public static IEnumerable<ClientViewModel> ToViewModel(this IEnumerable<Client> clientes)
        {
            List<ClientViewModel> array = new List<ClientViewModel>();
            foreach(var cliente in clientes)
            {
                array.Add(cliente.ToViewModel());
            }

            return array.AsEnumerable();
        }
    }
}
