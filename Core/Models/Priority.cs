using System.ComponentModel.DataAnnotations.Schema;

namespace EFScaffoldProj.Core.Models;
public class Priority
{

    public int PriorityId { get; set; }

    public string PriorityDef { get; set; } = "";

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<Models.Task> Tasks { get; set; } = new List<Models.Task>();
}