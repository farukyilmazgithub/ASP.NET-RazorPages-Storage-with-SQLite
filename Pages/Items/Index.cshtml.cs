using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using storage.Models;

namespace storage.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesItemContext _context;

        public IndexModel(RazorPagesItemContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ItemGenre { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from i in _context.Item
                                            orderby i.Genre
                                            select i.Genre;

            var items = from m in _context.Item
                        select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                items = items.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ItemGenre))
            {
                items = items.Where(x => x.Genre == ItemGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Item = await items.ToListAsync();
            }
    }
}
