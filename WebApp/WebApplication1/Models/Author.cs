using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Author
    {
        [Key]
        public int AutherId { get; set; }

        [Required(ErrorMessage ="Please Fill Auther Name")]
        public string AutherName { get; set; }

        [Required(ErrorMessage = "Please Fill Mail")]
        public string Mail { get; set; }

        public ICollection<BookAuthor> book_Authers { get; set; }
    }
}
