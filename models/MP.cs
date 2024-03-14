public class MP{
    public string? Nom {get; private set;}
    public List<UF> UFs {get; private set;}
    
    public MP(string Nom){
        this.Nom = Nom;
        this.UFs = new List<UF>();
    }    

    public Nota? Nota (float[] hores){
        //Cal tenir en compte les hores de cada UF dins l'MP. 
        throw new NotImplementedException();

        // var ufs = this.UFs.Where(x => x.Nota != null);
        // if(ufs.Count() == 0) return null;
        // else{
        //     #pragma warning disable CS8602 // Dereference of a possibly null reference.
        //     float mitja = ufs.Sum(x => x.Nota.Mitja) / ufs.Count();
        //     float real = ufs.Where(x => x.Nota.Real < 4).Count() == 0 ? mitja : Math.Min(3.9f, mitja); 
        //     #pragma warning restore CS8602 // Dereference of a possibly null reference.
        //     return new Nota(mitja, real);
        // }
    }
}