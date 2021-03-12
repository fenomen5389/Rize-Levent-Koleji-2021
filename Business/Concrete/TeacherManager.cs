using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Core.Utilities.Result;
using Business.Constants;
using Microsoft.AspNet.Identity;

namespace Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        ITeacherDal _teacherDal;
        public TeacherManager(ITeacherDal teacherDal)
        {
            _teacherDal = teacherDal;
        }

        public IResult Add(Teacher teacher)
        {
            //İSTİSNAİ DURUM:Ekleme için gelen data'da HashedPassword'dan salt şifre gelir. Server'da şifrelenir !
            var roomId = new Random().Next(1111111, 9999999);
            teacher.TeacherRoomId = roomId.ToString();
            try
            {
                if (GetByMail(teacher.TeacherMail).Data != null)
                    return new ErrorResult(Messages.TeacherMailAlreadyTaken);
                teacher.TeacherHashedPassword = new PasswordHasher().HashPassword(teacher.TeacherHashedPassword);
                _teacherDal.Add(teacher);
            }
            catch
            {
                return new ErrorResult(Messages.TeacherAddingFailed);
            }
            return new SuccessResult(Messages.TeacherAddedSuccessfully);
        }

        public IResult Delete(int teacherId)
        {
            try
            {
                _teacherDal.Remove(new Teacher { TeacherId = teacherId });
                return new SuccessResult(Messages.TeacherDeletedSuccessfully);
            }
            catch
            {
                return new ErrorResult(Messages.TeacherDeleteFailed);
            }
        }

        public IDataResult<List<Teacher>> GetAll()
        {
            return new SuccessDataResult<List<Teacher>>(_teacherDal.GetAll());
        }

        public IDataResult<Teacher> GetById(int id)
        {
            return new SuccessDataResult<Teacher>(_teacherDal.Get(p=>p.TeacherId==id));
        }

        public IDataResult<Teacher> GetByMail(string mail)
        {
            return new SuccessDataResult<Teacher>(_teacherDal.Get(p => p.TeacherMail == mail));
        }
    }
}
