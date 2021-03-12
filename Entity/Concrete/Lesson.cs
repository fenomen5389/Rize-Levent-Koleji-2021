using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Lesson:IEntity
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
    }
}
