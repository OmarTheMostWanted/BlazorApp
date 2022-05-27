namespace API.Services;

public abstract record OperationRecord();

public sealed record BinaryOperationRecord(BinaryOp BinaryOp , double x , double y, double res, DateTime DateTime);


public sealed record UnaryOperationRecord(BinaryOp BinaryOp , double x , double res, DateTime DateTime);