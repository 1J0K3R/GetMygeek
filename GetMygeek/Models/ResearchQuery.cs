namespace GetMygeek.Models;
public class ResearchQuery
{
    /// <summary>
    /// Le contenu du champs rechercher.
    /// </summary>
    public string Input { get; set; } = null;

    /// <summary>
    /// La disponibilite du consultant recherche. Peut prendre les valeurs null, disponible, enMission.
    /// </summary>
    public string Available { get; set; } = null;

    /// <summary>
    /// L'anciennete minimale du consultant recherche.
    /// </summary>
    public int? Anciennete { get; set; } = null;

    /// <summary>
    /// Une liste des types de missions recherchees par le consultant.
    /// </summary>
    public IEnumerable<string> ProfilesSelected { get; set; } = new HashSet<string>() { };

    public bool IsImplement()
    {
        if (Input is not null || Available is not null || Anciennete is not null || ProfilesSelected.Count()>0)
        {
            return true;
        }else 
        {
            return false;
        }
    }

    /// <summary>
    /// Une méthode qui analyse le contenu des filtres et de la barre de recherche et génère une requete SQL correspondante.
    /// </summary>
    /// <returns>requete SQL (string)</returns>
    public string GenerateSQL(){
        string SQLRequest = "SELECT C.* FROM Consultant C JOIN PreferenceDomaine P ON C.idPrefDomain = P.idPrefDomain ";
        bool firstCondition = true;

        if(Input!=null || Available!=null || Anciennete!=null || ProfilesSelected.Count()!=0){
            

            if(Input!=""){
                SQLRequest+="WHERE C.Nom LIKE '%" + Input + "%' ";
                firstCondition=false;
            }

            if(Available!=null){
                if(!firstCondition){
                    SQLRequest+="AND ";
                }
                else{
                    SQLRequest+="WHERE ";
                    firstCondition=false;
                }
                SQLRequest+= "C.disponibilite= '" + Available + "' ";
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
            if(ProfilesSelected.Count()!=0){
                if(ProfilesSelected.Contains("Dev")){
                    if(!firstCondition){
                        SQLRequest+="AND ";
                    }
                    else{
                        SQLRequest+="WHERE ";
                        firstCondition=false;
                    }
                    SQLRequest+= "P.dev=true ";
                }
                if(ProfilesSelected.Contains("Fonctionnel")){
                    if(!firstCondition){
                        SQLRequest+="AND ";
                    }
                    else{
                        SQLRequest+="WHERE ";
                        firstCondition=false;
                    }
                    SQLRequest+= "P.fonctionnel=true ";
                }
                if(ProfilesSelected.Contains("Infrastructures")){
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