using TechTalk.SpecFlow;

namespace SampleSpecification.Specs.Calculator;

[Binding]
public class Calculator
{
    private readonly SampleApplication.Core.Calculator _calculator;
    private int _total;

    public Calculator() => _calculator = new SampleApplication.Core.Calculator();

    [Given(@"the first number is (.*)")]
    public void GivenTheFirstNumberIs(int p0)
    {
        _calculator.SetFirstNumber(p0);
    }

    [Given(@"the second number is (.*)")]
    public void GivenTheSecondNumberIs(int p0)
    {
        _calculator.SetSecondNumber(p0);
    }

    [When(@"the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        _total = _calculator.Add();
    }

    [Then(@"the result should be (.*)")]
    public void ThenTheResultShouldBe(int p0)
    {
        Assert.Equal(p0, _total);
    }
}