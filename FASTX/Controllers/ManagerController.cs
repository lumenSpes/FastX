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
    public class ManagerController : ApiController
    {
        [HttpGet]
        [Route("api/manager/all")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = ManagerServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }

        }
        [HttpGet]
        [Route("api/manager/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var data = ManagerServices.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }

        }
        [HttpPost]
        [Route("api/manager/create")]
        public HttpResponseMessage Create([FromBody] ManagerDTO managerDTO)
        {
            try
            {
                if (managerDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid data" });
                }

                var data = ManagerServices.Create(managerDTO);

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Manager created successfully", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }
        [HttpPut]
        [Route("api/manager/update/{id}")]
        public HttpResponseMessage Update(int id, [FromBody] ManagerDTO managerDTO)
        {
            try
            {
                if (managerDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid data" });
                }

                managerDTO.ManagerId = id;

                var data = ManagerServices.Update(managerDTO);

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Manager updated successfully", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/manager/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isSuccess = ManagerServices.Delete(id);

                if (isSuccess)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Manager deleted successfully" });

                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Manager not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }
    }
}
