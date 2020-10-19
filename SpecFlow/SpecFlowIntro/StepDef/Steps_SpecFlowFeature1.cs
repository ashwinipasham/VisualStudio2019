using System;
using TechTalk.SpecFlow;

namespace SpecFlowIntro.StepDef
{
    [Binding]
    public class Steps_SpecFlowFeature1
    {
        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int FisrtNum)
        {
            Console.WriteLine(FisrtNum); 
        }
        
        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int secondNum)
        {
            Console.WriteLine(secondNum);
        }
        
        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            Console.WriteLine("performing Add operation");
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            if(result == 120)
                Console.WriteLine("The test has PASSED");
            else
                Console.WriteLine("The test has FAILED");
        }
    }
}
