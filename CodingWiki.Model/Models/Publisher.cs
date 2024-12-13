using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingWiki.Model.Models
{
    public class Publisher
    {
        [Key]
        public int Publisher_Id { get; set; }
        public string Name { get; set; }
        public string? Location { get; set; }
        public List<Book> Books { get; set; }
    }
}
