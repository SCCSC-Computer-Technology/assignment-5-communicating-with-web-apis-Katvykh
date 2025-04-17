using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace KVykhovanets_Lab5_MVC.Models
{
    [Table("State")]
    public class States
    {
        //error messages will handle possible issues when creating or editing a state
        //if the data entered doesnt work with the data type
        [Required]
        [Key]
        public int StateID { get; set; }

        [Required(ErrorMessage = "State name is required.")]
        [StringLength(50, ErrorMessage = "State name cannot exceed 50 characters.")]
        public string? State { get; set; }

        [Required(ErrorMessage = "Capital is required.")]
        [StringLength(50, ErrorMessage = "Capital name cannot exceed 50 characters.")]
        public string? Capital { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Population must be a positive number.")]
        public int Population { get; set; }

        [StringLength(200, ErrorMessage = "Flag description cannot exceed 200 characters.")]
        public string? FlagDescription { get; set; }

        [StringLength(50, ErrorMessage = "Flower name cannot exceed 50 characters.")]
        public string? Flower { get; set; }

        [StringLength(50, ErrorMessage = "Bird name cannot exceed 50 characters.")]
        public string? Bird { get; set; }

        [StringLength(50, ErrorMessage = "Colors cannot exceed 50 characters.")]
        public string? Colors { get; set; }

        [StringLength(200, ErrorMessage = "Largest cities list cannot exceed 200 characters.")]
        public string? LargestCities { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Median income must be a non-negative number.")]
        public decimal MedianIncome { get; set; }

        [Range(0, 100, ErrorMessage = "Percentage of computer-related jobs must be between 0 and 100.")]
        public decimal PercCompRelatedJobs { get; set; }
    }
}
