namespace GetMygeek.Models;
public class ResearchQuery
{
    public string input { get; set; } = null;
    public string available { get; set; } = null;
    public int? anciennete { get; set; } = null;
    public IEnumerable<string> profilesSelected { get; set; } = new HashSet<string>() { };

    public bool IsImplement()
    {
        if (input is not null || available is not null || anciennete is not null || profilesSelected.Count()>0)
        {
            return true;
        }else 
        {
            return false;
        }
    }
}