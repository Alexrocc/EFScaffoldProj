﻿namespace EFScaffoldProj.Core.Models;

public partial class User
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int RoleId { get; set; }
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    public virtual Role Role { get; set; } = null!;
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}