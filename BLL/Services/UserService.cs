using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System.Collections.Generic;

namespace BLL.Services
{
    public class UserService
    {
        DataAccessFactory factory;

        public UserService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        //CRUD Service
        public bool Create(UserDTO dto)
        {
            var data = MapperConfig.GetMapper().Map<User>(dto);
            return factory.UserData().Create(data);
        }

        public List<UserDTO> Get()
        {
            var data = factory.UserData().Get();
            return MapperConfig.GetMapper().Map<List<UserDTO>>(data);
        }

        public UserDTO Get(int id)
        {
            return MapperConfig.GetMapper()
                .Map<UserDTO>(factory.UserData().Get(id));
        }

        public bool Update(UserDTO dto)
        {
            var data = MapperConfig.GetMapper().Map<User>(dto);
            return factory.UserData().Update(data);
        }

        public bool Delete(int id)
        {
            return factory.UserData().Delete(id);
        }

        //Feature Services

        public List<UserDTO> SearchByNameOrEmail(string searchText)
        {
            var data = factory.UserFeature().SearchByNameOrEmail(searchText);
            return MapperConfig.GetMapper().Map<List<UserDTO>>(data);
        }

        public List<UserDTO> GetByRole(string role)
        {
            var data = factory.UserFeature().GetByRole(role);
            return MapperConfig.GetMapper().Map<List<UserDTO>>(data);
        }

        public bool ChangeUserRole(ChangeUserRoleDTO dto)
        {
            return factory.UserFeature()
                          .ChangeRole(dto.UserId, dto.NewRole);
        }

        public Dictionary<string, int> GetUserCount()
        {
            return factory.UserFeature()
                          .GetUserCountByRole();
        }
    }
}
