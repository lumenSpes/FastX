using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class InventoryServices
    {
        private static readonly IMapper mapper;

        static InventoryServices()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Branch, BranchDTO>();
            });
            mapper = cfg.CreateMapper();
        }

        public static List<InventoryDTO> Get()
        {
            var data = DataAccessFactory.InventoryData().Read();
            var mapped = mapper.Map<List<InventoryDTO>>(data);
            return mapped;
        }


        public static InventoryDTO GetById(int id)
        {
            var data = DataAccessFactory.InventoryData().Read(id);
            var mapped = mapper.Map<InventoryDTO>(data);
            return mapped;
        }

        public static InventoryDTO Create(InventoryDTO inventoryDTO)
        {
            var inventory = mapper.Map<Inventory>(inventoryDTO);
            var data = DataAccessFactory.InventoryData().Create(inventory);
            return mapper.Map<InventoryDTO>(data);
        }

        public static InventoryDTO Update(InventoryDTO inventoryDTO)
        {
            var inventory = mapper.Map<Inventory>(inventoryDTO);
            var data = DataAccessFactory.InventoryData().Update(inventory);
            return mapper.Map<InventoryDTO>(data);
        }

        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.InventoryData().Delete(id);
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
