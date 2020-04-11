using System;
using AssignmenApp.API.Enums;

namespace AssignmenApp.API.Entities
{
    public class MyTask
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public DateTime FinishDate { get; set; }
        public Priority Priority { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}