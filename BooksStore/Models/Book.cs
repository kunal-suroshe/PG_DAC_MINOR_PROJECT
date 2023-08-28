using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksStore.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        [DisplayName("Book Title")]
        [Required(ErrorMessage ="This field is Required")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Book Genre")]
        [Required(ErrorMessage = "This field is Required")]
        public string Genre { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Book Publisher")]
        [Required(ErrorMessage = "This field is Required")]
        public string Publisher { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [DisplayName("Book Author")]
        [Required(ErrorMessage = "This field is Required")]
        public string Author { get; set; }

        
        [DisplayName("Total Pages")]
        [Required(ErrorMessage = "This field is Required")]
        public int Total_pages { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yy}")]
        public DateTime Date { get; set; }
    }
}
