using System;
using AssignmenApp.API.Enums;

namespace AssignmenApp.API.Models
{
    public class TaskForUserDto
    {
    
        public string TaskName { get; set; }
        public DateTime FinishDate { get; set; }
        public Priority Priority { get; set; }
        public int UserId { get; set; }
    }
}