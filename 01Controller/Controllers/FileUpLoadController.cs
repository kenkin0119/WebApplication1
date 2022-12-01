using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01Controller.Controllers
{
    public class FileUpLoadController : Controller
    {
        
        public ActionResult Create()
        {

            
            return View();
        }




        [HttpPost]
        public ActionResult Create(HttpPostedFileBase photo)
        {

            //   \:是保留字 所以要用溢出字元:\   
            //要寫完整儲存路徑 但無法確定Server實際路徑 所以要用邏輯根目錄Server.MapPath把邏輯路徑轉實際路徑

            //"D:\\Visual studio\\WebApplication1\\01Controller\\photos\\"+photo.FileName 
            string a = "";
            if(photo != null)
            {
                if (photo.ContentLength>0)
                {
                    if (photo.ContentLength<=5242880) //單位:位元組byte
                    {                                  //抓起始索引值，找到.
                        a = photo.FileName.Substring(photo.FileName.IndexOf(".") + 1, 3); //抓副檔名
                        a = a.ToLower(); //轉小寫
                        if (a == "jpg" || a=="png" || a=="gif")
                        {
                            photo.SaveAs(Server.MapPath("~/photos/" + photo.FileName));
                            ViewBag.Message = "檔案上傳成功";
                        }
                        
                        else
                        {
                            ViewBag.Message = "檔案格式錯誤";
                        }    
                    }
                    
                    else
                    {
                        ViewBag.Message = "檔案大於5MB";
                    }
                }
               
                else
                {
                    ViewBag.Message = "您傳的是一個空檔案";
                }
            }
            else
            {
                ViewBag.Message = "您沒有選擇檔案";
            }



            return View();
        }


        //寫一個顯示photo資料夾中所有照片的功能(一般函數)
        public string ShowPhotos()
        {
            string show = "";
            DirectoryInfo d = new DirectoryInfo(Server.MapPath("~/photos/"));
            FileInfo[] files = d.GetFiles();

            foreach (FileInfo item in files)
            {
                show += "<img src=../photos/" + item.Name + " />"; //從controllers開始 而非根目錄 所以不使用邏輯路徑
            }
            show += "<hr><a href='/FileUpLoad/Create'>點我回上傳檔案頁面</a>";


            return show;
        }
    }
}