// File: Models/Company.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HenchmentRecruitingSolutions.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = null!;

        // The one position this company is recruiting for right now
        [Required, StringLength(100)]
        public string PositionName { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)"), Range(0, 1_000_000)]
        public decimal MinSalary { get; set; }

        [Column(TypeName = "decimal(18,2)"), Range(0, 1_000_000)]
        public decimal MaxSalary { get; set; }

        public DateTime? StartDate { get; set; }

        [Required, StringLength(100)]
        public string Location { get; set; } = null!;

        // — Relationships —
        [Required]
        public int IndustryId { get; set; }
        public Industry Industry { get; set; } = null!;

        public ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();

        // — Additional Properties —
        [Range(1, int.MaxValue)]
        public int NumberOfEmployees { get; set; }

        public bool IsPubliclyTraded { get; set; }

        [DataType(DataType.Date)]
        public DateTime FoundedDate { get; set; }

        [Url, StringLength(200)]
        public string? WebsiteUrl { get; set; }
    }
}