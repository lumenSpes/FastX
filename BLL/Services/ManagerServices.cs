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
    public class ManagerServices
    {
        private static readonly IMapper mapper;

        static ManagerServices() 
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Manager, ManagerDTO>();
            });
            mapper = cfg.CreateMapper();
        }


        public static List<ManagerDTO> Get()
        {
            var data = DataAccessFactory.ManagerData().Read();
            var mapped = mapper.Map<List<ManagerDTO>>(data);
            return mapped;
        }


        public static ManagerDTO GetById(int id)
        {
            var data = DataAccessFactory.ManagerData().Read(id);
            var mapped = mapper.Map<ManagerDTO>(data);
            return mapped;
        }

        public static ManagerDTO Create(ManagerDTO managerDTO)
        {
            var manager = mapper.Map<Manager>(managerDTO);
            var data = DataAccessFactory.ManagerData().Create(manager);
            return mapper.Map<ManagerDTO>(data);
        }

        public static ManagerDTO Update(ManagerDTO managerDTO)
        {
            var manager = mapper.Map<Manager>(managerDTO);
            var data = DataAccessFactory.ManagerData().Update(manager);
            return mapper.Map<ManagerDTO>(data);
        }

        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.ManagerData().Delete(id);
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
