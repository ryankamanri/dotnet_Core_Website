using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class Post
    {
        //帖子类
        public int ID { get; set; }//帖子的ID号
        [Display(Name = "发帖人")]
        public string Sender { get; set; }//发帖人
        [Display(Name = "密钥")]
        public string Password { get; set; }//发帖人密码
        [Display(Name = "标题")]
        public string Title { get; set; }//标题
        [Display(Name = "副标题")]
        public string CoTitle{ get; set; }//副标题
        [Display(Name = "正文")]
        public string Text { get; set; }//正文
        public IList<Comment>? Comments { get; set; }
    }
}
