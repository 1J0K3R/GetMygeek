namespace GetMygeek.Models;
public class Profil
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string NameTrigramme { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string PhoneNumber { get; set; }
    public string Mail { get; set; }
    public bool IsFree { get; set; }
    public Ddc Ddc { get; set; }
}
