Task task1 = new Task(() => { Console.WriteLine("First Task Start"); Thread.Sleep(15000); Console.WriteLine("First Task End"); });
Task task2 = new Task(() => { Console.WriteLine("Second Task Start"); Thread.Sleep(8000); Console.WriteLine("Second Task End"); });
Task task3 = new Task(() => { Console.WriteLine("Third Task Start"); Thread.Sleep(3000); Console.WriteLine("Third Task End"); });

//Task task2 = Task.Factory.StartNew(() => { Console.WriteLine("Second Task Start"); Thread.Sleep(3000); Console.WriteLine("Second Task End"); });
//Task task3 = Task.Run(() => { Console.WriteLine("Third Task Start"); Thread.Sleep(1000); Console.WriteLine("Third Task End"); }); 
// это просто варианты запуска таски
//task1.Start();
//task2.Start();
//task3.Start();

//Task task2 = Task.Factory.StartNew(() => { Console.WriteLine("Second Task Start"); Thread.Sleep(3000); Console.WriteLine("Second Task End"); });
//Task task3 = Task.Run(() => { Console.WriteLine("Third Task Start"); Thread.Sleep(1000); Console.WriteLine("Third Task End"); });

//task1.Wait();   // ожидаем завершения задачи task1 останавливая основной поток
//task2.Wait();   // ожидаем завершения задачи task2
//task3.Wait();   // ожидаем завершения задачи task3

Task t = CalcAsync.TaskPrintSeqAsync(3);
t.TrackStatus();

public static class CalcAsync
{
    public static TaskStatus _TaskStatus { get; set; } = default;

    public async static Task TaskPrintSeqAsync(int n)
    {
        await Task.Run(() => { Console.WriteLine($"Start task. Status: {_TaskStatus}"); Thread.Sleep(n * 1000); Console.WriteLine($"End task. Status: {_TaskStatus}"); });
    }
    public static void PrintStatusIfChanged(this Task task, TaskStatus taskStatus)
    {
        if (taskStatus != _TaskStatus)
        {
            Console.WriteLine(taskStatus);
            _TaskStatus = task.Status;
        }
    }
    public static void TrackStatus(this Task task)
    {
        do
        {
            task.PrintStatusIfChanged(task.Status);
        } while (!task.IsCompleted);
    }
}


