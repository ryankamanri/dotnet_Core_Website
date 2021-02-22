using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class Comment
    {
        //评论类
        public int ID { get; set; }
        public int PostID { get; set; }//评论对应的帖子ID
        [Display(Name = "评论")]
        public string Content { get; set; }//评论
        [Display(Name = "评论人")]
        public string Commentator { get; set; }//评论人
    }
}
