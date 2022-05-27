namespace API.Services;

public interface ICalculator
{
    double Min(double x, double y);
    double Mul(double x, double y);
    double Add(double x, double y);
    double Div(double x, double y);
    double Pow(double x, double y);
    double Sqrt(double x, double y);
    
}


public sealed class Calculator : ICalculator
{

    private readonly IOperationProvider _provider;
    
    
    
    
    public double Min(double x, double y)
    {
       return x - y;
    }

    public double Mul(double x, double y)
    {
        return x * y;
    }

    public double Add(double x, double y)
    {
        throw new NotImplementedException();
    }

    public double Div(double x, double y)
    {
        throw new NotImplementedException();
    }

    public double Pow(double x, double y)
    {
        throw new NotImplementedException();
    }

    public double Sqrt(double x, double y)
    {
        throw new NotImplementedException();
    }
}