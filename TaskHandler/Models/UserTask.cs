using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetersReader.Models
{
    public class UserTask
    {
        [Key]
        public int Id { get; set; }
        [StringLength(28, ErrorMessage = "Длина названия не может превышать 28 символов.")]
        [Required(ErrorMessage = "Пожалуйста, укажите название")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "Длина описания не может превышать 200 символов.")]
        [Display(Name = "Описание")]
        
        public string? Description { get; set; } = string.Empty;
        public bool isDone { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime DateCreated { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? DateFinished { get; set; }
    }
}
