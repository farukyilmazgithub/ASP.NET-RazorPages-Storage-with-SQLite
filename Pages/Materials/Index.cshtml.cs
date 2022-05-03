using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using storage.Models;

namespace storage.Pages.Materials
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesItemContext _context;

        public IndexModel(RazorPagesItemContext context)
        {
            _context = context;
        }

        public IList<Material> Material { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MaterialGenre { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Material
                                            orderby m.Genre
                                            select m.Genre;

            var materials = from m in _context.Material
                        select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                materials = materials.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MaterialGenre))
            {
                materials = materials.Where(x => x.Genre == MaterialGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Material = await materials.ToListAsync();
            }
    }
}
