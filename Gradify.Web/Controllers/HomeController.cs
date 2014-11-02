using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Gradify.Web.Common;
using Gradify.Web.DataAccess;

namespace Gradify.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGradeRepository _gradeRepository;
        public HomeController()
        {
            // TODO: Implement using dependency container
            var db = new GradifyDb();
            var uow = new UnitOfWork(db);
            var gradeRepository = new GradeRepository(uow);

            _gradeRepository = gradeRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewGrade(string shortUrl)
        {
            var id = Utility.ResolveId(shortUrl);

            if (id == 0) return View("Error");


            ViewBag.Encouragement = GetEncouragement();

            var grade = _gradeRepository.FindById(id);


            if (string.IsNullOrEmpty(grade.Instructor)) grade.Instructor = GetSecretCaption();
            if (string.IsNullOrEmpty(grade.Term)) grade.Term = GetSecretCaption();

            if (grade.IsPrivate)
            {
                return View("ViewGradePrivate", grade);
            }

            return View(grade);
        }

        private string GetEncouragement()
        {
            var messages = new List<string>
            {
                "Your grades are awesome!",
                "Not bad, eh?",
                "Kudos! Awesome score.",
                "Yeahhhh meeeeeen.",
                "OMG! OMG! OMG!",
                "Ooops. Kamote.",
                "Congratulations!",
                "Great job!",
                "Keep up the good work!",
                "Two thumbs up! Keep it up.",
                "Very good. Be proud!"
            };
            var ri = new Random().Next(0, messages.Count - 1);
            return messages[ri];
        }

        private string GetSecretCaption()
        {
            var messages = new List<string>
            {
                "Some things are better left unsaid.",
                "The secret is untold.",
                "Sssshhh",
                "Doesn't want to be known.",
                "Unknown",
                "Been gone forever..."
            };

            var ri = new Random().Next(0, messages.Count - 1);
            return messages[ri];
        }

    }
}