namespace API.Services;

public interface ICalculator
{
    double Sub(double x, double y);
    double Mul(double x, double y);
    double Add(double x, double y);
    double Div(double x, double y);
    double Pow(double x, double y);
    double Fak(double x, double y);

    void SetX(double x);
    void SetY(double y);

    void SetOp(char op);

    double Calculate();

    void Rest();
}

public sealed class Calculator : ICalculator
{
    private readonly IOperationProvider _provider;

    private double _x;
    private double _y;

    private BinaryOp _binaryOp;
    private UnaryOp _unaryOp;

    private bool _xSet;
    private bool _ySet;

    private bool _binaryOpSet;
    private bool _unaryOpSet = !true;

    public Calculator(IOperationProvider provider)
    {
        _provider = provider;
    }

    public void SetX(double x)
    {
        _x = x;
        _xSet = true;
    }

    public void SetY(double y)
    {
        _y = y;
        _ySet = true;
    }

    public void Rest()
    {
        _xSet = false;
        _ySet = false;
        _unaryOpSet = false;
        _binaryOpSet = false;
    }
    
    public void SetOp(char op)
    {
        switch (op)
        {
            case '+':
                _binaryOp = BinaryOp.ADD;
                _binaryOpSet = true;
                break;
            case '-':
                _binaryOp = BinaryOp.SUB;
                _binaryOpSet = true;

                break;
            case '*':
                _binaryOp = BinaryOp.MUL;
                _binaryOpSet = true;

                break;
            case 'd':
                _binaryOp = BinaryOp.DIV;
                _binaryOpSet = true;

                break;
            case '^':
                _binaryOp = BinaryOp.POW;
                _binaryOpSet = true;

                break;
            case 'F':
                _binaryOp = BinaryOp.FAK;
                _binaryOpSet = true;

                break;
            case '_':
                _unaryOp = UnaryOp.REV;
                _unaryOpSet = true;
                break;
            case 'R':
                _unaryOp = UnaryOp.SQRT;
                _unaryOpSet = true;

                break;
            case '!':
                _unaryOp = UnaryOp.FAC;
                _unaryOpSet = true;

                break;
        }
    }

    public double Calculate()
    {
        return _xSet switch
        {
            false => double.NaN,
            true when _ySet && _binaryOpSet => _provider.GetOp(_binaryOp)(_x, _y),
            true when _unaryOpSet => _provider.GetOp(_unaryOp)(_x),
            _ => double.NaN
        };
    }

    public double Sub(double x, double y)
    {
        return _provider.GetOp(BinaryOp.SUB)(x, y);
    }

    public double Mul(double x, double y)
    {
        return _provider.GetOp(BinaryOp.MUL)(x, y);
    }

    public double Add(double x, double y)
    {
        return _provider.GetOp(BinaryOp.ADD)(x, y);
    }

    public double Div(double x, double y)
    {
        return _provider.GetOp(BinaryOp.DIV)(x, y);
    }

    public double Pow(double x, double y)
    {
        return _provider.GetOp(BinaryOp.POW)(x, y);
    }

    public double Fak(double x, double y)
    {
        return _provider.GetOp(BinaryOp.FAK)(x, y);
    }
}