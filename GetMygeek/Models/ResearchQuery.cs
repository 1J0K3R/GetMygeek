namespace GetMygeek.Models;
    public class ResearchQuery
    {
        public string input { get; set; }
        public string available { get; set; }
        public int anciennete { get; set; }
        public IEnumerable<string> profilesSelected { get; set; } = new HashSet<string>() { };
    }