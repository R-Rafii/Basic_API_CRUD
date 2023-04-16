using BLL.Services;
using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;

namespace Basic_API.Controllers
{
    // hi there ... 
    public class ShopController : ApiController
    {
        [HttpGet]
        [Route("api/products")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = ProductService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        [HttpGet]
        [Route("api/products/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                
                return Request.CreateResponse(HttpStatusCode.OK, ProductService.Get(id));
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }
        [HttpPost]
        [Route("api/products/add")]
        public HttpResponseMessage Add(ProductDTO pro)
        {
            try
            {
                var res = ProductService.Create(pro);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = pro });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Inserted", Data = pro });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = pro });
            }
        }

        [HttpPost]
        [Route("api/products/update")]
        public HttpResponseMessage Update(ProductDTO pro)
        {
            try
            {
                var res = ProductService.Update(pro);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Updated", Data = pro });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Updated", Data = pro });
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = pro });
            }
        }
        [HttpPost]
        [Route("api/products/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, ProductService.Delete(id));
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }
    }
}
