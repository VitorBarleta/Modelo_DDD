using Modelo.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Modelo.Api.ViewModels.Extensions
{
    public static class ClientDetailsViewModelExtension
    {
        public static ClientDetailsViewModel ToViewModel(this Client client)
        {
            return new ClientDetailsViewModel()
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                LastName = client.LastName,
                Address = client.Address,
                BirthDate = client.BirthDate,
                Phone = client.Phone
            };
        }

        public static IEnumerable<ClientDetailsViewModel> ToViewModel(this IEnumerable<Client> cliente)
        {
            List<ClientDetailsViewModel> array = new List<ClientDetailsViewModel>();
            foreach (var client in cliente)
            {
                array.Add(client.ToViewModel());
            }

            return array.AsEnumerable();
        }
    }
}
