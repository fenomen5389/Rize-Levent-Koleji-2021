using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Core.Utilities.Result;

namespace Business.Abstract
{
    public interface ITeacherService
    {
        IDataResult<List<Teacher>> GetAll();
        IDataResult<Teacher> GetById(int id);
        IDataResult<Teacher> GetByMail(string mail);
        IResult Add(Teacher teacher);
        IResult Delete(int teacherId);
    }
}
