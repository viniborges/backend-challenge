namespace MotoFleet.SharedKernel;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}
