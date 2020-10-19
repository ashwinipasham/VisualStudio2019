using NUnit.Framework;
using System;

namespace NUnitTestProject1
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void RandomTestDataGenerator()
        {
            Random r = new Random();

            String fullName = $"FullName{r.Next()}";
            String firstName = $"FirstName{r.Next()}";
            String lastName = $"LastName{r.Next()}";
            String email = $"Email{r.Next()}@gmail.com";
            String address = $"Address{r.Next()}";
            String phone = r.Next(1000000000).ToString().PadRight(10, '0'); 


            Console.WriteLine("FullName: " + fullName);
            Console.WriteLine("FirstName: " + firstName);
            Console.WriteLine("LastName: " + lastName);
            Console.WriteLine("Email: " + email);
            Console.WriteLine("Phone: " + phone);
            Console.WriteLine("Address: " + address);
            //Assert.Pass();
        }

        [Test]
        public void RandomTestDataGenerator1()
        {
            Random r1 = new Random();
            Console.WriteLine("Second test: "+ r1.Next());
            Assert.Pass();
        }
    }
}