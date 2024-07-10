using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FASTX.Controllers
{
    public class ReturnOrderController : ApiController
    {
        [HttpGet]
        [Route("api/return/all")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = ReturnOrderServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }

        }
        [HttpGet]
        [Route("api/return/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var data = ReturnOrderServices.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }

        }
        [HttpPost]
        [Route("api/return/create")]
        public HttpResponseMessage Create([FromBody] ReturnOrderDTO returnOrderDTO)
        {
            try
            {
                if (returnOrderDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid data" });
                }

                var data = ReturnOrderServices.Create(returnOrderDTO);

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Return Order created successfully", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }
        [HttpPut]
        [Route("api/retun/update/{id}")]
        public HttpResponseMessage Update(int id, [FromBody] ReturnOrderDTO returnOrderDTO)
        {
            try
            {
                if (returnOrderDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid data" });
                }

                returnOrderDTO.ReturnId = id;

                var data = ReturnOrderServices.Update(returnOrderDTO);

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Return Order updated successfully", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/return/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isSuccess = ReturnOrderServices.Delete(id);

                if (isSuccess)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Return Order deleted successfully" });

                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Return Order not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }

    }
}
