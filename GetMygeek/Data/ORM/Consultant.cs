﻿namespace GetMygeek.Data.ORM;
public class Consultant
{
    public long IdConsultant { get; set; }
    public string Nom { get; set; }
    public string Trigramme { get; set; }
    public string Tel { get; set; }
    public string Mail { get; set; }
    public string DdcUrl { get; set; }
    public long? IdMission { get; set; }
    public string ResponsableCarriere { get; set; }
    public int? Anciennete { get; set; }
    public string? Disponibilite { get; set; }
    public long? IdPrefDomain { get; set; }
    public string ImageUrl { get; set; }
}
