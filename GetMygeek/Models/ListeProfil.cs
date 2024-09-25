using GetMygeek.Data.ORM;

namespace GetMygeek.Models;
public class ListeProfil
{
    public IEnumerable<Consultant> Consultants { get; set; }
}