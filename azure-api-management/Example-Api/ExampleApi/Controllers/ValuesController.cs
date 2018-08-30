using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NSwag.Annotations;

namespace ExampleApi.Controllers
{
    /// <summary>
    /// Example controller
    /// </summary>
    public class ValuesController : ApiController
    {
        /// <summary>
        /// Ping operation, summary field
        /// </summary>
        /// <remarks>
        /// Ping operation, remarks field
        /// </remarks>
        /// <returns>HTTP 200 - Ok</returns>
        /// <response code="200">Ok</response>
        [HttpGet]
        [Route("ping")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(void))]
        public IHttpActionResult Ping()
        {
            return Ok();
        }

        /// <summary>
        /// Get-all operation, summary field
        /// </summary>
        /// <remarks>
        /// Get-all operation, remarks field
        /// </remarks>
        /// <returns>Get-all operation, returns field</returns>
        /// <response code="200">Description of the response code (ok)</response>
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, typeof(IEnumerable<string>))]
        public IHttpActionResult GetAll()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        /// <summary>
        /// Get operation, summary field
        /// </summary>
        /// <remarks>
        /// Get operation, remarks field
        /// </remarks>
        /// <param name="id">Get operation, param field for id</param>
        /// <returns>Get operation, returns field</returns>
        /// <response code="200">Description of the response code (ok)</response>
        /// <response code="404">Description of the response code (not found)</response>
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, typeof(string))]
        [SwaggerResponse(HttpStatusCode.NotFound, typeof(void))]
        public IHttpActionResult Get(int id)
        {
            return Ok("value");
        }

        /// <summary>
        /// Post operation, summary field
        /// </summary>
        /// <remarks>
        /// Post operation, remarks field
        /// </remarks>
        /// <response code="201">Description of the response code (created)</response>
        /// <response code="400">Description of the response code (bad request)</response>
        /// <response code="500">Description of the response code (internal server error)</response>
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, typeof(string))]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(void))]
        public IHttpActionResult Post([FromBody]string value)
        {
            return Created("url to created resource", value);
        }

        /// <summary>
        /// Put operation, summary field
        /// </summary>
        /// <remarks>
        /// Put operation, remarks field
        /// </remarks>
        /// <param name="id">Put operation, param field for id</param>
        /// <param name="value">Put operation, param field for value</param>
        /// <response code="200">Description of the response code (ok)</response>
        /// <response code="400">Description of the response code (bad request)</response>
        /// <response code="404">Description of the response code (not found)</response>
        /// <response code="500">Description of the response code (internal server error)</response>
        [HttpPut]
        [SwaggerResponse(HttpStatusCode.OK, typeof(string))]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void))]
        [SwaggerResponse(HttpStatusCode.NotFound, typeof(void))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(void))]
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return Ok(value);
        }

        /// <summary>
        /// Delete operation, summary field
        /// </summary>
        /// <remarks>
        /// Delete operation, remarks field
        /// </remarks>
        /// <param name="id">Delete operation, param field for id</param>
        /// <response code="200">Description of the response code (ok)</response>
        /// <response code="404">Description of the response code (not found)</response>
        [HttpDelete]
        [SwaggerResponse(HttpStatusCode.OK, typeof(void))]
        [SwaggerResponse(HttpStatusCode.NotFound, typeof(void))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
