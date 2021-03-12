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
    public class ClassManager : IClassService
    {
        IClassDal _classDal;
        public ClassManager(IClassDal classDal)
        {
            _classDal = classDal;
        }

        public IResult Add(Class @class)
        {
            if(@class.ClassN > 12)
            {
                return new ErrorResult(Messages.ClassNumberTooHigh);
            }
            else if(@class.ClassN < 1)
            {
                return new ErrorResult(Messages.ClassNumberTooLow);
            }
            else if(@class.ClassQ.Length > 10)
            {
                return new ErrorResult(Messages.ClassQueryLengthExceeded);
            }
            else if(@class.ClassQ.Length < 1)
            {
                return new ErrorResult(Messages.ClassQueryLengthNotEnough);
            }
            _classDal.Add(@class);
            return new SuccessResult(Messages.ClassAddedSuccessfully);
        }

        public IDataResult<Class> GetById(int id)
        {
            return new SuccessDataResult<Class>(_classDal.Get(p=>p.ClassId==id), Messages.ClassListedSuccessfully);
        }

        public IDataResult<List<Class>> GetAll(Expression<Func<Class, bool>> filter = null)
        {
            return new SuccessDataResult<List<Class>>(_classDal.GetAll(filter),Messages.ClassListedSuccessfully);
        }

        public IResult Remove(Class @class)
        {
            try
            {
                _classDal.Remove(@class);
            }
            catch
            {
                return new ErrorResult(Messages.ClassRemoveFailed);
            }
            return new SuccessResult(Messages.ClassRemovedSuccessfully);
        }

        public IResult Update(Class @class)
        {
            throw new NotImplementedException();
        }
    }
}
