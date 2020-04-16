using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    public class StudentinUniversity
    {

        public long std_id { get; set; }
        public Student Student { get; set; }

   
        public long uni_id { get; set; }
        public University University { get; set; }
    }
}