namespace SampleApplication.Core;

public class Calculator
{
    private int _number1;
    private int _number2;
    
    public void SetFirstNumber(int number) => _number1 = number;
    public void SetSecondNumber(int number) => _number2 = number;

    public int Add() => _number1 + _number2;
}