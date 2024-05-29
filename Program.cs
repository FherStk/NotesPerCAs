var lines = File.ReadLines("input/notes.csv");
var headers = (lines.FirstOrDefault() ?? "").SplitCSV().ToArray();

var alumnes = new List<Alumne>();
foreach(var line in lines.Skip(1)){
    var fields = line.SplitCSV().ToArray();
    var alumne = new Alumne(fields[0], fields[1], fields[5]);
    
    var mps = new List<MP>();
    var ufs = new List<UF>();
    var ras = new List<RA>();
    var cas = new List<CA>();
    var items = new List<Item>();
    for(int i=6; i<headers.Length; i++){
        var item = headers[i];

        if(!item.Contains("Total de")) items.Add(new Item(item, (fields[i].ToString() == "-" ? null : float.Parse(fields[i].ToString()))));
        else
        {
            var title = item.Substring(9);
        
            if(item.Contains("Total de MP")){
                var mp = new MP(title);
                mp.UFs.AddRange(ufs);                
                mps.Add(mp);
                ufs.Clear();
            }
            else if(item.Contains("Total de UF")){
                var uf = new UF(title);
                uf.RAs.AddRange(ras);
                ufs.Add(uf);
                ras.Clear();
            }
            else if(item.Contains("Total de RA")){
                var ra = new RA(title);
                ra.CAs.AddRange(cas);
                ras.Add(ra);
                cas.Clear();
            }
            else if(item.Contains("Total de ") && !item.Contains("Total de CA")){   
                var ca = new CA(title); 
                ca.Items.AddRange(items);
                cas.Add(ca);
                items.Clear();
            }
        }
    }

    alumne.MPs.AddRange(mps);
    alumnes.Add(alumne);
    mps.Clear();
}

var dir = "output";
Directory.CreateDirectory(dir);
foreach(var alumne in alumnes){
    File.WriteAllText(Path.Combine(dir, $"{alumne.Cognoms}, {alumne.Nom}.txt"), alumne.toString());
    Console.WriteLine(alumne.toString());    
}
