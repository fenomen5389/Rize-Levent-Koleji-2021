using Business.Abstract;
using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Entity.Concrete;
using Business.Constants;
using Core.Entity;
using Entity.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        ITeacherService _teacherService;
        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            if (!Auth.IsAdmin(Request))
            {
                return BadRequest(new ErrorResult(Messages.AccessDenied));
            }
            var result = _teacherService.GetAll();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Teacher teacher)
        {
            if (!Auth.IsAdmin(Request))
            {
                return BadRequest(new ErrorResult(Messages.AccessDenied));
            }
            var result = _teacherService.Add(teacher);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("remove/{teacherId}")]
        public IActionResult Remove(int teacherId)
        {
            if (!Auth.IsAdmin(Request))
            {
                return BadRequest(new ErrorResult(Messages.AccessDenied));
            }
            var result = _teacherService.Delete(teacherId);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("login")]
        public IActionResult Login(TeacherLoginDTO dto)
        {
            string mail = dto.Mail;
            string pass = dto.Password;
            Teacher teacher = _teacherService.GetByMail(mail).Data;
            if(teacher != null)
            {
                if(new PasswordHasher().VerifyHashedPassword(teacher.TeacherHashedPassword, pass) == PasswordVerificationResult.Success)
                {
                    return Ok(new SuccessResult(new PasswordHasher().HashPassword(teacher.TeacherMail)));
                }
                else
                {
                    return BadRequest(new ErrorResult(Messages.TeacherLoginFailed));
                }
            }
            return BadRequest(new ErrorResult(Messages.TeacherLoginFailed));
        }

        [HttpGet("gettesttoken")]
        public IActionResult GetTestToken()
        {
            return Ok(new SuccessResult(new PasswordHasher().HashPassword("mysuperscretadminkeymysuperscretadminkey")));
        }
    }
}
