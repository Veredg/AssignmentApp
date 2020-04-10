using System;
using AssignmenApp.API.Enums;

namespace AssignmenApp.API.Models
{
    public class TaskForUserDto
    {
         public int Id { get; set; }
        public string TaskName { get; set; }
        public DateTime FinishDate { get; set; }
        public string Priority { get; set; }
    }
}