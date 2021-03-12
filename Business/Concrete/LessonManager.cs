using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class LessonManager : ILessonService
    {
        ILessonDal _lessonDal;
        public LessonManager(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }
        public IResult Add(Lesson lesson)
        {
            if(lesson.LessonName.Length < 2)
            {
                return new ErrorResult(Messages.LessonNameTooShort);
            }
            _lessonDal.Add(lesson);
            return new SuccessResult(Messages.LessonAddedSuccessfully);
        }

        public IDataResult<Lesson> GetById(int id)
        {
            return new SuccessDataResult<Lesson>(_lessonDal.Get(p=>p.LessonId==id));
        }

        public IDataResult<List<Lesson>> GetAll(Expression<Func<Class, bool>> filter = null)
        {
            return new SuccessDataResult<List<Lesson>>(_lessonDal.GetAll());
        }

        public IResult Remove(Lesson lesson)
        {
            try
            {
                _lessonDal.Remove(lesson);
                return new SuccessResult(Messages.LessonDeletedSuccessfully);
            }
            catch
            {
                return new ErrorResult(Messages.LessonDeleteFailed);
            }
        }

        public IResult Update(Lesson lesson)
        {
            try
            {
                return new SuccessResult(Messages.LessonUpdatedSuccessfully);
            }
            catch
            {
                return new ErrorResult(Messages.LessonUpdateFailed);
            }
        }
    }
}
