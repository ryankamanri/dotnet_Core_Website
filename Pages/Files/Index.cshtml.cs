using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.IO;

namespace WebApplication1.Pages.Files
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;
        public static string physicalLocation = Models.LinkAttributes.PublicPhysicalLocation;
        public static string virtualLocation = Models.LinkAttributes.PublicVirtualLocation;
        public static string thisPageLocation = Models.LinkAttributes.FilesPageLocation;
        public IndexModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
            FileList = new List<Models.File>();
            DictionaryList = new List<Models.File>();
        }

        public List<Models.File> FileList { get;set; }
        public List<Models.File> DictionaryList { get; set; }
        [BindProperty(SupportsGet = true)]//绑定名称与属性相同的表单值与查询字符串
        public string SearchString { get; set; }

        public void OnGet()
        {
            Director(physicalLocation,this.DictionaryList, this.FileList);
        }
        public PageResult OnPostClick(string data)//这里参数只能是提交上来的表单属性data,不能改
        {

            if (!Director(physicalLocation + data,DictionaryList, FileList)) return Page();
            return Page();
            //return RedirectToPage(thisPageLocation + "?data="  + data.Replace("\\","%5C") + "&handler=Click");
            //return new JsonResult("receive : " + data);
        }
        //"G:\\ftpShare"
        public static bool Director(string dir, IList<Models.File> DictionaryList,IList<Models.File> FileList)
        {
            try
            {
                DirectoryInfo direct = new DirectoryInfo(dir);
                FileInfo[] files = direct.GetFiles();//文件
                DirectoryInfo[] directs = direct.GetDirectories();//文件夹
                                                                  //获取子文件夹内的文件列表，(no)递归遍历  
                foreach (DirectoryInfo d in directs)
                {
                    DictionaryList.Add(new Models.File("[子目录] " + d.Name, "---", d.LastWriteTime, d.FullName.Replace(physicalLocation, ""), Models.File.Type.Directory));
                    //Director(d.FullName, FilesList);
                }
                foreach (FileInfo f in files)
                {
                    FileList.Add(new Models.File(f.Name, f.Length.ToString(), f.LastWriteTime, f.FullName.Replace(physicalLocation, ""), Models.File.Type.File));//添加文件名到列表中  
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
