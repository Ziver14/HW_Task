namespace HW_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var taskManager = new TaskManager();

            Task task1 = new Task(1, "Выучить сохранение в XML", "Прочитать методичку", DateTime.Now.AddDays(1), 1);
            Task task2 = new Task(2, "Выучить сохранение в Json", "Прочитать методичку", DateTime.Now.AddDays(1), 2);
            Task task3 = new Task(3, "Сделать ДЗ", "Сделать ДЗ и выслать ссылку", DateTime.Now.AddDays(1), 1);

            taskManager.AddTask(task1);
            taskManager.AddTask(task2);
            taskManager.AddTask(task3);

            taskManager.SaveToXml("task.xml");
            taskManager.LoadFromXml("task.xml");
            Console.WriteLine();

            taskManager.SaveToJson("task.json");
            taskManager.LoadToJson("task.json");
            Console.WriteLine();

            taskManager.SaveTaskAsCsv("task.csv");
            taskManager.LoadTasksFromCsv("task.csv");
            Console.WriteLine();

            taskManager.RemoveTask(3);
            Console.WriteLine("Лист задач после удаления");
            taskManager.SaveToXml("task.xml");
            taskManager.LoadFromXml("task.xml");
            Console.WriteLine();

            var SortByPriority = taskManager.FilterByPriorety(1);
            foreach (var task in SortByPriority)
            {
                Console.WriteLine($"{task.Title} : {task.Priority}");
            }

            Console.WriteLine();

            var SortByDate = taskManager.SortByDate();
            foreach (var task in SortByDate)
            {
                Console.WriteLine($"{task.Title} : {task.DueTime}");
            }
            Console.WriteLine();

            var GroupByPriority = taskManager.GroupTasksByPriority();
            foreach (var group in GroupByPriority)
            {
                Console.WriteLine($"Priority: {group.Key}");
                foreach (var task in group)
                {
                    Console.WriteLine($"Task Title: {task.Title}");
                }
            }
        }
    }
}
