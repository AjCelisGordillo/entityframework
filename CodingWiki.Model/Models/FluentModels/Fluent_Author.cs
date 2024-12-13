using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingWiki.Model.Models
{
    public class Fluent_Author
    {
        //[Key]
        public int Author_Id { get; set; }
        //[MaxLength(50)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Location { get; set; }
        //[NotMapped]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }
        public List<Fluent_BookAuthorMap> BookAuthorMap { get; set; }
    }
}
