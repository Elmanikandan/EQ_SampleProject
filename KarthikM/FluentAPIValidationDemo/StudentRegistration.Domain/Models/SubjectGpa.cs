using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Domain.Models
{
    public class SubjectGpa:BaseEntity
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public float Gpa { get; set; }
        public string SubjectPassStatus { get; set; }
        public int StudentId { get; set; }
        public Student Students { get; set; }
    }
}
