using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClubM.Data;

namespace ProgrammingClubM.Controllers
{
    public class AnnouncementController : Controller
    {
        private Repository.AnnouncementRepository _repository;

        public AnnouncementController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.AnnouncementRepository(dbContext);
        }

        // GET: AnnouncementController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AnnouncementController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AnnouncementController/Create
        public ActionResult Create()
        {
            return View("CreateAnnouncement");
        }

        // POST: AnnouncementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.DBObjects.Announcement model = new Models.DBObjects.Announcement();

                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertAnnouncement(model);
                }

                return View("CreateAnnouncement");
            }
            catch
            {
                return View("CreateAnnouncement");
            }
        }

        // GET: AnnouncementController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AnnouncementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnnouncementController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AnnouncementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
