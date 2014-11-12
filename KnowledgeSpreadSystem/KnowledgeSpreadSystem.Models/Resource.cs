﻿namespace KnowledgeSpreadSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using KnowledgeSpreadSystem.Data.Common.Models;
    using KnowledgeSpreadSystem.Models.Enums;

    public class Resource : AuditInfo, IDeletableEntity
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string FileExtension { get; set; }

        [Required]
        public string MIMEType { get; set; }

        public virtual CourseModule Module { get; set; }

        [Required]
        public int ModuleId { get; set; }

        public virtual Course Course { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        public byte[] Content { get; set; }

        public int Rating { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}