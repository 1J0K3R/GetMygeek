namespace GetMygeek.Models;
public class ParametreRecherche
{
    /// <summary>
    /// Le contenu du champs rechercher.
    /// </summary>
    public string NomRecherche { get; set; } = null;

    /// <summary>
    /// La disponibilite du consultant recherche. Peut prendre les valeurs null, disponible, enMission.
    /// </summary>
    public string Disponibilite { get; set; } = null;

    /// <summary>
    /// L'anciennete minimale du consultant recherche.
    /// </summary>
    public int? Anciennete { get; set; } = null;

    /// <summary>
    /// Une liste des types de missions recherchees par le consultant.
    /// </summary>
    public IEnumerable<string> ProfilesSelectionne { get; set; } = new HashSet<string>() { };

    public bool IsImplement()
    {
        if (NomRecherche is not null || Disponibilite is not null || Anciennete is not null || ProfilesSelectionne.Count()>0)
        {
            return true;
        }else 
        {
            return false;
        }
    }

    public void ResetResearchParam()
    {
        NomRecherche = null;
        Disponibilite = null;
        Anciennete = null;
    }

    /// <summary>
    /// Une méthode qui analyse le contenu des filtres et de la barre de recherche et génère une requete SQL correspondante.
    /// </summary>
    /// <returns>requete SQL (string)</returns>
    public string GenerateSQL(){
        string SQLRequest = "SELECT C.* FROM Consultant C JOIN PreferenceDomaine P ON C.idPrefDomain = P.idPrefDomain ";
        bool firstCondition = true;

        if(NomRecherche!=null || Disponibilite!=null || Anciennete!=null || ProfilesSelectionne.Count()!=0){
            

            if(NomRecherche!=""){
                SQLRequest+="WHERE unaccent(C.Nom) ILIKE unaccent('%" + NomRecherche + "%') ";
                firstCondition=false;
            }

            if(Disponibilite!=null){
                if(!firstCondition){
                    SQLRequest+="AND ";
                }
                else{
                    SQLRequest+="WHERE ";
                    firstCondition=false;
                }
                SQLRequest+= "C.disponibilite= '" + Disponibilite + "' ";
            }
            if(Anciennete!=null){
                if(!firstCondition){
                    SQLRequest+="AND ";
                }
                else{
                    SQLRequest+="WHERE ";
                    firstCondition=false;
                }
                SQLRequest+= "C.anciennete>=" + Anciennete + " ";
            }
            if(ProfilesSelectionne.Count()!=0){
                if(ProfilesSelectionne.Contains("Dev")){
                    if(!firstCondition){
                        SQLRequest+="AND ";
                    }
                    else{
                        SQLRequest+="WHERE ";
                        firstCondition=false;
                    }
                    SQLRequest+= "P.dev=true ";
                }
                if(ProfilesSelectionne.Contains("Fonctionnel")){
                    if(!firstCondition){
                        SQLRequest+="AND ";
                    }
                    else{
                        SQLRequest+="WHERE ";
                        firstCondition=false;
                    }
                    SQLRequest+= "P.fonctionnel=true ";
                }
                if(ProfilesSelectionne.Contains("Infrastructures")){
                    if(!firstCondition){
                        SQLRequest+="AND ";
                    }
                    else{
                        SQLRequest+="WHERE ";
                        firstCondition=false;
                    }
                    SQLRequest+= "P.infra=true ";
                }
            }
        }
        SQLRequest+=";";
        Console.WriteLine(SQLRequest);
        return SQLRequest;
    }
}