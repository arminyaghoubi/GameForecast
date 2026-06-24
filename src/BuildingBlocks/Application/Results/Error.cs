namespace BuildingBlocks.Application.Results;

public sealed record Error(string Message)
{
    public static readonly Error None = new(string.Empty);
}