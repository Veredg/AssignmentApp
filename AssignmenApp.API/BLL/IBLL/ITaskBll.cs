using System.Collections.Generic;
using System.Threading.Tasks;
using AssignmenApp.API.Entities;
using AssignmenApp.API.Models;

namespace AssignmenApp.API.BLL.IBLL
{
    public interface ITaskBll
    {
        Task<IEnumerable<MyTask>> GetTasksListAsync(string Email);
        Task<bool> UpdateTaskAsync(TaskForUpdateDto task);
        Task<bool> InsertTaskAsync(TaskForUserDto task);
        Task<bool> RemoveTaskAsync(int Id);
        bool EmailIsValid(string Email);

    }
    }
}