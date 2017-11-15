using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    [Table("Details")]
    public class Details
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        [StringLength(100),Required]

        public string Url { get; set; }
        [StringLength(100),Required]
        public string Email { get; set; }
        [StringLength(100),Required]
        public string Password { get; set; }
        [StringLength(1000),Required]
        public string Description { get; set; }

        public string UserId { get; set; }
    }

}