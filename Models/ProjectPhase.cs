﻿using System.ComponentModel.DataAnnotations;

namespace WTR_Blazor.Models;

public class ProjectPhase
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int Order { get; set; }
    public bool IsActive { get; set; } = true;
}
