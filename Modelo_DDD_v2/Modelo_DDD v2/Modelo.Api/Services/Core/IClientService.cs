using Modelo.Domain.Entities;
using Modelo.Domain.Services;
using System.Collections.Generic;

namespace Modelo.Api.Services.Core
{
    public interface IClientService : IServiceBase<Client>
    {
        Client Find(int id);
        IEnumerable<Client> FindAll(int id);
        int UpdateEmail(int id, string email);
        int UpdatePhone(int id, string phone);
        int UpdateAddress(int id, string address);
    }
}
