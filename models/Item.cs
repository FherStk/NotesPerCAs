public class Item{
    public string? Nom {get; private set;}
    public float? Nota {get; private set;}

    public Item(string Nom, float? Nota){
        this.Nom = Nom;
        this.Nota = Nota;
    }
}