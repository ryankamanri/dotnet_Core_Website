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
                //��ȡ�ļ���
                string fileName = Request.Form.Files[0].FileName;
                //���յ���POST������ȡ�������ļ���(������������)
                Stream file = Request.Form.Files[0].OpenReadStream();
                //�����ļ������ڱ��ص�λ��
                string filePath = privatePhysicalLocation + "\\" + fileName;
                //���ļ�������(�����ڱ��ص���)
                FileStream fstream = new FileStream(filePath, FileMode.Create);
                //��ʼ���ֽ�������Ϊ������
                byte[] bytes = new byte[file.Length];
                //�����ļ����򻺳���
                file.Read(bytes, 0, (int)file.Length);
                //�����������ļ�������
                fstream.Write(bytes, 0, (int)file.Length);
                //���ؽ��
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
