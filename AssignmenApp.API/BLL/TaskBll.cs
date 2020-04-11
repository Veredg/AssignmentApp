using System.Collections.Generic;
using System.Threading.Tasks;
using AssignmenApp.API.BLL.IBLL;
using AssignmenApp.API.Data;
using AssignmenApp.API.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AssignmenApp.API.Models;

namespace AssignmenApp.API.BLL
{
    public class TaskBll: ITaskBll
    {
         private readonly IAssignmentRepository<User> _userRepo;
        private readonly IAssignmentRepository<MyTask> _taskRepo;
   public TaskBll (IAssignmentRepository<User> userRepo, IAssignmentRepository<MyTask> taskRepo){
        _userRepo = userRepo;
        _taskRepo = taskRepo;

   }
       public  async Task<IEnumerable<MyTask>> GetTasksListAsync(string Email)
        {

           
        IEnumerable<MyTask> UsertTasks =  await (from tasks in _taskRepo.Queryable()
                                         join user in _userRepo.Queryable() 
                                         on  tasks.UserId equals user.Id
                                         where user.Email == Email
                                         select tasks).ToListAsync();
 

        return (UsertTasks);
        
        }

        public async Task<bool> UpdateTaskAsync(TaskForUpdateDto task)
        {
            MyTask taskForUpdate = await _taskRepo.Queryable().Where(p => p.Id == task.Id).FirstOrDefaultAsync();
            _taskRepo.Update(taskForUpdate);
            bool retVal = await _taskRepo.SaveChangesAsync() > 0;
            return retVal;
        }

        public async  Task<bool> InsertTaskAsync(TaskForUserDto task)
        {
           
            MyTask taskForInsert = new MyTask
                    {  
                        TaskName = task.TaskName,
                        FinishDate = task.FinishDate,
                        Priority = task.Priority,
                        UserId = task.UserId
                    };
          await _taskRepo.InsertAsync(taskForInsert);
          
          return await _taskRepo.SaveChangesAsync() > 0;  
        }
        
        public async Task<bool> RemoveTaskAsync(int Id)
        {
           MyTask taskForRemove = await _taskRepo.Queryable().Where(t => t.Id == Id).FirstOrDefaultAsync();
            _taskRepo.Remove(taskForRemove);
            bool retVal = await _taskRepo.SaveChangesAsync() > 0;
            return retVal;
        }

      public bool EmailIsValid(string Email) {
        try {
        var addr = new System.Net.Mail.MailAddress(Email);
        return addr.Address == Email;
    }
    catch {
        return false;
    }

    }

    }
}