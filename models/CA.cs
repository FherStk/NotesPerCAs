public class CA{
    public string? Nom {get; private set;}
    public List<Item> Items {get; private set;}

    public Nota? Nota {
        get{
            var items = this.Items.Where(x => x.Nota.HasValue);
            if(items.Count() == 0) return null;
            else{
                float mitja = items.Select(x => x.Nota ?? 0).Sum() / items.Count();
                float real = items.Where(x => x.Nota < 4).Count() == 0 ? mitja : Math.Min(3.9f, mitja); 
                return new Nota(mitja, real);
            }
        }
    }

    public CA(string Nom){
        this.Nom = Nom;
        this.Items = new List<Item>();
    }
}