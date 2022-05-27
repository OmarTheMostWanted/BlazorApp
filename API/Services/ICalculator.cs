namespace API.Services;

public interface ICalculator
{
    double Sub(double x, double y);
    double Mul(double x, double y);
    double Add(double x, double y);
    double Div(double x, double y);
    double Pow(double x, double y);
    double Fak(double x, double y);

}


public sealed class Calculator : ICalculator
{
    
    private readonly IOperationProvider _provider;

    public Calculator(IOperationProvider provider)
    {
        _provider = provider;
    }
    
    public double Sub(double x, double y)
    {
        return _provider.GetOp(BinaryOp.SUB)(x ,y);
    }

    public double Mul(double x, double y)
    {
        return _provider.GetOp(BinaryOp.MUL)(x ,y);
    }

    public double Add(double x, double y)
    {
        return _provider.GetOp(BinaryOp.ADD)(x ,y);
    }

    public double Div(double x, double y)
    {
        return _provider.GetOp(BinaryOp.DIV)(x ,y);
    }

    public double Pow(double x, double y)
    {
        return _provider.GetOp(BinaryOp.POW)(x ,y);
    }

    public double Fak(double x, double y)
    {
        return _provider.GetOp(BinaryOp.FAK)(x, y);
    }

}