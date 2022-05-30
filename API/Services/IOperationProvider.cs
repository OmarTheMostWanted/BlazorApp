using System.Diagnostics;

namespace API.Services;

public delegate double BinaryOperation(double x, double y);

public delegate double UnaryOperation(double x);

public interface IOperationProvider
{
    BinaryOperation GetOp(BinaryOp binaryOp);
    UnaryOperation GetOp(UnaryOp unaryOp);
}

public sealed class OperationProvider : IOperationProvider
{
    private static double Add(double x, double y) => x + y;

    private static double Fak(double x, double y)
    {
        if (x <= 0 | y <= 0) return 1;

        return x * y * Fak(x - 1, y - 1);
    }


    public BinaryOperation GetOp(BinaryOp binaryOp) => binaryOp switch
    {
        BinaryOp.ADD => Add,
        BinaryOp.DIV => (x, y) => x / y,
        BinaryOp.MUL => (x, y) => x * y,
        BinaryOp.SUB => (x, y) => x - y,
        BinaryOp.POW => Math.Pow,
        BinaryOp.FAK => Fak,
        _ => throw new ArgumentOutOfRangeException(nameof(binaryOp), binaryOp, "Wrong operator exception.")
    };

    private static double Fac(double x)
    {
        if (x <= 0) return 1;
        return x * Fac(x - 1);
    }

    public UnaryOperation GetOp(UnaryOp unaryOp) => unaryOp switch
    {
        UnaryOp.FAC => Fac,
        UnaryOp.REV => x => -1 * x,
        UnaryOp.SQRT => Math.Sqrt,
        _ => throw new ArgumentOutOfRangeException(nameof(unaryOp), unaryOp, "Wrong operator exception.")
    };
}