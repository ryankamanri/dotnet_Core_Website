using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Posts
{
    public class IndexPostModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;
        [BindProperty(SupportsGet = true)]//绑定名称与属性相同的表单值与查询字符串
        public string SearchString { get; set; }

        public IndexPostModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; }

        public async Task OnGetAsync()
        {
            var posts = from p in _context.Post//linq查询语句
                           select p;
            if (!string.IsNullOrEmpty(SearchString))
            {
                posts = posts.Where(p => (p.Title.Contains(SearchString) || p.CoTitle.Contains(SearchString) || p.Sender.Contains(SearchString)));
            }// lambda表达式为linq查询的标准查询运算符方法的参数
            Post = await posts.ToListAsync();
        }
    }
}
