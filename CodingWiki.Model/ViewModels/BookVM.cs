using CodingWiki.Model.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodingWiki.Model.ViewModels
{
    public class BookVM
    {
        public Book Book { get; set; }
        public IEnumerable<SelectListItem> PublisherList { get; set; }
    }
}
