using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DELTAXDAL;
using DeltaxWebApp.Models;

namespace DeltaxWebApp.Controllers
{
    public class ActorController : Controller
    {
        public DeltaxRepositoryFile db = new DeltaxRepositoryFile();

        public Models.Actor DAL_to_Client(DELTAXDAL.Actor DALactor)
        {
            Models.Actor actor = new Models.Actor();
            actor.Name = DALactor.Name;
            actor.sex = DALactor.sex;
            actor.bio = DALactor.bio;
            actor.dob = (DateTime)DALactor.dob;
            return actor;
        }
        public DELTAXDAL.Actor Client_To_DAL(Models.Actor Clientactor)
        {
            DELTAXDAL.Actor actor = new DELTAXDAL.Actor();
            actor.Name = Clientactor.Name;
            actor.sex = Clientactor.sex;
            actor.bio = Clientactor.bio;
            actor.dob = (DateTime)Clientactor.dob;
            return actor;
        }
        public ActionResult Index()
        {
            List<Models.Actor> list_of_client_actor = new List<Models.Actor>();
            var list_of_actor = db.GetActorsList();
            foreach (var movie in list_of_actor)
            {
                list_of_client_actor.Add(DAL_to_Client(movie));
            }
            return View(list_of_client_actor);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Actor mv)
        {
            var actor = Client_To_DAL(mv);
            db.AddActor(actor);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string name)
        {
            DELTAXDAL.Actor result = db.GetActorDetails(name);
            var result1 = DAL_to_Client(result);
            return View(result1);
        }
        [HttpPost]
        public ActionResult Edit(Models.Actor mv)
        {
            var actor = Client_To_DAL(mv);
            db.EditActor(actor);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(string name)
        {
            DELTAXDAL.Actor result = db.GetActorDetails(name);
            var actor = DAL_to_Client(result);
            return View(actor);
        }
        [HttpPost]
        public ActionResult Delete(Models.Actor mv)
        {
            var result = Client_To_DAL(mv);
            db.DeleteActor(result);
            return RedirectToAction("Index");
        }
    }
}