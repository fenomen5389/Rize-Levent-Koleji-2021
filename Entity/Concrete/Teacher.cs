using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Teacher:IEntity
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public string TeacherRoomId { get; set; }
        public string TeacherPhone { get; set; }
        public string TeacherHashedPassword { get; set; }
        public string TeacherMail { get; set; }
        public short LessonId { get; set; }
    }
}
