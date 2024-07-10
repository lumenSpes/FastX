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
    public class InventoryController : ApiController
    {
        [HttpGet]
        [Route("api/inventory/all")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = InventoryServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }

        }
        [HttpGet]
        [Route("api/inventory/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var data = InventoryServices.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }

        }
        [HttpPost]
        [Route("api/inventory/create")]
        public HttpResponseMessage Create([FromBody] InventoryDTO inventoryDTO)
        {
            try
            {
                if (inventoryDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid data" });
                }

                var data = InventoryServices.Create(inventoryDTO);

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Inventory created successfully", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }
        [HttpPut]
        [Route("api/inventory/update/{id}")]
        public HttpResponseMessage Update(int id, [FromBody] InventoryDTO inventoryDTO)
        {
            try
            {
                if (inventoryDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Invalid data" });
                }

                inventoryDTO.InventoryId = id;

                var data = InventoryServices.Update(inventoryDTO);

                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Inventory updated successfully", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/inventory/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isSuccess = InventoryServices.Delete(id);

                if (isSuccess)
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Inventory deleted successfully" });

                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Inventory not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ex.Message });
            }
        }
    }
}
