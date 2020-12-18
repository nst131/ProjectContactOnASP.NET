using ContactTask.PresentationService.Interfaces;
using ContactTask.ViewModels;
using System.Web.Mvc;

namespace ContactTask.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly IContactPresentationService presentationService;

        public HomeController(IContactPresentationService presentationService)
        {
            this.presentationService = presentationService;
        }

        [HttpGet]
        public virtual ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public virtual PartialViewResult CreateContact()
        {
            return PartialView(MVC.Home.Views.CreateContact, new CreateContactViewModel());
        }
        [HttpPost]
        public virtual ActionResult CreateContact(CreateContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                presentationService.AddContact(contact);

                return RedirectToAction(MVC.Home.Index());
            }

            return PartialView(MVC.Home.Views.CreateContact, contact);
        }

        [HttpGet]
        public virtual PartialViewResult EditContact(int id)
        {
            return PartialView(MVC.Home.Views.EditeContact, presentationService.GetContactById(id));
        }
        [HttpPost]
        public virtual ActionResult EditContact(EditContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                presentationService.EditContact(contact);

                return RedirectToAction(MVC.Home.Index());
            }

            return PartialView(MVC.Home.Views.EditeContact, contact);
        }

        [HttpGet]
        public virtual PartialViewResult DeleteContact(int id)
        {
            return PartialView(MVC.Home.Views.DeleteContact, presentationService.GetContactById(id));
        }
        [HttpPost]
        public virtual ActionResult DeleteContact(EditContactViewModel contact)
        {
            presentationService.DeleteContact(contact);

            return RedirectToAction(MVC.Home.Index());
        }

        [Route("GetColumnsName")]
        [HttpGet]
        public virtual JsonResult GetColumnsName()
        {
            return Json(presentationService.GetColumnsNameWithoutId(), JsonRequestBehavior.AllowGet);
        }

        [Route("Contact")]
        [HttpGet]
        public virtual JsonResult Get()
        {
            return Json(presentationService.GetAllContacts(), JsonRequestBehavior.AllowGet);
        }
    }
}