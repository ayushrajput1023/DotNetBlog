using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebAPI.Models
{
    public class Post
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Column]
        [Required]
        [StringLength(10)]
        public string Title { get; set; }

        [Column]
        [Required]
        [StringLength(211)]
        public string Content { get; set; }

        [Column]
        [Required]
        public int Page { get; set; }
    }
}
