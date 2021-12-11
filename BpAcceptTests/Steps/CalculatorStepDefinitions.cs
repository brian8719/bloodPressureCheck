using BPCalculator;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace BpAcceptTests.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        private readonly BloodPressure _testBP = new BloodPressure();

        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the SystolicValue is (.*)")]
        public void GivenSystolicValueIs(int number)
        {
            _testBP.Systolic = number;
        }

        [When("the Diastolic Value is (.*)")]
        public void GivenDiastolicValueIs(int number)
        {
            _testBP.Diastolic = number;
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(string result)
        {            
            _testBP.Category.ToString().Should().Be(result);
        }
    }
}
