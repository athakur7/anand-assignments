using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEFDemo.Models
{
     class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CourseLevel level { get; set; }
        public List<Student> Students { get; set; } // navigation property for related students
        public Author author { get; set; } // navigation property for related author
        public int AuthorId { get; set; } // foreign key to Author
    }
        enum CourseLevel
        {
            Beginner =1,
            Intermediate=2,
            Advanced=3
    }
}
