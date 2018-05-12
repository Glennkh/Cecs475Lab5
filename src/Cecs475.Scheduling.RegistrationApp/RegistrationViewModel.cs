using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cecs475.Scheduling.RegistrationApp
{
    public class RegistrationViewModel
    {

        public class CourseSectionDto
        {
            public int Id { get; set; }
            public int SemesterTermId { get; set; }
            public CatalogcourseDto CatalogCourse { get; set; }
            public int SectionNumber { get; set; }

            override public String ToString()
            {
                return CatalogCourse.DepartmentName + " " + CatalogCourse.CourseNumber + "-" + SectionNumber.ToString();
            }
        }

        public class CatalogcourseDto
        {
            public int Id { get; set; }
            public string DepartmentName { get; set; }
            public string CourseNumber { get; set; }
            public int[] PrerequisiteCourseIds { get; set; }
        }

        public class SemesterTermDto
        {
            public int Id { get; set; }
            public string Name { get; set; }

            override public String ToString()
            {
                return Name;
            }
        }

        public ObservableCollection<SemesterTermDto> SemesterTerm { get; set; } = new ObservableCollection<SemesterTermDto>();
        public ObservableCollection<CourseSectionDto> CourseSection { get; set; } = new ObservableCollection<CourseSectionDto>();

        /// <summary>
        /// A URL path to the registration web service.
        /// </summary>
        public string ApiUrl { get; set; }
        /// <summary>
        /// The full name of the student who is registering.
        /// </summary>
        public string FullName { get; set; }
    }
}
