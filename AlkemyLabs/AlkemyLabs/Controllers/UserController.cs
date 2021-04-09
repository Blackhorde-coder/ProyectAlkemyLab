using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlkemyLabs.Models;
using AlkemyLabs.Models.DTO;
using AlkemyLabs.Models.TableViewModels;
using AlkemyLabs.Models.ViewModels;

namespace AlkemyLabs.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<MattersTaleViewModel> list = null;
            using (AlkemyLabEntities bd = new AlkemyLabEntities())
            {
                list = (from d in bd.subject_matter
                       where d.quota >= 1
                       orderby d.Name
                       select new MattersTaleViewModel
                       {
                           id = d.id,
                           name = d.Name,
                           description = d.Description,
                           teacher = d.teacher,
                           quota = d.quota


                       }).ToList();
            }

                return View(list);
        }
        [HttpGet]
        public ActionResult Add()
        {
            List<DTOteacher> list = null;
            using (AlkemyLabEntities bd = new AlkemyLabEntities())
            {
                list = (from d in bd.teacher
                        where d.Active == true
                        orderby d.Name
                        select new DTOteacher
                        {
                            id = d.id,
                            name = d.Name
                            

                        }).ToList();
            }
            MatterViewModel model = new MatterViewModel();
            model.teachers = list;
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(MatterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new AlkemyLabEntities())
            {
                subject_matter matter = new subject_matter();
                matter.Name = model.name;
                matter.Description = model.description;
                matter.Time = model.Time;
                matter.id_teacher = model.idTeacher;
                matter.quota = model.quota;

                db.subject_matter.Add(matter);
                db.SaveChanges();

            }
            return Redirect(Url.Content("~/User/Index"));

        }
    }
}