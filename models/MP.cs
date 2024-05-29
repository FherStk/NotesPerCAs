public class MP{
    public string? Nom {get; private set;}
    public List<UF> UFs {get; private set;}
    
    public MP(string Nom){
        this.Nom = Nom;
        this.UFs = new List<UF>();
    }    

    public Nota? Nota (float[] hores){
        #pragma warning disable CS8602 // Dereference of a possibly null reference.
        var notes = this.UFs.OrderBy(x => x.Nom).Where(x => x.Nota != null).Select(x => x.Nota.Real).ToList();
        #pragma warning restore CS8602 // Dereference of a possibly null reference.

        if(notes.Count != hores.Count()) return null;   //Not finalized course.
        var suspes = notes.Where(x => x < 5).Count() > 0;
        

        var total = hores.Sum(x => x);
        var nota = 0f;

        for(int i = 0; i < hores.Length; i++){
            var p = hores[i] / total;
            nota += notes[i] * p;                        
        }

        return new Nota(nota, suspes ? 4 : nota);
    }
}