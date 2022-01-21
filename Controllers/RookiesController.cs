using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_Core.Models;

namespace ASP.NET_Core.Controllers;

public class RookiesController : Controller{
        static List<Person> persons = new List<Person>{
            new Person{
                FirstName = "Thai",
                LastName = "Do Van",
                Gender = "Male",
                DOB = new DateTime(2001, 2, 15),
                PhoneNumber = "",
                BirthPlace = "Thai Binh",
                IsGraduated = false
            },
            new Person{
                FirstName = "Hoc",
                LastName = "Nguyen Thai",
                Gender = "Male",
                DOB = new DateTime(2000, 2, 15),
                PhoneNumber = "",
                BirthPlace = "Ha Nam",
                IsGraduated = false
            },
            new Person{
                FirstName = "Thanh",
                LastName = "Do Tien",
                Gender = "Male",
                DOB = new DateTime(1999, 2, 15),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Person{
                FirstName = "Anh",
                LastName = "Do Ngoc",
                Gender = "Male",
                DOB = new DateTime(1998, 3, 11),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Person{
                FirstName = "Duy",
                LastName = "Pham Tran",
                Gender = "Male",
                DOB = new DateTime(1998, 3, 11),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Person{
                FirstName = "Quan",
                LastName = "Pham Dinh",
                Gender = "Male",
                DOB = new DateTime(1996, 3, 11),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Person{
                FirstName = "Huy",
                LastName = "Nguyen Quang",
                Gender = "Female",
                DOB = new DateTime(1997, 3, 11),
                PhoneNumber = "",
                BirthPlace = "Bac Giang",
                IsGraduated = false
            }
        };


        public IActionResult Index(){
            return View(persons);
        } 

        [Route("rookies/male")]
        

        public IActionResult GetMale(){
            var male_member = from p in persons
            where p.Gender == "Male"
            select p;
            return Json(male_member);
        }


        [Route("rookies/oldest")]
        public IActionResult GetOldest(){
            var maxAge = persons.Max(m => m.Age);
            var oldest_member = persons.First(m => m.Age == maxAge);
            return Json(oldest_member);
        }


        [Route("rookies/full-name")]
        public IActionResult GetFullnames(){
            var fullnames = persons.Select(m => m.FullName);
            return Json(fullnames);
        }




        [Route("rookies/listbirth")]
        public IActionResult ListbirthMembers(int year){
            var birth = from p in persons
            group p by p.DOB.Year.CompareTo(year) into grp
            select new{
                Key = grp.Key switch{
                    -1 => $"Less than {year}",
                    0 => $"BirthYear is {year}",
                    1 => $"Greater than {year}",
                    _ => string.Empty
                },
                Data = grp.ToList()
            };
            return Json(birth);
        }
        



        




        // [Route("rookies/export")]
        // public IActionResult DownFile(){
        //     var result = WriteCsvToMemory(persons); 
        //     var memoryStream = new MemoryStream(result);
        //     return new FileStreamResult(memoryStream, "text/csv") { FileDownloadName = "Person.csv" };
        // }

        // public byte[] WriteCsvToMemory(List<Person> lisp){
        //     using (var stream = new MemoryStream())
        //     using (var Writer = new StreamWriter(stream))
        //     using (var csvWriter = new CsWriter(Writer, CultureInfo.InvariantCulture))
        //     {
        //         csvWriter.WriteRecords(lisp);
        //         Writer.Flush();
        //         return stream.ToArray();
        //     }
        // }



        // [Route("rookies/place")]
        // public IActionResult GetBirthPlace(){
        //     var place = from p in persons
        //     where p.BirthPlace == "Ha Noi"
        //     select p;
        //     return Json(place);
        // }
}
