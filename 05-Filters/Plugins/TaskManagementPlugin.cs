using Microsoft.SemanticKernel;
using System.ComponentModel;

public class TaskManagementPlugin
{
    public class TaskModel
    {
        public int Id { get; set; }
    }

    [KernelFunction("complete_task")]
    [Description("Marks a task as completed by its ID.")]
    [return: Description("The updated task, or null if not found.")]
    public TaskModel? CompleteTask(int id)
    {
        return new TaskModel() { Id = id }; // Simulate task completion logic
    }

    [KernelFunction("get_critical_tasks")]
    [Description("Gets a list of all tasks marked as 'Critical' priority.")]
    [return: Description("A list of critical tasks.")]
    public List<TaskModel> GetCriticalTasks()
    {
        return new List<TaskModel>
        {
            new TaskModel { Id = 1 },
            new TaskModel { Id = 2 },
            new TaskModel { Id = 3 }
        }; // Simulate fetching critical tasks
    }
}