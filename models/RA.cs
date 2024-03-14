public class RA{
    public string? Nom {get; private set;}
    public List<CA> CAs {get; private set;}

    public Nota? Nota {
        get{
            var cas = this.CAs.Where(x => x.Nota != null);
            if(cas.Count() == 0) return null;
            else{
                #pragma warning disable CS8602 // Dereference of a possibly null reference.
                float mitja = cas.Sum(x => x.Nota.Mitja) / cas.Count();
                float real = cas.Where(x => x.Nota.Real < 4).Count() == 0 ? mitja : Math.Min(3.9f, mitja); 
                #pragma warning restore CS8602 // Dereference of a possibly null reference.
                return new Nota(mitja, real);
            }
        }
    }

    public RA(string Nom){
        this.Nom = Nom;
        this.CAs = new List<CA>();
    }
}