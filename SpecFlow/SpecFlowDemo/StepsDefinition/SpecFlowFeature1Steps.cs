using Gherkin.Ast;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowDemo.Featurefiles
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int numbers)
        {
            Console.WriteLine(numbers); 
        }
        
        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int secondNum)
        {
            Console.WriteLine(secondNum);
        }
        
        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            Console.WriteLine("Performing the ADD operation");
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            if(result == 120)
            Console.WriteLine("The test has been PASSED");
            else
                 Console.WriteLine("The test has been FAILED");
        }

       
       

    }
}
