namespace GetMygeek.Models;
public class ResearchQuery
{
    public string Input { get; set; } = null;
    public string Available { get; set; } = null;
    public int? Anciennete { get; set; } = null;
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

    public string GenerateSQL(){
        string SQLRequest = "SELECT C.* FROM Consultant C JOIN PreferenceDomaine P ON C.idPrefDomain = P.idPrefDomain ";
        bool firstCondition = true;

        if(Input!=null || Available!=null || Anciennete!=null || ProfilesSelected.Count()!=0){
            SQLRequest+="WHERE ";

            if(Input!=null){
                SQLRequest+="C.Nom='" + Input + "' ";
                firstCondition=false;
            }

            if(Available!=null){
                if(!firstCondition){
                    SQLRequest+="AND ";
                }
                else{
                    firstCondition=false;
                }
                SQLRequest+= "C.disponibilite= '" + Available + "' ";
            }
            if(Anciennete!=null){
                if(!firstCondition){
                    SQLRequest+="AND ";
                }
                else{
                    firstCondition=false;
                }
                SQLRequest+= "C.anciennete=" + Anciennete + " ";
            }
            if(ProfilesSelected.Count()!=0){
                if(ProfilesSelected.Contains("Dev")){
                    if(!firstCondition){
                        SQLRequest+="AND ";
                    }
                    else{
                        firstCondition=false;
                    }
                    SQLRequest+= "P.dev=true ";
                }
                if(ProfilesSelected.Contains("Fonctionnel")){
                    if(!firstCondition){
                        SQLRequest+="AND ";
                    }
                    else{
                        firstCondition=false;
                    }
                    SQLRequest+= "P.fonctionnel=true ";
                }
                if(ProfilesSelected.Contains("Infrastructures")){
                    if(!firstCondition){
                        SQLRequest+="AND ";
                    }
                    else{
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