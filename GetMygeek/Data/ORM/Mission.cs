﻿namespace GetMygeek.Data.ORM;
public class Mission
{
    /// <summary>
    /// Id de la mission
    /// </summary>
    public long IdMission { get; set; }

    /// <summary>
    /// Entreprise au sein de laquelle est effectuée la mission
    /// </summary>
    public string Entreprise { get; set; }

    /// <summary>
    /// Ingénieure d'affaire responsable de la mission 
    /// </summary>
    public string ResponsableMission { get; set; }

    /// <summary>
    /// Fiche de poste de la mission 
    /// </summary>
    public string FicheDePoste { get; set; }
}