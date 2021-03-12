using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class TimeTableLesson:IEntity
    {
        public int TimeTableLessonId { get; set; }
        public string TimeTableLessonLabel { get; set; }
        public short TimeTableLessonDay { get; set; }
        public long TimeTableLessonTime { get; set; }
        public int TeacherId { get; set; }
        public int LessonId { get; set; }
        public int ClassId { get; set; }
    }
}
