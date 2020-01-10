using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestIndikatore.Model;

namespace TestIndikatore.Controllers
{
    [ApiController]
    [Route("pastas")]
    public class PastaController : ApiControllerAttribute
    {

        public List<Folder> pastas = new List<Folder>();



        [HttpGet]

        public List<Folder> get()
        {
            
                pastas.Add(new Folder("Pasta 1/Filha da pasta 1/doc.docx (20kb)"));
                pastas.Add(new Folder("Pasta 1/Outra filha da pasta 1/doc.ppt (10kb)"));
                pastas.Add(new Folder("Pasta 2/Filha da pasta 2/Neta da pasta 2/script.sh (45kb)"));
                pastas.Add(new Folder("Pasta 2/Filha da pasta 2/Outra neta da pasta 2/Bisneta da pasta 2/picture.png (5kb)"));
                pastas.Add(new Folder("Pasta 2/Outra filha da pasta 2/picture.png (25kb)"));
                pastas.Add(new Folder("Pasta 3/Outra filha da pasta 3/picture.png (25kb)"));
                pastas.Add(new Folder("Pasta 3/Outra filha da pasta 3/picture2.png (25kb)"));
                pastas.Add(new Folder("Outra coisa/Outra filha da pasta 2/picture.png (25kb)"));
                pastas.Add(new Folder("Pode Receber/Qualquer rota/doFrontend.png (25kb)"));




            List<Folder> final = new List<Folder>();
                foreach (Folder listaPasta in pastas)
                {
                    String pastasList = listaPasta.name;
                    String[] caminho = pastasList.Split("/");

                    List<String> lst = caminho.OfType<String>().ToList();
                    String file = lst.First();
                    lst.RemoveAt(0);




                    String prevProp = lst.Last();
                    lst.RemoveAt(lst.Count - 1);


                    string[] parts1 = prevProp.Replace("kb)", "").Split('(');
                    int sizeFile = int.Parse(parts1[1]);


                    



                    //buscando se existe inicio
                    Folder prevLevel = final.Find(x => x.name == file);
                    if (prevLevel == null)
                    {
                        prevLevel = new Folder(file);
                        prevLevel.size = sizeFile;
                        final.Add(prevLevel);
                    }
                    else
                    {
                        prevLevel.size += sizeFile;
                    }
                    //buscando se existe fim



                    

                    foreach (String level in lst)
                    {
                        Folder prevLevelFilho = prevLevel.folders.Find(x => x.name == level);
                        if (prevLevelFilho == null)
                        {
                            prevLevelFilho = new Folder(level);
                            prevLevelFilho.size = sizeFile;
                            prevLevel.folders.Add(prevLevelFilho);
                        }
                        else
                        {
                            prevLevelFilho.size += sizeFile;
                        }
                        //trocando de Filho
                        prevLevel = prevLevelFilho;
                    }
                }


                return final;
            }

    }
}