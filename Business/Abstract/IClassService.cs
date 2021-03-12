using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Core.Utilities.Result;

namespace Business.Abstract
{
    public interface IClassService
    {
        IDataResult<List<Class>> GetAll(Expression<Func<Class,bool>> filter = null);
        IDataResult<Class> GetById(int id);
        IResult Add(Class @class);
        IResult Remove(Class @class);
        IResult Update(Class @class);
    }
}
