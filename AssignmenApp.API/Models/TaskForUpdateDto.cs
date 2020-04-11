using System;

namespace AssignmenApp.API.Models
{
    public class TaskForUpdateDto
    {
       public int Id { get; set; }
        public string TaskName { get; set; }
        public DateTime FinishDate { get; set; }
        public string Priority { get; set; }
    }
}