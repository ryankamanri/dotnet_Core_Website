using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bond.Tag;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Posts
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public DetailsModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
            Comment = new Comment();
        }

        public Post Post { get; set; }
        public IList<Comment> Comments { get; set; }//评论列表
       
        [BindProperty]
        public Comment Comment { get; set; }//要发表的评论

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await _context.Post.FirstOrDefaultAsync(m => m.ID == id);
     
            var comment = from c in _context.Comment//linq查询语句
                           select c;

                comment = comment.Where(c => (c.PostID == Post.ID));
            // lambda表达式为linq查询的标准查询运算符方法的参数

            Comments = await comment.ToListAsync();
            if (Post == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            Comment.PostID = (int)id;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Comment.Add(Comment);
            await _context.SaveChangesAsync();
            await OnGetAsync(id);
            return Page();
        }
    }
    

}
