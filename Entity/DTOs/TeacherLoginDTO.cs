using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
    public class TeacherLoginDTO:IDto
    {
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
