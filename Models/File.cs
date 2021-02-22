using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;

namespace WebApplication1.Models
{
    public class File
    {
        
        public int ID { get; set; }//数据库获取主键
        [Display(Name = "文件名")]
        public string FileName { get; set; }
        [Display(Name = "文件大小")]
        public string Length { get; set; }
        [Display(Name = "修改日期")]
        public DateTime LastWriteTime { get; set; }
        [Display(Name = "目录")]
        public string VirtualRoute { get; set; }
        public enum Type { File, Directory };//定义文件类型枚举类
        public Type type;
        public File(string FileName,string Length,DateTime LastWriteTime,string VirtualRoute,Type type)
        {
            this.FileName = FileName;
            this.Length = Length;
            this.LastWriteTime = LastWriteTime;
            this.VirtualRoute = VirtualRoute;
            this.type = type;
        }
        public override string ToString()
        {
            return FileName + "\"" + Length + "\"" + LastWriteTime.ToString() + "\"" + VirtualRoute;
        }
    }
}
