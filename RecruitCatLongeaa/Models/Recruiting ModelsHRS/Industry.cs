// File: Models/Industry.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HenchmentRecruitingSolutions.Models
{
    public class Industry
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = null!;

        public ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
        public ICollection<Company> Companies { get; set; } = new List<Company>();
    }
}