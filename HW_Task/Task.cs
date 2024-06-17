using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueTime { get; set; }
        public int Priority {  get; set; }
        public Task() { }
        public Task(int id, string title, string description, DateTime dueTime, int priority)
        {
            Id = id;
            Title = title;
            Description = description;
            DueTime = dueTime;
            Priority = priority;
        }
    }
}
