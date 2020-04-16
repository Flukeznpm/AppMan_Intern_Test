using System.Collections.Generic;

namespace TodoApi.Models
{
    public class University
    {
        public long uni_Id { get; set; }
        public string uni_name { get; set; }

        public virtual ICollection<StudentinUniversity> StudentinUniversities { get; set; }
    }
}