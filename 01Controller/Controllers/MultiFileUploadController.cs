using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01Controller.Controllers
{
    public class MultiFileUploadController : Controller
    {
        
        public ActionResult Create()
        {
            return View();
        }
    

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase[] photos)
        {
            
            if(photos != null)
            {
                foreach(var photo in photos)
                {

                    if (photo.ContentLength > 0)
                    {
                        string subName = "";
                        string nowStr = DateTime.Now.ToString("yyyyMMddhhmmssff") ; //取時間
                        subName = photo.FileName.Substring(photo.FileName.IndexOf(".") + 1, 3);
                        subName = subName.ToLower();
                        if (subName == "jpg" || subName == "png" || subName == "gif")
                        {                                                    //給變數
                            photo.SaveAs(Server.MapPath("~/photos/" +nowStr+Guid.NewGuid().ToString()+"."+subName));
                            ViewBag.Message = "上傳成功";
                            
                        }
                        
                    }
                }
            }
            else
            {
                ViewBag.Message="您沒有上傳任何檔案";
            }

            return View();
        }

        public string ShowPhotos()
        {
            string show = "";
            DirectoryInfo d = new DirectoryInfo(Server.MapPath("~/photos/"));
            FileInfo[] files = d.GetFiles();

            foreach (FileInfo item in files)
            {
                show += "<img src=../photos/" + item.Name + " />"; //從controllers開始 而非根目錄 所以不使用邏輯路徑
            }
            show += "<hr><a href='/MultiFileUpload/Create'>點我回上傳檔案頁面</a>";


            return show;
        }
    }



}

