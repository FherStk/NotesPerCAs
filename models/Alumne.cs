public class Alumne{
    public string? Nom {get; private set;}
    public string? Cognoms {get; private set;}
    public string? Email {get; private set;}
    public List<MP> MPs {get; private set;}

    public Alumne(string Nom, string Cognoms, string Email){
        this.Nom = Nom;
        this.Cognoms = Cognoms;
        this.Email = Email;
        this.MPs = new List<MP>();
    }

    public String toString(){
        var info = $"{this.Cognoms}, {this.Nom} ({this.Email}):\n";
        foreach(var mp in MPs){  
            info += $"   {(mp.Nom ?? "").Replace(" (Real)", "")}:\n";

            foreach(var uf in mp.UFs){
                var nota = uf.Nota;
                if(nota != null) info += $"      {uf.Nom}:\n         Nota Real: {nota.Real}\n         Nota mitja: {nota.Mitja}\n";
                else info += $"      {uf.Nom}:\n         Encara no s'ha cursat.\n";
            }

            info += "\n";
        }
        

        return info;

    }
}