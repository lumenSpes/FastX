using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class BranchServices
    {
        private static readonly IMapper mapper;

        static BranchServices()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Branch, BranchDTO>();
            });
            mapper = cfg.CreateMapper();
        }

        public static List<BranchDTO> Get()
        {
            var data = DataAccessFactory.BranchData().Read();
            var mapped = mapper.Map<List<BranchDTO>>(data);
            return mapped;
        }
        

        public static BranchDTO GetById(int id)
        {
            var data = DataAccessFactory.BranchData().Read(id);
            var mapped = mapper.Map<BranchDTO>(data);
            return mapped;
        }

        public static BranchDTO Create(BranchDTO branchDTO)
        {
            var branch = mapper.Map<Branch>(branchDTO);
            var data = DataAccessFactory.BranchData().Create(branch);
            return mapper.Map<BranchDTO>(data);
        }

        public static BranchDTO Update(BranchDTO branchDTO)
        {
            var branch = mapper.Map<Branch>(branchDTO);
            var data = DataAccessFactory.BranchData().Update(branch);
            return mapper.Map<BranchDTO>(data);
        }

        public static bool Delete(int id)
        {
            var isSuccess= DataAccessFactory.BranchData().Delete(id);
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
