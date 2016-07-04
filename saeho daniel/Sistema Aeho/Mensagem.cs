using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Aeho
{
    public class Mensagem
    {
        private Conexao c;
        private int id, lida;
        private int? competicao_id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Lida
        {
            get { return lida; }
            set { lida = value; }
        }

        public int? Competicao_id
        {
            get { return competicao_id; }
            set { competicao_id = value; }
        }
        private string registro_remetente, registro_receptor, mensagem_conteudo, data_envio;

        public string Data_envio
        {
            get { return data_envio; }
            set { data_envio = value; }
        }

        public string Mensagem_conteudo
        {
            get { return mensagem_conteudo; }
            set { mensagem_conteudo = value; }
        }

        public string Registro_remetente
        {
            get { return registro_remetente; }
            set { registro_remetente = value; }
        }

        public string Registro_receptor
        {
            get { return registro_receptor; }
            set { registro_receptor = value; }
        }
        public Mensagem(int Id, int Lida, string Mensagem_conteudo, string Registro_receptor, string Registro_remetente, string Data_envio)
        {
            c = new Conexao();
            this.Id = Id;
            this.Lida = Lida;
            this.Mensagem_conteudo = Mensagem_conteudo;
            this.Registro_receptor = Registro_receptor;
            this.Registro_remetente = Registro_remetente;
            this.Data_envio = Data_envio;
        }
        public Mensagem(int Id, int Lida, string Mensagem_conteudo, string Registro_receptor, string Registro_remetente, int Competicao_id, string Data_envio)
        {
            c = new Conexao();

            this.Id = Id;
            this.Lida = Lida;
            this.Mensagem_conteudo = Mensagem_conteudo;
            this.Registro_receptor = Registro_receptor;
            this.Registro_remetente = Registro_remetente;
            this.Competicao_id = Competicao_id;
            this.Data_envio = Data_envio;
        }
        public Mensagem(string Mensagem_conteudo, string Registro_receptor, int Competicao_id, string Registro_remetente)
        {
            c = new Conexao();
            this.Mensagem_conteudo = Mensagem_conteudo;
            this.Lida = 0;
            this.Registro_receptor = Registro_receptor;
            this.Competicao_id = Competicao_id;
            this.Registro_remetente = Registro_remetente;
            DateTime k = DateTime.Now;
            this.Data_envio = k.ToString("yyyyMMdd");

        }
        public Mensagem(string Mensagem_conteudo, string Registro_receptor, string Registro_remetente)
        {
            c = new Conexao();
            this.Mensagem_conteudo = Mensagem_conteudo;
            this.Lida = 0;
            this.Registro_receptor = Registro_receptor;
            this.Registro_remetente = Registro_remetente;
            DateTime k = DateTime.Now;
            this.Data_envio = k.ToString("yyyyMMdd");
        }
        public Mensagem()
        {
            c = new Conexao();
        }
        public Mensagem(int Id)
        {
            c = new Conexao();
            this.Id = Id;
        }
        public Mensagem(string Registro_receptor)
        {
            c = new Conexao();
            this.Registro_receptor = Registro_receptor;
        }
        public List<Mensagem> s_all()
        {
            List<Mensagem> Lista = new List<Mensagem>();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("SELECT * FROM Mensagem", c.gConenection());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Mensagem m;
                if (dr["competicao_id"] == DBNull.Value)
                {
                    Console.WriteLine("eae");
                    m = new Mensagem(int.Parse(dr["id"].ToString()), int.Parse(dr["lida"].ToString()), dr["mensagem"].ToString(), dr["registro_receptor"].ToString(), dr["registro_remetente"].ToString(), dr["data_envio"].ToString());
                }
                else
                {
                    m = new Mensagem(int.Parse(dr["id"].ToString()), int.Parse(dr["lida"].ToString()), dr["mensagem"].ToString(), dr["registro_receptor"].ToString(), dr["registro_remetente"].ToString(), int.Parse(dr["competicao_id"].ToString()), dr["data_envio"].ToString());
                }
                Lista.Add(m);
            }

            c.gConenection().Close();
            return Lista;

        }
        public List<Mensagem> Selecionar_suas_mensagens()
        {
            List<Mensagem> Lista = new List<Mensagem>();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("SELECT * FROM Mensagem WHERE registro_receptor = @r_u", c.gConenection());
            cmd.Parameters.AddWithValue("@r_u", Registro_receptor);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Mensagem m;
                if (dr["competicao_id"] == DBNull.Value)
                {
                    m = new Mensagem(int.Parse(dr["id"].ToString()), int.Parse(dr["lida"].ToString()), dr["mensagem"].ToString(), dr["registro_receptor"].ToString(), dr["registro_remetente"].ToString(), dr["data_envio"].ToString());
                }
                else
                {
                    m = new Mensagem(int.Parse(dr["id"].ToString()), int.Parse(dr["lida"].ToString()), dr["mensagem"].ToString(), dr["registro_receptor"].ToString(), dr["registro_remetente"].ToString(), int.Parse(dr["competicao_id"].ToString()), dr["data_envio"].ToString());
                }
                Lista.Add(m);
            }
            return Lista;
        }

        public Mensagem Selecionar_uma()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Mensagem WHERE id = @id", c.gConenection());
            cmd.Parameters.AddWithValue("@id", Id);
            SqlDataReader dr = cmd.ExecuteReader();
            Mensagem m = new Mensagem();
            while (dr.Read())
            {
                if (dr["competicao_id"] != DBNull.Value) m = new Mensagem(int.Parse(dr["id"].ToString()), int.Parse(dr["lida"].ToString()), dr["mensagem"].ToString(), dr["registro_receptor"].ToString(), dr["registro_remetente"].ToString(), int.Parse(dr["competicao_id"].ToString()), dr["data_envio"].ToString());
                m = new Mensagem(int.Parse(dr["id"].ToString()), int.Parse(dr["lida"].ToString()), dr["mensagem"].ToString(), dr["registro_receptor"].ToString(), dr["registro_remetente"].ToString(), dr["data_envio"].ToString());
            }
            dr.Close();
            return m;
        }
        public bool existe_mensagem_competicao(int c_id)
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Mensagem WHERE competicao_id = @id", c.gConenection());
            cmd.Parameters.AddWithValue("@id", c_id);
            int existe = (int)cmd.ExecuteScalar();
            if (existe > 0)
                return true;
            return false;
        }
        public List<Mensagem> selec_mensagem_comp(int c_id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Mensagem WHERE competicao_id = @id", c.gConenection());
            cmd.Parameters.AddWithValue("@id", c_id);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Mensagem> listm = new List<Mensagem>();
            while (dr.Read())
            {
                Mensagem m = new Mensagem(int.Parse(dr["id"].ToString()), int.Parse(dr["lida"].ToString()), dr["mensagem"].ToString(), dr["registro_receptor"].ToString(), dr["registro_remetente"].ToString(), int.Parse(dr["competicao_id"].ToString()), dr["data_envio"].ToString());
                listm.Add(m);
            }
            return listm;

        }
        public void Inserir_mensagem()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Mensagem VALUES(@inf1, @inf2, @inf4, @inf5, @inf6, @inf7)", c.gConenection());
            if (Competicao_id.HasValue) cmd.Parameters.AddWithValue("@inf1", Competicao_id);
            else cmd.Parameters.AddWithValue("@inf1", DBNull.Value);
            cmd.Parameters.AddWithValue("@inf2", Registro_remetente);
            cmd.Parameters.AddWithValue("@inf4", Mensagem_conteudo);
            cmd.Parameters.AddWithValue("@inf5", Lida);
            cmd.Parameters.AddWithValue("@inf6", Registro_receptor);
            cmd.Parameters.AddWithValue("@inf7", Data_envio);
            cmd.ExecuteNonQuery();
        }

    }
}
