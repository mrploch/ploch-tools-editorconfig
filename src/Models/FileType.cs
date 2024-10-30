﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ploch.Data.Model;

namespace Ploch.EditorConfigTools.Models;

public class FileType : IHasId<int>
{
    public int Id { get; set; }

    public string? Name { get; set; }

    [Required]
    public virtual ICollection<FileExtension> FileExtensions { get; set; } = null!;

    public virtual ICollection<FilePattern> FilePatterns { get; set; } = null!;
}