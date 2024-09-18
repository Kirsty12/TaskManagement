using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace TaskManagementSystem.Models
{
    public class TaskItem
    {
        [Key]
        public int Id {get; set;}
        [Required]
        public string Title {get; set;}
        public bool IsComplete {get; set;}
        
        [DataType(DataType.Date)]
        public DateTime DueDate {get; set;}
    }
}