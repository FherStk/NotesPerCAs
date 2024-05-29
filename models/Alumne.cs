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
            var nota = mp.Nota(mp.Nom == "MP03" ? new float[]{85, 50, 30} : new float[]{20, 20, 26});  //posar hores
            info += $"   {clean(mp.Nom)}:\n";

            if(nota != null){
                info += $"      Nota butlletí (redondeig): {Math.Round(nota.Real)}\n      Nota real (amb decimals): {nota.Real}\n      Nota mitjana (sense tenir en compte les penalitzacions): {nota.Mitja}\n";
                info += $"\n";
            }

            foreach(var uf in mp.UFs){
                nota = uf.Nota;
                if(nota != null) info += $"      {clean(uf.Nom)}:\n         Nota butlletí (redondeig): {Math.Round(nota.Real)}\n         Nota real (amb decimals): {nota.Real}\n         Nota mitjana (sense tenir en compte les penalitzacions): {nota.Mitja}\n";
                else info += $"      {clean(uf.Nom)}:\n         Encara no s'ha cursat.\n";

                if(nota != null && (nota.Mitja != nota.Real || nota.Mitja < 5)){
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