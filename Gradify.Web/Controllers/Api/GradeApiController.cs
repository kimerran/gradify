using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Gradify.Web.Common;
using Gradify.Web.DataAccess;
using Gradify.Web.Domain;

namespace Gradify.Web.Controllers.Api
{
    [RoutePrefix("api/grade")]
    public class GradeApiController : ApiController
    {

        private readonly IGradeRepository _gradeRepository;
        public GradeApiController()
        {
            // TODO: Implement using dependency container
            var db = new GradifyDb();
            var uow = new UnitOfWork(db);
            var gradeRepository = new GradeRepository(uow);

            _gradeRepository = gradeRepository;
        }

        [HttpGet]
        [Route("{gradeId:int}")]
        public Grade Get(int gradeId)
        {
            return _gradeRepository.FindById(gradeId);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post(Grade grade)
        {
            if (!ModelState.IsValid) return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            try
            {
                grade.Created = DateTime.UtcNow;

                _gradeRepository.Add(grade);

                grade.ShortUrl = Utility.GenerateHash(grade.Id);

                return Request.CreateResponse(HttpStatusCode.Created, grade);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }           
        }
    }
}
