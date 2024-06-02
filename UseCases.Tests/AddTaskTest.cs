namespace UseCases.Tests;

public class AddTaskTest
{
    [Fact]
    public void Creation_RequestWithEmptyTitle_Fails()
    {
        IClock fakeClock = new StoppedClock();
        ITaskRepository fakeRepository = new FakeTaskRepository();

        var request = new AddTaskRequest 
        {
            Title = "",
            DueDate = fakeClock.OffsetNow.AddDays(1)
        };
        
    }
}
