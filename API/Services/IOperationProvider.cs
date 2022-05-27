using System.Diagnostics;

namespace API.Services;

public delegate double Operation(double x, double y);

public interface IOperationProvider
{
    Operation GetOp(BinaryOp binaryOp);
}

public sealed class OperationProvider : IOperationProvider
{
    private static double Add(double x, double y) => x + y;

    private static double Fak(double x, double y)
    {
        if (x <= 0 | y <= 0) return 1;

        return x * y * Fak(x - 1, y - 1);
    }


    public Operation GetOp(BinaryOp binaryOp) => binaryOp switch
    {
        BinaryOp.ADD => Add,
        BinaryOp.DIV => (x, y) => x / y,
        BinaryOp.MUL => (x, y) => x * y,
        BinaryOp.SUB => (x, y) => x - y,
        BinaryOp.POW => Math.Pow,
        BinaryOp.FAK => Fak,
        _ => throw new ArgumentOutOfRangeException(nameof(binaryOp), binaryOp, "Wrong operator exception.")
    };
}