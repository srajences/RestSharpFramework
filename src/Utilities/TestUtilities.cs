using System;
using Faker;
public class TestUtilities{
    public static string GenerateFirstName()
    {
        string firstName = Faker.Name.First();
        return firstName;
    }
    public static string GenerateLastName()
    {
        string lastName = Faker.Name.Last();
        return lastName;
    }
        public static string GenerateEmail(string firstName)
    {
        Random random = new Random();
        int randomNumber = random.Next(1000,9999);
        string email = $"{firstName}{randomNumber}@gmail.com";
        return email;
    }
}