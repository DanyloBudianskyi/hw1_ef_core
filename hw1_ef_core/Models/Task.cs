using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw1_ef_core.Models
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}" +
                $"\nDescription: {Description}," +
                $"\nStatus: {(IsCompleted ? "Completed" : "In progress")}" +
                $"\nCreation date: {CreateDate.Day}.{CreateDate.Month}.{CreateDate.Year}";
        }
    }
}
