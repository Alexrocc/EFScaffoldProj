using EFScaffoldProj.Models;
using Microsoft.EntityFrameworkCore;

using (var context = new PmsapiContext())
{
    foreach (var el in context.Tasks.Include(e => e.Projects).ToList())
    {
        Console.WriteLine($"{el.Id}");
    }
}
