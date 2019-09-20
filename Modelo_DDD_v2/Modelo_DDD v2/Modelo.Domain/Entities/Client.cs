using Modelo.Domain.Services.Validators;
using System;

namespace Modelo.Domain.Entities
{
    public class Client
    {
        private Client() { }

        public Client(string name, string lastname, string email, string phone, DateTime birthDate, string address)
        {
            Name = name;
            LastName = lastname;
            Email = email;
            Phone = phone;
            BirthDate = birthDate;
            Address = address;
            CreatedOn = DateTime.UtcNow;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }

        public bool ChangeTheAddress(string endereco)
        {
            if (VerifyCreationTime(CreatedOn))
                return false;

            Address = endereco;
            UpdatedOn = DateTime.UtcNow;

            return true;
        }

        public bool ChangeThePhone(string telefone)
        {
            if (VerifyCreationTime(CreatedOn))
                return false;

            Phone = telefone;
            UpdatedOn = DateTime.UtcNow;

            return true;
        }

        public bool ChangeTheEmail(string email)
        {
            if (EmailValidator.Validate(email))
            {
                Email = email;
                UpdatedOn = DateTime.UtcNow;

                return true;
            }

            return false;
        }

        private bool VerifyCreationTime(DateTime startDate)
        {
            return startDate.AddDays(1).ToUniversalTime() >= DateTime.UtcNow;
        }
    }
}
