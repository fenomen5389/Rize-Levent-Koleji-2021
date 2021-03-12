using Business.Concrete;
using DataAccess.Abstract;
using Business.Abstract;
using System;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNet.Identity;
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Parse("10:40").TimeOfDay.Ticks);
        }
    }
}
