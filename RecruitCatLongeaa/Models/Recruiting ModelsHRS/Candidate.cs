// File: Models/Candidate.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HenchmentRecruitingSolutions.Models
{
    public class Candidate
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; } = null!;

        [Required, StringLength(50)]
        public string LastName { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)"), Range(0, 1_000_000)]
        public decimal TargetSalary { get; set; }

        public DateTime? StartDate { get; set; }

        // — Relationships —
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }

        [Required]
        public int JobTitleId { get; set; }
        public JobTitle JobTitle { get; set; } = null!;

        [Required]
        public int IndustryId { get; set; }
        public Industry Industry { get; set; } = null!;

        // — Additional Properties (6 total; at least one nullable) —
        [Required, EmailAddress, StringLength(100)]
        public string Email { get; set; } = null!;

        [Phone, StringLength(20)]
        public string? PhoneNumber { get; set; }

        [Range(0, 50)]
        public int YearsOfExperience { get; set; }

        public bool IsActive { get; set; } = true;

        [Range(0, 100)]
        public decimal ProfileCompletionPercentage { get; set; }

        [Url, StringLength(200)]
        public string? LinkedInProfileUrl { get; set; }
    }
}