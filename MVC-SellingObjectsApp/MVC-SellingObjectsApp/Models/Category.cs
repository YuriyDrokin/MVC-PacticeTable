﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations; // data annotation 

namespace MVC_SellingObjectsApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //modifying attributes
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage = "Display Order must be between 1 and 100 only")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now; // assigned time to now when created
    }
}
