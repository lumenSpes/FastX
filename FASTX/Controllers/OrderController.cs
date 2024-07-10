using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services.Description;

namespace FASTX.Controllers
{
    public class OrderController : ApiController
    {
        [HttpGet]
        [Route("api/Orders")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = OrderServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }

        }
        [HttpGet]
        [Route("api/Orders/{OrderId}")]
        public HttpResponseMessage GetById(int OrderId)
        {
            try
            {
                var data = OrderServices.GetById(OrderId);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }

        }
        [HttpPost]
        [Route("api/OrdersCreate")]
        public HttpResponseMessage Create([FromBody] OrderDTO orderDTO)
        {
            try
            {
                if (orderDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid data" });
                }

                var data = OrderServices.Create(orderDTO);

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Order created successfully", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }
        [HttpPut]
        [Route("api/UpdateOrder/{OrderId}")]
        public HttpResponseMessage Update(int OrderId, [FromBody] OrderDTO orderDTO)
        {
            try
            {
                if (orderDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid data" });
                }

                orderDTO.BranchId = OrderId;

                var data = OrderServices.Update(orderDTO);

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Order updated successfully", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/DeleteOrder/{OrderId}")]
        public HttpResponseMessage Delete(int OrderId)
        {
            try
            {
                var isSuccess = OrderServices.Delete(OrderId);
                if (isSuccess) return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Order deleted successfully" });
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Order not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }
    }
}
