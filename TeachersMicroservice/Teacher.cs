using System;
using System.Collections.Generic;

namespace TeacherMicroservice
{
    public class Teacher
    {
        public string Name { get; set; }

        public string Subject { get; set; }

        public IEnumerable<int> Grades { get; set; }
    }
}
