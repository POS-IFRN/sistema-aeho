using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_Aeho;

namespace Hora
{
    class Program
    {
        static void Main(string[] args)
        {
            Conexao c = new Conexao();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Competicao WHERE status_competicao = 1 ", c.gConenection());
            SqlDataReader datar = cmd.ExecuteReader();
            while (datar.Read())
            {
                if (Convert.ToDateTime(datar["dataFimEvento"].ToString()) < DateTime.Now)
                {
                    SqlCommand cdr = new SqlCommand("UPDATE INTO [Competicao] SET status_competicao = 2 WHERE id = @sid", c.gConenection());
                    cdr.Parameters.AddWithValue("@sid", datar["id"].ToString());
                }
            }
            c.gConenection().Close();
        }
    }
}
