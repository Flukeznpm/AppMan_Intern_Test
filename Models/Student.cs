using System.Collections.Generic;

namespace TodoApi.Models
{
    public class Student
    {
        public long std_Id { get; set; }
        public string std_fname { get; set; }
        public string std_lname { get; set; }

        public virtual ICollection<StudentinUniversity> StudentinUniversities { get; set; }
    }
}
