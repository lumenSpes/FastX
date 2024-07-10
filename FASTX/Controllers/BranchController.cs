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
    public class BranchController : ApiController
    {
        [HttpGet]
        [Route("api/branch")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = BranchServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message});
            }

        }
        [HttpGet]
        [Route("api/branch/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var data = BranchServices.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }

        }
        [HttpPost]
        [Route("api/branch/create")]
        public HttpResponseMessage Create([FromBody] BranchDTO branchDTO)
        {
            try
            {
                if (branchDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid data" });
                }

                var data = BranchServices.Create(branchDTO);

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Branch created successfully", data});
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }
        [HttpPut]
        [Route("api/branch/update/{id}")]
        public HttpResponseMessage Update(int id, [FromBody] BranchDTO branchDTO)
        {
            try
            {
                if (branchDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid data" });
                }

                branchDTO.BranchId = id;

                var data = BranchServices.Update(branchDTO);

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Branch updated successfully", data});
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/branch/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isSuccess = BranchServices.Delete(id);

                if (isSuccess)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Branch deleted successfully" });

                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Branch not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }


    }
}
