using Domain;

namespace UseCases;

public class AddTask
{
    private readonly AddTaskRequest request;
    private readonly ITaskRepository taskRepository;
    private readonly IClock clock;

    public AddTask(AddTaskRequest request, ITaskRepository taskRepository, IClock clock)
    {
        this.request = request ?? throw new ArgumentNullException(nameof(request));
        this.taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
        this.clock = clock ?? throw new ArgumentNullException(nameof(clock));
    }

    public IAddRequestResult Execute()
    {
        DateTimeOffset now = clock.OffsetNow;

        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return AddRequestResult.Fail("You are trying to add a task without a title.");
        }

        if (request.DueDate <= now)
        {
            return AddRequestResult.Fail("You are trying to add a task with a due date in the past.");
        }

        var task = new TodoTask(request.Title, request.DueDate);
        taskRepository.Add(task);
        return AddRequestResult.Success(task);
    }
}

public interface IClock
{
    DateTimeOffset OffsetNow { get; }
}

public interface ITaskRepository
{
    void Add(TodoTask task);
}

public class AddTaskRequest
{
    public string? Title { get; set; }
    public DateTimeOffset DueDate { get; set; }
}

public interface IAddRequestResult {
}

public static class AddRequestResult {
    public static IAddRequestResult Success(TodoTask task) {
        throw new NotImplementedException();
    }
    public static IAddRequestResult Fail(string description) {
        throw new NotImplementedException();
    }
}