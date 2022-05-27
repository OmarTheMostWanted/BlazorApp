using System.Diagnostics;

namespace API.Services;

public delegate double Operation(double x, double y);

public interface IOperationProvider
{
    
    
    Operation GetOp(Op op);
}

public sealed class OperationProvider : IOperationProvider
{
    private static double Add(double x, double y) => x + y;

    private static double Fuck(double x, double y)
    {
        if (x <= 0 | y <= 0) return 1;

        return x * y * Fuck(x - 1, y - 1);
    }

    

    public Operation GetOp(Op op) => op switch
    {
        Op.ADD => Add,
        Op.DIV => (x, y) => x / y,
        Op.MUL => (x, y) => x * y,
        Op.SUB => (x, y) => x - y,
        Op.POW => (x, y) => Math.Pow(x , y),
        Op.FAC => Fuck
    }
    
}
}