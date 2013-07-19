using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgiSoft.Models;

namespace AgiSoft.Controllers
{
    public class ReleaseInfoController : Controller
    {
        private AgiSoftDb db = new AgiSoftDb();

        //
        // GET: /ReleaseInfo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReleaseInfo(int id = 0)
        {
            ReleaseInfo model = new Models.ReleaseInfo();
            var existrelease = (from ReleaseInfo e1 in db.ReleaseInfo
                                join ProjRelInfo e2 in db.ProjRelInfo on e1.ReleaseId equals e2.ReleaseId into temp
                                from e2 in temp.DefaultIfEmpty()
                                where e2.ProjectId == id
                                select new { e1.BuildCompleteDT, e1.ReleaseId, e1.ReleaseYear, e1.RelMonth, e1.DesignDT, e1.RequirementsDT, e1.SITEndDT, e1.SITStartDT, e1.TurnDT, e1.UATEndDT, e1.UATStartDT }).ToList();

            if (existrelease.Count > 0)
            {
                ViewBag.ReleaseYear = existrelease[0].ReleaseYear;
                ViewBag.BuildCompleteDT = existrelease[0].BuildCompleteDT;
                ViewBag.DesignDT = existrelease[0].DesignDT;
                ViewBag.ReleaseId = existrelease[0].ReleaseId;
                ViewBag.RelMonth = existrelease[0].RelMonth;
                ViewBag.RequirementsDT = existrelease[0].RequirementsDT;
                ViewBag.SITEndDT = existrelease[0].SITEndDT;
                ViewBag.SITStartDT = existrelease[0].SITStartDT;
                ViewBag.TurnDT = existrelease[0].TurnDT;
                ViewBag.UATEndDT = existrelease[0].UATEndDT;
                ViewBag.UATStartDT = existrelease[0].UATStartDT;
                ViewBag.ReleaseInfo = existrelease;
                model.ReleaseYear = existrelease[0].ReleaseYear;
                model.RelMonth = existrelease[0].RelMonth;
            }


            return View(model);
        }

        // POST: /Admin/RolesCreate/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ReleaseInfo(ReleaseInfo releaseinfos, FormCollection frm, int id = 0)
        {
            int i = 0;
            if (ModelState.IsValid)
            {
                if (frm["sitenddate"] == "")
                    frm["sitenddate"] = "01/01/1990";
                releaseinfos.SITEndDT = Convert.ToDateTime(frm["sitenddate"]);

                if (frm["sitstartdate"] == "")
                    frm["sitstartdate"] = "01/01/1990";
                releaseinfos.SITStartDT = Convert.ToDateTime(frm["sitstartdate"]);

                if (frm["turndate"] == "")
                    frm["turndate"] = "01/01/1990";
                releaseinfos.TurnDT = Convert.ToDateTime(frm["turndate"]);

                if (frm["uatenddate"] == "")
                    frm["uatenddate"] = "01/01/1990";
                releaseinfos.UATEndDT = Convert.ToDateTime(frm["uatenddate"]);

                if (frm["uatstartdate"] == "")
                    frm["uatstartdate"] = "01/01/1990";
                releaseinfos.UATStartDT = Convert.ToDateTime(frm["uatstartdate"]);

                if (frm["designdate"] == "")
                    frm["designdate"] = "01/01/1990";
                releaseinfos.DesignDT = Convert.ToDateTime(frm["designdate"]);

                if (frm["reqdate"] == "")
                    frm["reqdate"] = "01/01/1990";
                releaseinfos.RequirementsDT = Convert.ToDateTime(frm["reqdate"]);

                if (frm["buildcompletedate"] == "")
                    frm["buildcompletedate"] = "01/01/1990";
                releaseinfos.BuildCompleteDT = Convert.ToDateTime(frm["buildcompletedate"]);

                db.ReleaseInfo.Add(releaseinfos);
                db.SaveChanges();
                i = 1;


                var releaseid = (from e in db.ReleaseInfo
                                 orderby e.ReleaseId descending
                                 select e).ToList();

                ProjRelInfo model = new ProjRelInfo();
                model.ReleaseId = releaseid[0].ReleaseId;
                model.ProjectId = id;
                db.ProjRelInfo.Add(model);
                db.SaveChanges();

                return Json("../ReleaseInfo/ReleaseInfos");
            }
            return Json(new { result = i }, JsonRequestBehavior.AllowGet);
        }

        // GET: /Team/Teams
        public ActionResult ReleaseInfos()
        {
            return View(db.ReleaseInfo.ToList());
        }

        // GET: /Admin/RolesDetails
        public ActionResult ReleaseInfosDetails(int id = 0)
        {
            ReleaseInfo releaseinfos = db.ReleaseInfo.Find(id);

            if (releaseinfos == null)
            {
                return HttpNotFound();
            }
            if (releaseinfos != null)
            {
                ViewBag.Type = "releaseinfo";
            }

            return View(releaseinfos);
        }

        // GET: /Admin/RolesCreate
        public ActionResult ReleaseInfosCreate()
        {
            return View();
        }

        // POST: /Admin/RolesCreate/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReleaseInfosCreate(ReleaseInfo releaseinfos, FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                if (frm["sitenddate"] == "")
                    frm["sitenddate"] = "01/01/1990";
                releaseinfos.SITEndDT = Convert.ToDateTime(frm["sitenddate"]);

                if (frm["sitstartdate"] == "")
                    frm["sitstartdate"] = "01/01/1990";
                releaseinfos.SITStartDT = Convert.ToDateTime(frm["sitstartdate"]);

                if (frm["turndate"] == "")
                    frm["turndate"] = "01/01/1990";
                releaseinfos.TurnDT = Convert.ToDateTime(frm["turndate"]);

                if (frm["uatenddate"] == "")
                    frm["uatenddate"] = "01/01/1990";
                releaseinfos.UATEndDT = Convert.ToDateTime(frm["uatenddate"]);

                if (frm["uatstartdate"] == "")
                    frm["uatstartdate"] = "01/01/1990";
                releaseinfos.UATStartDT = Convert.ToDateTime(frm["uatstartdate"]);

                if (frm["designdate"] == "")
                    frm["designdate"] = "01/01/1990";
                releaseinfos.DesignDT = Convert.ToDateTime(frm["designdate"]);

                if (frm["reqdate"] == "")
                    frm["reqdate"] = "01/01/1990";
                releaseinfos.RequirementsDT = Convert.ToDateTime(frm["reqdate"]);

                if (frm["buildcompletedate"] == "")
                    frm["buildcompletedate"] = "01/01/1990";
                releaseinfos.BuildCompleteDT = Convert.ToDateTime(frm["buildcompletedate"]);

                db.ReleaseInfo.Add(releaseinfos);
                db.SaveChanges();

                return RedirectToAction("ReleaseInfos");
            }
            return View(releaseinfos);
        }

        // GET: /Admin/RolesEdit
        public ActionResult ReleaseInfosEdit(int id, FormCollection frm)
        {
            ReleaseInfo releaseinfos = db.ReleaseInfo.Find(id);
            frm["requirementdt"] = "02/04/2013";
            List<ReleaseInfo> rlist = null;

            if (releaseinfos == null)
            {
                return HttpNotFound();
            }

            if (releaseinfos != null)
            {
                ViewBag.Type = "releaseinfo";
            }

            return View(releaseinfos);
        }

        // POST: /Admin/RolesEdit/5
        [HttpPost]
        public ActionResult ReleaseInfosEdit(ReleaseInfo releaseinfos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(releaseinfos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ReleaseInfos");
            }

            return View(releaseinfos);
        }

        // GET: /Admin/RolesDelete
        public ActionResult ReleaseInfosDelete(int id = 0)
        {
            ReleaseInfo releaseinfos = db.ReleaseInfo.Find(id);
            if (releaseinfos == null)
            {
                return HttpNotFound();
            }/*
            else
            {
                db.Team.Remove(teams);
                db.SaveChanges();
                return RedirectToAction("Teams");
            }*/
            return View(releaseinfos);
        }


    }
}
