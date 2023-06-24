using System.ComponentModel.DataAnnotations;

namespace BtkAkademi.Models
{
    public class Candidate
    {
        public Candidate()
        {
            ApplyAt = DateTime.Now;
        }
        [Required(ErrorMessage = "E-mail is required.")]
        public string? Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "FirstName is required.")]
        public string? FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "LastName is required.")]
        public string? LastName { get; set; } = string.Empty;
        public string? FullName => $"{FirstName} {LastName?.ToUpper()}";
        [Required(ErrorMessage = "Age is required.")]
        public int? Age { get; set; }
        [Required(ErrorMessage = "Course is required.")]
        public string? SelectedCourse { get; set; } = string.Empty;
        public DateTime ApplyAt { get; set; }
    }
}