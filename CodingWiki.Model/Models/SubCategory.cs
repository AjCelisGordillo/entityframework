using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingWiki.Model.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategory_Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
