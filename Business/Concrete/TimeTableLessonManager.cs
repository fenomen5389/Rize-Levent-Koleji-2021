using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Business.Constants;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class TimeTableLessonManager : ITimeTableLessonService
    {
        ITimeTableLessonDal _timeTableLessonDal;
        public TimeTableLessonManager(ITimeTableLessonDal timeTableLessonDal)
        {
            _timeTableLessonDal = timeTableLessonDal;
        }
        public IResult Add(TimeTableLesson timeTableLesson)
        {
            //sınıfın aynı saatte başka bir dersi olabilir...
            if(timeTableLesson.TimeTableLessonDay > 6)
            {
                return new ErrorResult(Messages.TimeTableLessonAddDaysOutOfRange);
            }
            var list = GetByLinq(p=>p.ClassId == timeTableLesson.ClassId && p.TimeTableLessonDay == timeTableLesson.TimeTableLessonDay).Data;
            foreach (var p in list)
            {
                if(Math.Abs(timeTableLesson.TimeTableLessonTime - p.TimeTableLessonTime) < TimeSpan.FromMinutes(SchoolConfiguration.LessonTime).Ticks)
                {
                    return new ErrorResult(Messages.TimeTableLessonAddFailedTimeError);
                }
            }
            _timeTableLessonDal.Add(timeTableLesson);
            return new SuccessResult(Messages.TimeTableLessonAddedSuccessfully);

        }

        public IDataResult<List<TimeTableLesson>> GetAll()
        {
            return new SuccessDataResult<List<TimeTableLesson>>(_timeTableLessonDal.GetAll());
        }

        public IDataResult<List<TimeTableLesson>> GetByClassId(int id)
        {
            return new SuccessDataResult<List<TimeTableLesson>>(_timeTableLessonDal.GetAll(p=>p.ClassId == id));
        }

        public IDataResult<List<TimeTableLesson>> GetByLessonID(int id)
        {
            return new SuccessDataResult<List<TimeTableLesson>>(_timeTableLessonDal.GetAll(p => p.LessonId == id));
        }

        public IDataResult<List<TimeTableLesson>> GetByLinq(Expression<Func<TimeTableLesson, bool>> linq)
        {
            return new SuccessDataResult<List<TimeTableLesson>>(_timeTableLessonDal.GetAll(linq));
        }

        public IDataResult<List<TimeTableLesson>> GetByTeacherId(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Remove(TimeTableLesson timeTableLesson)
        {
            throw new NotImplementedException();
        }

        public IResult Update(TimeTableLesson timeTableLesson)
        {
            throw new NotImplementedException();
        }
    }
}
