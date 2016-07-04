using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_Aeho;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Console.WriteLine("eae menina");
           // Mensagem m = new Mensagem();
           // m.Registro_usuario = "daniel";
           // List<Mensagem> lista = m.Selecionar_suas_mensagens("Atleta");
            //foreach (Mensagem k in lista)
           //{
             //   Console.WriteLine("EAE {0}",k.Id);
               // Console.WriteLine("EAE{0}",k.Competicao_id);
               // Console.WriteLine("EAE{0}", k.Mensagem_conteudo);
               // Console.WriteLine();
           // }
            
            
            DateTime firstDate = new DateTime(2002, 10, 22);
            TimeSpan span = new TimeSpan(1, 2, 0, 30, 0);
            Console.WriteLine("Competicao");
            Competicao c = new Competicao();
            List<Competicao> listacompete = c.Selecionar_competicoes_com_status(1); 
            foreach(Competicao l in listacompete)
            {
                Console.WriteLine("Nome: {0}",l.Nome);
                Console.WriteLine("Numero Máximo Inscritos: {0}", l.Maximoinscritos);
            }
            Console.ReadKey();
            
        }
    }
}
