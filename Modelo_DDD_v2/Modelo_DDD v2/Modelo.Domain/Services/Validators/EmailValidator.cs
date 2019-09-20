namespace Modelo.Domain.Services.Validators
{
    public static class EmailValidator
    {
        public static bool Validate(string email)
        {
            return email.Contains("@gmail.com") ? true : false;
        }
    }
}
