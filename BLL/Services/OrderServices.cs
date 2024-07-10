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
    public class OrderServices
    {
        private static readonly IMapper mapper;

        static OrderServices()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Order, OrderDTO>();
            });
            mapper = cfg.CreateMapper();
        }

        public static List<OrderDTO> Get()
        {
            var data = DataAccessFactory.OrderData().Read();
            var mapped = mapper.Map<List<OrderDTO>>(data);
            return mapped;
        }


        public static OrderDTO GetById(int id)
        {
            var data = DataAccessFactory.OrderData().Read(id);
            var mapped = mapper.Map<OrderDTO>(data);
            return mapped;
        }

        public static OrderDTO Create(OrderDTO orderDTO)
        {
            var order = mapper.Map<Order>(orderDTO);
            var data = DataAccessFactory.OrderData().Create(order);
            return mapper.Map<OrderDTO>(data);
        }

        public static OrderDTO Update(OrderDTO orderDTO)
        {
            var order = mapper.Map<Order>(orderDTO);
            var data = DataAccessFactory.OrderData().Update(order);
            return mapper.Map<OrderDTO>(data);
        }

        public static bool Delete(int id)
        {
            var isSuccess = DataAccessFactory.OrderData().Delete(id);
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
