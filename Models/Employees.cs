using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Models  
{  
    public class Employees
    {  
        public int Id { get; set; }  
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Name")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Длина login'a от 3 до 30 символов")]
        public string Name { get; set; }  
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Discription")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Длина описания до 150 символов")]  
        public string Discription { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Category")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Длина описания до 150 символов")]  
        public string Category { get; set; } 
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "TelNumber")]
        [StringLength(12, ErrorMessage = "номер телефона 12 сиволов(с +7ы)")]  
        public string TelNumber { get; set; } 
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "ImgRes")]
        public string ImgRes { get; set; }  
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Price")]
        [Range(typeof(int),"500", "50000", ErrorMessage = "Цена от 500 - 50000")]
        public int Price {get;set;}
        [Required]
        [Display(Name = "Owner")]
        public string Owner {get; set;}
    
    }  
}