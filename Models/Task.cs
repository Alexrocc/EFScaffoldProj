using System;
using System.Collections.Generic;

namespace EFScaffoldProj.Models;

public partial class Task
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Status { get; set; }

    public string? Priority { get; set; }

    public DateOnly? DueDate { get; set; }

    public int? ProjectsId { get; set; }

    public int? UsersId { get; set; }

    public virtual Project? Projects { get; set; }

    public virtual ICollection<TaskAttachment> TaskAttachments { get; set; } = new List<TaskAttachment>();

    public virtual User? Users { get; set; }
}
