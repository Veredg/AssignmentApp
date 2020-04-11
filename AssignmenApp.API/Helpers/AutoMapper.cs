using AssignmenApp.API.Entities;
using AssignmenApp.API.Models;
using AutoMapper;

namespace AssignmenApp.API.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<User, UserForRegisterDto>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<UserForLoginDto, User>();
            CreateMap<MyTask, TaskForUserDto>();
            CreateMap<TaskForUserDto, MyTask>();
            CreateMap<TaskForUpdateDto, MyTask>();

        }
    }
}