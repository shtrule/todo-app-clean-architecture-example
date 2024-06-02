namespace UseCases.Tests;

internal class StoppedClock : IClock
{
    private readonly DateTimeOffset dateTime;

    public StoppedClock()
    {
        dateTime = DateTimeOffset.Now;
    }

    public StoppedClock(DateTimeOffset dateTime)
    {
        this.dateTime = dateTime;
    }
 
    public DateTimeOffset OffsetNow => dateTime;
}
