using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class VideoController : BaseController
    {
        VideoBLL bll = new VideoBLL();

        public ActionResult AddVideo()
        {
            VideoDTO dto = new VideoDTO();
            return View(dto);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddVideo(VideoDTO model)
        {
            if (ModelState.IsValid)
            {
                string path = model.OriginalVideoPath.Substring(32);
                string mergeLink = "https://www.youtube.com/embed/";
                mergeLink += path;
                model.VideoPath = String.Format(@"< iframe width = ""733"" height = ""412"" src = ""{0)"" frameborder = ""0"" allow = ""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"" allowfullscreen ></ iframe > ", mergeLink);

                //old
                /*model.VideoPath = String.Format(@"<iframe width = ""300"" height = ""200"" src = ""{0}"" frameborder = ""0""  allowfullscreen ></iframe> ", mergeLink);*/

                if (bll.AddVideo(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new VideoDTO();
                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;
            }
            else
                ViewBag.ProcessState = General.Messages.EmptyArea;

            return View(model);
        }

        public ActionResult VideoList()
        {
            List<VideoDTO> list = new List<VideoDTO>();
            list = bll.GetVideos();
            return View(list);
        }

        public ActionResult UpdateVideo(int ID)
        {
            VideoDTO dto = new VideoDTO();
            dto = bll.GetVideoWithID(ID);
            return View(dto);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateVideo(VideoDTO model)
        {
            if (ModelState.IsValid)
            {
                string path = model.OriginalVideoPath.Substring(32);
                string mergeLink = "https://www.youtube.com/embed/";
                mergeLink += path;
                model.VideoPath = String.Format(@"<iframe width = ""300"" height = ""200"" src = ""{0}"" frameborder = ""0""  allowfullscreen ></iframe> ", mergeLink);

                if (bll.UpdateVideo(model))
                {
                    ViewBag.ProcessState = General.Messages.UpdateSuccess;
                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;
            }
            else
                ViewBag.ProcessState = General.Messages.EmptyArea;

            return View(model);
        }

        public JsonResult DeleteVideo(int ID)
        {
            bll.DeleteVideo(ID);
            return Json("");
        }
    }
}