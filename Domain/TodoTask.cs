namespace Domain;


public class TodoTask
{
    public string Title { get; private set; }
    public DateTimeOffset DueDate { get; private set; }

    public bool Finished { get; private set; }

    public void Postpone(int days) {
        if (Finished) {
            throw new InvalidOperationException("You cannot postpone a finished task.");
        }

        if (days <= 0) {
            throw new ArgumentOutOfRangeException(nameof(days), "You cannot postpone a task for less than 1 day.");
        }

        DueDate = DueDate.AddDays(days);
    }

    public void Complete() {
        Finished = true;
    }

    public TodoTask(string title, DateTimeOffset dueDate)
    {
        Title = title;
        DueDate = dueDate;
    }
}