using Modelo.Api.Services.Core;
using Modelo.Api.ViewModels;
using Modelo.Domain.Entities;
using Modelo.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Modelo.Api.Services
{
    public class ClienteService : IClientService
    {
        private readonly IRepositoryBase<Client> _repository;

        public ClienteService(IRepositoryBase<Client> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public int Add(Client entity)
        {
            if (_repository.Find(x => x.Email == entity.Email) != null)
                throw new InvalidOperationException();

            if (_repository.Find(x => x.Phone == entity.Phone) != null)
                throw new InvalidOperationException();

            _repository.Add(entity);

            return _repository.SaveChanges();
        }

        public Client Find(int id)
        {
            return FindByExpression(x => x.Id == id);
        }

        public IEnumerable<Client> FindAll(int id)
        {
            return FindAllByExpression(x => x.Id == id);
        }

        public IEnumerable<Client> FindAllByExpression(Expression<Func<Client, bool>> expression)
        {
            return _repository.FindAll(expression);
        }

        public Client FindByExpression(Expression<Func<Client, bool>> expression)
        {
            return _repository.Find(expression);
        }

        public IEnumerable<Client> GetAll()
        {
            return _repository.GetAll();
        }

        public int Update(Client entity)
        {
            try
            {
                _repository.Update(entity);

                return _repository.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateEmail(int id, string email)
        {
            var client = _repository.Find(x => x.Id == id);

            if (client.Email == email)
                throw new ArgumentException();

            var result = client.ChangeTheEmail(email);

            if (!result)
                throw new InvalidOperationException();

            return Update(client);
        }

        public int UpdatePhone(int id, string phone)
        {
            var client = _repository.Find(x => x.Id == id);

            if (client.Phone == phone)
                throw new ArgumentException();

            var result = client.ChangeThePhone(phone);

            if (!result)
                throw new InvalidOperationException();

            return Update(client);
        }

        public int UpdateAddress(int id, string address)
        {
            var client = _repository.Find(x => x.Id == id);

            if (client.Address == address)
                throw new ArgumentException();

            var result = client.ChangeTheAddress(address);

            if (!result)
                throw new InvalidOperationException();

            return Update(client);
        }
    }
}
