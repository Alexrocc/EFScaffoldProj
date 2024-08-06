using System;
using System.Collections.Generic;

namespace EFScaffoldProj.Models;

public partial class Project
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? ProjectCategoriesId { get; set; }

    public int? UsersManagerId { get; set; }

    public virtual ProjectCategory? ProjectCategories { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual User? UsersManager { get; set; }
}
