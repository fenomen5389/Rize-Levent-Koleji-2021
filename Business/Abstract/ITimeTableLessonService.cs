using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Result;
using Entity.Concrete;
using System.Linq.Expressions;
namespace Business.Concrete
{
    public interface ITimeTableLessonService
    {
        IDataResult<List<TimeTableLesson>> GetAll();
        IDataResult<List<TimeTableLesson>> GetByClassId(int id);
        IDataResult<List<TimeTableLesson>> GetByTeacherId(int id);
        IDataResult<List<TimeTableLesson>> GetByLessonID(int id);
        IDataResult<List<TimeTableLesson>> GetByLinq(Expression<Func<TimeTableLesson,bool>> linq);
        IResult Add(TimeTableLesson timeTableLesson);
        IResult Remove(TimeTableLesson timeTableLesson);
        IResult Update(TimeTableLesson timeTableLesson);
    }
}
