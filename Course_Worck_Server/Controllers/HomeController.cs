using Course_Worck_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Security;
using System.Diagnostics;

/*http://10.0.2.2:55090/api.....
*/


namespace Course_Worck_Server.Controllers
{
    public class HomeController : Controller
    {
        LabTrackerDB db = new LabTrackerDB();


        public ActionResult Authorization()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AuthorizationNext(string login, int password)
        {
            if (login != "" && password != 0)
            {
                using (LabTrackerDB db = new LabTrackerDB())
                {
                    var admins = db.Admins;
                    foreach (Admin a in admins)
                    {
                        if (a.Login == login && a.Password == password)
                            FormsAuthentication.SetAuthCookie(a.Login, true);
                        return RedirectPermanent("/Home/ListOfStudents");
                    }
                }
            }
            return RedirectPermanent("/Shared/Error");
        }

        [Authorize]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Authorization");
        }

        [Authorize]
        public ActionResult ListOfStudents()
        {
            ViewBag.Title = "FIT.ListOfStudent";
            var students = db.ListStudents.Include(c => c.Group.Cource).Include(s => s.Group.Speciality).Include(sg => sg.Group.SubGroup);
            return View(students.ToList());
        }

        [Authorize]
        public ActionResult AddStudentList()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var dbValues = db.Groups.Include(g => g.Cource).Include(sg => sg.SubGroup).ToList();
            // Формируем список команд для передачи в представление
            SelectList groups = new SelectList(dbValues.Select(item => new SelectListItem
            {
                Text = item.Cource.NumberCource.ToString() + " course, " + item.NumberGroup.ToString() + " group, " + item.SubGroup.IDSubGroup.ToString() + " subgroup",
                Value = item.IDGroup.ToString()

            }).ToList(), "Value", "Text");

            ViewBag.Group = groups;
            return View();
        }

        [Authorize]
        public ActionResult UpdateStudentList(string idSelectedItem)
        {
            ViewBag.Id = idSelectedItem;
            //int id = int.Parse(idSelectedItem);
            if (idSelectedItem == "")
            {
                return HttpNotFound();
            }
            int id = int.Parse(idSelectedItem);
            // Находим в бд футболиста
            var player = db.ListStudents.Find(id);
            if (player != null)
            {
                db.Configuration.ProxyCreationEnabled = false;
                var dbValues = db.Groups.Include(g => g.Cource).Include(sg => sg.SubGroup).ToList();
                SelectList groups = new SelectList(dbValues.Select(item => new SelectListItem
                {
                    Text = item.Cource.NumberCource.ToString() + " course, " + item.NumberGroup.ToString() + " group, " + item.SubGroup.IDSubGroup.ToString() + " subgroup",
                    Value = item.IDGroup.ToString()

                }).ToList(), "Value", "Text");

                ViewBag.Group = groups;
                return View(player);
            }
            return RedirectToAction("ListOfStudents");
        }

        [Authorize]
        [HttpGet]
        public ActionResult DeleteStudentList(string delSelectedItem)
        {
            ViewBag.Id = delSelectedItem;
            if (ViewBag.Id != "")
            {

                return View();

            }
            return HttpNotFound();
        }

        [Authorize]
        public ActionResult ListOfTeachers()
        {
            var teachers = db.ListTeachers;
            return View(teachers.ToList());
        }

        [Authorize]
        public ActionResult AddTeacherList()
        {
            return View();
        }

        [Authorize]
        public ActionResult UpdateTeacherList(string idSelectedItem)
        {
            ViewBag.Id = idSelectedItem;
            //int id = int.Parse(idSelectedItem);
            if (idSelectedItem == "")
            {
                return HttpNotFound();
            }
            int id = int.Parse(idSelectedItem);
            // Находим в бд футболиста
            var player = db.ListTeachers.Find(id);
            if (player != null)
            {
                return View(player);
            }
            return RedirectToAction("ListOfTeachers");
        }

        [Authorize]
        [HttpGet]
        public ActionResult DeleteTeacherList(string delSelectedItem)
        {
            ViewBag.Id = delSelectedItem;
            if (ViewBag.Id != "")
            {
                return View();
            }
            return HttpNotFound();
        }

        [Authorize]
        public ActionResult ListOfLabs()
        {
            ViewBag.Title = "FIT.ListOfLabs";
            var labs = db.ListLabs.Include(c => c.Cource).Include(s => s.Speciality).Include(sg => sg.Semestr);
            return View(labs.ToList());
        }

        [Authorize]
        public ActionResult AddLabList()
        {
            db.Configuration.ProxyCreationEnabled = false;

            var dbCource = db.Cources.ToList();
            var dbSpeciality = db.Specialities.ToList();
            var dbSemestr = db.Semestrs.ToList();

            // Make Selectlist, which is IEnumerable<SelectListItem>
            var listOfCourse = new SelectList(dbCource.Select(item => new SelectListItem
            {
                Text = item.NumberCource.ToString() + " cource ",
                Value = item.IDCource.ToString()

            }).ToList(), "Value", "Text");

            var listOfSpeciality = new SelectList(dbSpeciality.Select(item => new SelectListItem
            {
                Text = item.NameSpeciality.ToString(),
                Value = item.NameSpeciality.ToString()

            }).ToList(), "Value", "Text");

            var listOfSemestrs = new SelectList(dbSemestr.Select(item => new SelectListItem
            {
                Text = item.IDSem.ToString() + " semestr",
                Value = item.IDSem.ToString()

            }).ToList(), "Value", "Text");

            ViewBag.Course = listOfCourse;
            ViewBag.Speciality = listOfSpeciality;
            ViewBag.Semestr = listOfSemestrs;
            return View();
        }

        [Authorize]
        public ActionResult UpdateLabList(string idSelectedItem)
        {
            ViewBag.Id = idSelectedItem;
            //int id = int.Parse(idSelectedItem);
            if (idSelectedItem == "")
            {
                return HttpNotFound();
            }
            int id = int.Parse(idSelectedItem);
            // Находим в бд футболиста
            var player = db.ListLabs.Find(id);
            if (player != null)
            {
                var dbCource = db.Cources.ToList();
                var dbSpeciality = db.Specialities.ToList();
                var dbSemestr = db.Semestrs.ToList();

                // Make Selectlist, which is IEnumerable<SelectListItem>
                var listOfCourse = new SelectList(dbCource.Select(item => new SelectListItem
                {
                    Text = item.NumberCource.ToString() + " cource ",
                    Value = item.IDCource.ToString()

                }).ToList(), "Value", "Text");

                var listOfSpeciality = new SelectList(dbSpeciality.Select(item => new SelectListItem
                {
                    Text = item.NameSpeciality.ToString(),
                    Value = item.NameSpeciality.ToString()

                }).ToList(), "Value", "Text");

                var listOfSemestrs = new SelectList(dbSemestr.Select(item => new SelectListItem
                {
                    Text = item.IDSem.ToString() + " semestr",
                    Value = item.IDSem.ToString()

                }).ToList(), "Value", "Text");

                ViewBag.Course = listOfCourse;
                ViewBag.Speciality = listOfSpeciality;
                ViewBag.Semestr = listOfSemestrs;
                return View(player);
            }
            return RedirectToAction("ListOfStudents");
        }

        [Authorize]
        [HttpGet]
        public ActionResult DeleteLabList(string delSelectedItem)
        {
            ViewBag.Id = delSelectedItem;
            if (ViewBag.Id != "")
            {
                return View();
            }
            return HttpNotFound();
        }

        [Authorize]
        public ActionResult ListOfTeachersLabs()
        {
            db.Configuration.ProxyCreationEnabled = false;
            ViewBag.Title = "FIT.ListOfTeachersLabs";
            var ListLabTeach = db.ListLabTeachers.Include(s => s.Group).ToList();
            var dbListLabTeacher = db.ListLabTeachers.Include(c => c.Group.Cource).Include(s => s.Group).Include(sg => sg.Group.SubGroup).Include(t => t.ListTeacher).Include(l => l.ListLab).ToList();
            var dbListLab = db.ListLabs.ToList();
            foreach (ListLab list_lab in dbListLab)
            {
                foreach (ListLabTeacher list_lab_teacher in ListLabTeach)
                {
               
                    if (list_lab_teacher.Group.IDCource != list_lab.IDCource || list_lab_teacher.Group.IDSpeciality.Equals(list_lab.IDSpeciality)==false)
                    {
                        dbListLabTeacher.Remove(list_lab_teacher);
                    }
                }
            }
            return View(dbListLabTeacher);
        }

        [Authorize]
        public ActionResult AddTeachersLab()
        {
            // db.Configuration.ProxyCreationEnabled = false;
            var dbListGroup = db.Groups.ToList();
            var dbListTeacher = db.ListTeachers.ToList();
            var dbListLab = db.ListLabs.ToList();
            var dbWeekday = db.WeekDays.ToList();


            // Make Selectlist, which is IEnumerable<SelectListItem>

            var listOfTeachers = new SelectList(dbListTeacher.Select(item => new SelectListItem
            {
                Text = item.Name + " " + item.Surname,
                Value = item.IDTeacher.ToString()

            }).ToList(), "Value", "Text");

            var listOfLabs = new SelectList(dbListLab.Select(item => new SelectListItem
            {
                Text = item.NameLab,
                Value = item.IDLab.ToString()

            }).ToList(), "Value", "Text");


            var listOfGroups = new SelectList(dbListGroup.Select(item => new SelectListItem
            {
                Text = item.Cource.NumberCource.ToString() + " cource, " + item.NumberGroup.ToString() + " group, " + item.SubGroup.IDSubGroup.ToString() + " subgroup",
                Value = item.IDGroup.ToString()

            }).ToList(), "Value", "Text");

            ViewBag.Group = listOfGroups;


            var listOfWeekdays = new SelectList(dbWeekday.Select(item => new SelectListItem
            {
                Text = item.IDWeek,
                Value = item.IDWeek.ToString()

            }).ToList(), "Value", "Text");


            ViewBag.Lab = listOfLabs;
            ViewBag.Teacher = listOfTeachers;
            ViewBag.Week = listOfWeekdays;
            return View();
        }

        [Authorize]
        public ActionResult UpdateTeachersLab(string idSelectedItem)
        {
            ViewBag.Id = idSelectedItem;
            //int id = int.Parse(idSelectedItem);
            if (idSelectedItem == "")
            {
                return HttpNotFound();
            }
            int id = int.Parse(idSelectedItem);
            // Находим в бд футболиста
            var player = db.ListLabTeachers.Find(id);
            if (player != null)
            {
                var dbListGroup = db.Groups.ToList();
                var dbListTeacher = db.ListTeachers.ToList();
                var dbListLab = db.ListLabs.ToList();
                var dbWeekday = db.WeekDays.ToList();


                // Make Selectlist, which is IEnumerable<SelectListItem>
                var listOfTeachers = new SelectList(dbListTeacher.Select(item => new SelectListItem
                {
                    Text = item.Name + " " + item.Surname,
                    Value = item.IDTeacher.ToString()

                }).ToList(), "Value", "Text");

                var listOfLabs = new SelectList(dbListLab.Select(item => new SelectListItem
                {
                    Text = item.NameLab,
                    Value = item.IDLab.ToString()

                }).ToList(), "Value", "Text");


                var listOfGroups = new SelectList(dbListGroup.Select(item => new SelectListItem
                {
                    Text = item.Cource.NumberCource.ToString() + " cource, " + item.NumberGroup.ToString() + " group, " + item.SubGroup.IDSubGroup.ToString() + " subgroup",
                    Value = item.IDGroup.ToString()

                }).ToList(), "Value", "Text");


                var listOfWeekdays = new SelectList(dbWeekday.Select(item => new SelectListItem
                {
                    Text = item.IDWeek,
                    Value = item.IDWeek.ToString()

                }).ToList(), "Value", "Text");


                ViewBag.Group = listOfGroups;
                ViewBag.Lab = listOfLabs;
                ViewBag.Teacher = listOfTeachers;
                ViewBag.Week = listOfWeekdays;

                return View(player);
            }
            return RedirectToAction("ListOfStudents");
        }

        [Authorize]
        [HttpGet]
        public ActionResult DeleteTeachersLab(string delSelectedItem)
        {
            ViewBag.Id = delSelectedItem;
            if (ViewBag.Id != "")
            {
                return View();
            }
            return HttpNotFound();
        }

        

    }
}
