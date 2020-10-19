using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1
{
    class FakerDataGenerator
    {
        [Test]
        public void RandomTestDataGenerator()
        {

        }


        [Test]
        public void FakeDataGenerator()
        {
            //creating random data using faker API 
            String fullname = Faker.Name.FullName();
            String firstname = Faker.Name.First();
            String phonNumber = Faker.Phone.Number();
            String address = Faker.Address.StreetAddress();
            String email = Faker.Internet.Email();
            String randomSentence= Faker.Lorem.Sentence();


            //Feeding data to print output
            Console.WriteLine("FullName: " + fullname);
            Console.WriteLine("FirstName: " + firstname);
            Console.WriteLine("Email: " + email);
            Console.WriteLine("Phone: " + phonNumber);
            Console.WriteLine("Address: " + address);
            Console.WriteLine("Random Sentence: " + randomSentence);

        }


    }
}
