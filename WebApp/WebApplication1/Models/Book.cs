using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Book
    {
       
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please Fill Book Name")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Please Fill Book Type")]
        [MaxLength(200, ErrorMessage = "Max 200 Char")]

        public string BookType { get; set; }
        public ICollection<BookAuthor> Book_Authers{get;set;}

    }
 
}

