using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace WebApplication1.Pages.Upload
{
    public class IndexModel : PageModel
    {
        public static string thisPageLocation = Models.LinkAttributes.UploadPageLocation;
        public static string privatePhysicalLocation = Models.LinkAttributes.PrivatePhysicalLocation;
        public static string thisURL = Models.LinkAttributes.ThisURL;
        public Models.File newFile;

        public IndexModel(WebApplication1.Data.WebApplication1Context context)
        {

        }
        public PageResult OnGet()
        {
            return Page();
        }

        public JsonResult OnPostUpload()
        {
            try
            {
                //获取文件名
                string fileName = Request.Form.Files[0].FileName;
                //从收到的POST请求中取出输入文件流(从网络来的流)
                Stream file = Request.Form.Files[0].OpenReadStream();
                //设置文件保存在本地的位置
                string filePath = privatePhysicalLocation + "\\" + fileName;
                //打开文件接收流(保存在本地的流)
                FileStream fstream = new FileStream(filePath, FileMode.Create);
                //初始化字节数组作为缓冲区
                byte[] bytes = new byte[file.Length];
                //输入文件流向缓冲区
                file.Read(bytes, 0, (int)file.Length);
                //缓冲区流向文件接受流
                fstream.Write(bytes, 0, (int)file.Length);
                //返回结果
                newFile = new Models.File(fileName, file.Length.ToString(), DateTime.Now, "/Private", Models.File.Type.File);

                fstream.Close();
                file.Close();
                return new JsonResult(newFile.ToString());//Success
            }
            catch (Exception)
            {
                return new JsonResult(405);// Error
            };
        }
    }
}
