using System;
using System.ComponentModel.DataAnnotations;
using EpamBlog.ValidationAttributes;


namespace EpamBlog.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        public DateTime Published { get; set; }
         
        [Required ( ErrorMessage = "Please, enter your name" )]
        public string Author { get; set; }

        [Required ( ErrorMessage = "This field cannot be empty" )]
        [TextValidation( new string[] { "iframe", "object", "script" }, ErrorMessage = "You cannot use words like 'iframe', 'object' and 'script'" ) ]
        public string Text { get; set; }
        
    }
    
}