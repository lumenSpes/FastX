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
    public class ReturnOrderServices
    {
        private static readonly IMapper mapper;

        static ReturnOrderServices() 
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ReturnOder, ReturnOrderDTO>();
            });
            mapper = cfg.CreateMapper();
        }
        public static List<ReturnOrderDTO> Get()
        {
            var data = DataAccessFactory.ReturnOrderData().Read();
            var mapped = mapper.Map<List<ReturnOrderDTO>>(data);
            return mapped;
        }


        public static ReturnOrderDTO GetById(int id)
        {
            var data = DataAccessFactory.ReturnOrderData().Read(id);
            var mapped = mapper.Map<ReturnOrderDTO>(data);
            return mapped;
        }

        public static ReturnOrderDTO Create(ReturnOrderDTO returnOrderDTO)
        {
            var returnOrder = mapper.Map<ReturnOder>(returnOrderDTO);
            var data = DataAccessFactory.ReturnOrderData().Create(returnOrder);
            return mapper.Map<ReturnOrderDTO>(data);
        }

        public static ReturnOrderDTO Update(ReturnOrderDTO returnOrderDTO)
        {
            var returnOrder = mapper.Map<ReturnOder>(returnOrderDTO);
            var data = DataAccessFactory.ReturnOrderData().Update(returnOrder);
            return mapper.Map<ReturnOrderDTO>(data);
        }

        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.ReturnOrderData().Delete(id);
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
