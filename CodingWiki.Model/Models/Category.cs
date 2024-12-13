using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingWiki.Model.Models
{
    // way to change table name
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }
        [Column("Name")]
        [Required]
        public string CategoryName { get; set; }
        //public int DisplayOrder { get; set; }
    }
}
