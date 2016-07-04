using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Aeho
{
    public class Conexao
    {
        private string conexao;
        private SqlConnection conn;
        public Conexao()
        {
            conexao = "Data Source=./;Initial Catalog=dbplataformaAEHO;User ID=sa;Password=senha;MultipleActiveResultSets=True";
        conn = new SqlConnection(conexao);
        conn.Open();
        }
        public SqlConnection gConenection()
        {
            return conn;
        }
    }
}
