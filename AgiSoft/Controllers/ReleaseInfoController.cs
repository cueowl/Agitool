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

        public ActionResult ReleaseInfo()
        {
            return View();
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
