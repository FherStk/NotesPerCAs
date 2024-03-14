public class UF{
    public string? Nom {get; private set;}
    public List<RA> RAs {get; private set;}

    public Nota? Nota {
        get{
            var ras = this.RAs.Where(x => x.Nota != null);
            if(ras.Count() == 0) return null;
            else{
                #pragma warning disable CS8602 // Dereference of a possibly null reference.
                float mitja = ras.Sum(x => x.Nota.Mitja) / ras.Count();
                float real = ras.Where(x => x.Nota.Real < 4).Count() == 0 ? mitja : Math.Min(3.9f, mitja); 
                #pragma warning restore CS8602 // Dereference of a possibly null reference.
                return new Nota(mitja, real);
            }
        }
    }

    public UF(string Nom){
        this.Nom = Nom;
        this.RAs = new List<RA>();
    }
}