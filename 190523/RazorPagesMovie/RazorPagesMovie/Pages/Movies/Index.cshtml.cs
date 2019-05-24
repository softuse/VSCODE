using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Models.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Models.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }
        public async Task OnGetAsync()
        {
            // Movie = await _context.Movie.ToListAsync();
            var movies=from movie in _context.Movie
                        select movie;
            var genreList=from m in _context.Movie orderby m.Genre select m.Genre;

            //加入查询条件 //加入查询条件 //加入查询条件 //加入查询条件
           // 1.先判断是否为空
           // 2.查询包含字符串的条件
            if(!string.IsNullOrEmpty(SearchString))
            {
                //The Contains method is run on the database, not in the C# code.
                movies=movies.Where(movie=>movie.Title.Contains(SearchString));  
                
            }
            if(!string.IsNullOrEmpty(MovieGenre))
            {
                //The Contains method is run on the database, not in the C# code.
                movies=movies.Where(movie=>movie.Genre==MovieGenre);  
                
            }

            Genres=new SelectList(await genreList.Distinct().ToListAsync());
            Movie=await movies.ToListAsync();
        }
    }
}
