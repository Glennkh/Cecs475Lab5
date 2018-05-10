using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cecs475.Scheduling.Web.Controllers
{

    public class SemesterTermDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static SemesterTermDto From(Model.SemesterTerm semesterTerm)
        {
            return new SemesterTermDto
            {
                Id = semesterTerm.Id,
                Name = semesterTerm.Name,
            };
        }
    }

    [RoutePrefix("api/schedule")]
    public class ScheduleController : ApiController
    {
        private Model.CatalogContext mContext = new Model.CatalogContext();

        [HttpGet]
        [Route("{year}/{term}")]
        public IEnumerable<CourseSectionDto> GetCoursesSections(string year, string term)
        {
            var SemesterTerm = mContext.SemesterTerms.Where(c => term + " " + year == c.Name).FirstOrDefault();
            if (SemesterTerm == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(
                HttpStatusCode.NotFound, $"No course with name {term} {year} found"));
            }
            return SemesterTerm.CourseSections.Select(CourseSectionDto.From);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IEnumerable<CourseSectionDto> GetCoursesSections(int id)
        {
            var SemesterTerm = mContext.SemesterTerms.Where(c => c.Id == id).FirstOrDefault();
            if (SemesterTerm == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(
                HttpStatusCode.NotFound, $"No course with id {id} found"));
            }
            return SemesterTerm.CourseSections.Select(CourseSectionDto.From);
        }

        [HttpGet]
        [Route("terms")]
        public IEnumerable<SemesterTermDto> GetCoursesSections()
        {
            return mContext.SemesterTerms.Select(SemesterTermDto.From);
        }
        
    }
}