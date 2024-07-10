using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UsersServices
    {
        private static readonly IMapper mapper;

        static UsersServices()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UsersDTO>();
            });
            mapper = cfg.CreateMapper();
        }

        public static List<UsersDTO> Get()
        {
            var data = DataAccessFactory.UsersData().Read();
            var mapped = mapper.Map<List<UsersDTO>>(data);
            return mapped;
        }


        public static UsersDTO GetById(int id)
        {
            var data = DataAccessFactory.UsersData().Read(id);
            var mapped = mapper.Map<UsersDTO>(data);
            return mapped;
        }

        public static UsersDTO Create(UsersDTO usersDTO)
        {
            var user = mapper.Map<User>(usersDTO);
            var data = DataAccessFactory.UsersData().Create(user);
            return mapper.Map<UsersDTO>(data);
        }

        public static UsersDTO Update(UsersDTO usersDTO)
        {
            var user = mapper.Map<User>(usersDTO);
            var data = DataAccessFactory.UsersData().Update(user);
            return mapper.Map<UsersDTO>(data);
        }

        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.UsersData().Delete(id);
            if (isSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
