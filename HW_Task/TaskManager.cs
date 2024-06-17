using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace HW_Task
{
    public class TaskManager
    {
        public List<Task> tasks = new List<Task>();
        public void AddTask(Task task) { tasks.Add(task); }
        public void RemoveTask(int id) { tasks.RemoveAll(t => t.Id == id); }
        public void SaveToXml(string path)
        {
            var serializer = new XmlSerializer(typeof(List<Task>));
            using (var fs = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, tasks);
                Console.WriteLine("Лист задач записан в XML");
            }
        }
        public void LoadFromXml(string path)
        {
            var deserializer = new XmlSerializer(typeof(List<Task>));
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                List<Task> tasks = deserializer.Deserialize(fs) as List<Task>;
                if (tasks != null)
                {
                    Console.WriteLine("Загружено из XML");
                    foreach (var task in tasks)
                    {
                        Console.WriteLine($"ID:{task.Id} ,Title:{task.Title} , Description:{task.Description} , DueTime:{task.DueTime}" +
                            $" Priority:{task.Priority}  ");
                    }
                }
            }

        }

        public void SaveToJson(string path) 
        {
            var json = JsonConvert.SerializeObject(tasks);
            File.WriteAllText(path, json);
        }
        public void LoadToJson(string path) 
        {
            var json = File.ReadAllText(path);
            tasks = JsonConvert.DeserializeObject<List<Task>>(json);
            if (tasks != null) 
            {
                Console.WriteLine("Загружено из json");
                foreach(var task in tasks)
                {
                    Console.WriteLine($"ID:{task.Id} ,Title:{task.Title} , Description:{task.Description} , DueTime:{task.DueTime}" +
                            $" Priority:{task.Priority}  ");
                }
            }
        }

        public void SaveTaskAsCsv(string filePath)
        {
            var csv = new StringBuilder();
            csv.AppendLine("Id,Title,Description,DueDate,Priority");
            foreach (var task in tasks)
            {
                csv.AppendLine($"{task.Id},{task.Title},{task.Description},{task.DueTime},{task.Priority}");
            }
            File.WriteAllText(filePath, csv.ToString());
        }

        public void LoadTasksFromCsv(string filePath)
        {
            var lines = File.ReadAllLines(filePath).Skip(1);
            tasks.Clear();
            foreach (var line in lines)
            {
                var values = line.Split(',');
                tasks.Add(new Task(
                    int.Parse(values[0]),
                    values[1],
                    values[2],
                    DateTime.Parse(values[3]),
                    int.Parse(values[4])
                ));
            }
                Console.WriteLine("Загружено из csv");
                foreach( var task in tasks)
                {
                    Console.WriteLine($"ID:{task.Id} ,Title:{task.Title} , Description:{task.Description} , DueTime:{task.DueTime}" +
                            $" Priority:{task.Priority}  ");
                }
            }

        public IEnumerable<Task> FilterByPriorety(int priority)
        {
            return tasks.Where(t => t.Priority == priority);
        }

        public IEnumerable<Task> SortByDate()  
        {
            return tasks.OrderBy(t => t.DueTime);
        }

        public IEnumerable<IGrouping<int, Task>> GroupTasksByPriority()
        {
            return tasks.GroupBy(t => t.Priority);
        }

    }
    }


