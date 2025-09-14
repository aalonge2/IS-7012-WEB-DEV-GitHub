// File: Models/JobTitle.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HenchmentRecruitingSolutions.Models
{
    public class JobTitle
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)"), Range(0, 1_000_000)]
        public decimal MinSalary { get; set; }

        [Column(TypeName = "decimal(18,2)"), Range(0, 1_000_000)]
        public decimal MaxSalary { get; set; }

        public ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();

        // — Additional Properties —
        [StringLength(500)]
        public string? Description { get; set; }

        [Range(0, 30)]
        public int RequiredExperienceYears { get; set; }

        public bool IsManagementTrack { get; set; }
    }
}