
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace KVykhovanets_Lab5.Models.TableModels
{
    public class States
    {
        [Required]
        [Key]
        public int StateID { get; set; }
        [StringLength(50)]
        public string? State { get; set; }
        [StringLength(50)]
        public string? Capital { get; set; }
        public int Population { get; set; }
        [StringLength(200)]
        public string? FlagDescription { get; set; }
        [StringLength(50)]
        public string? Flower { get; set; }
        [StringLength(50)]
        public string? Bird { get; set; }
        [StringLength(50)]
        public string? Colors { get; set; }
        [StringLength(200)]
        public string? LargestCities { get; set; }
        public SqlMoney MedianIncome { get; set; }
        public decimal PercCompRelatedJobs { get; set; }
    }
}
