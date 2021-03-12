using Core.Utilities.Result;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ILessonService
    {
        IDataResult<List<Lesson>> GetAll(Expression<Func<Class, bool>> filter = null);
        IDataResult<Lesson> GetById(int id);
        IResult Add(Lesson lesson);
        IResult Remove(Lesson lesson);
        IResult Update(Lesson lesson);
    }
}
