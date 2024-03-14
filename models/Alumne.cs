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
            info += $"   {clean(mp.Nom)}:\n";

            foreach(var uf in mp.UFs){
                var nota = uf.Nota;
                if(nota != null) info += $"      {clean(uf.Nom)}:\n         Nota Real: {nota.Real}\n         Nota mitja: {nota.Mitja}\n";
                else info += $"      {clean(uf.Nom)}:\n         Encara no s'ha cursat.\n";

                if(nota != null && nota.Mitja != nota.Real){
                    //Cal recuperar quelcom

                    info += $"         Cal recuperar els següents CAs:\n";
                    foreach(var ra in uf.RAs){
                        foreach(var ca in ra.CAs){
                            if(ca.Nota != null && ca.Nota.Real < 4){
                                info += $"            {clean(ra.Nom)} CA {clean(ca.Nom)}\n";
                            }
                        }
                    }
                }
            }

            info += "\n";
        }
        

        return info;
    }

    private String clean(String? text){
        return (text ?? "").Replace(" (Real)", "");
    }
}