using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sistema_Aeho
{
    public class Premiacao
    {
        //1 = BRONZE, 2 = PRATA, 3 = OURO
        private Registro atleta, organizador;
        private Conexao c;
        public Registro Organizador
        {
            get { return organizador; }
            set { organizador = value; }

        }
        public Registro Atleta
        {
            get { return atleta; }
            set { atleta = value; }
        }
        private Competicao competicao;

        public Competicao Competicao
        {
            get { return competicao; }
            set { competicao = value; }
        }
        private int tipo_medalha;

        public int Tipo_medalha
        {
            get { return tipo_medalha; }
            set { tipo_medalha = value; }
        }

        public Premiacao()
        {
            c = new Conexao();
        }
        public Premiacao(Registro Atleta, Competicao Competicao)
        {
            c = new Conexao();
            this.Atleta = Atleta;
            this.Competicao = Competicao;
        }

        public Premiacao(Registro Atleta, Competicao Competicao, int Tipo_medalha)
        {
            c = new Conexao();
            this.Competicao = Competicao;
            this.Competicao.preencher_competicao();
            Registro aux = new Registro(Competicao.Organizador_usuario);
            this.Atleta = Atleta;
            this.Tipo_medalha = Tipo_medalha;
            this.Organizador = aux.selecionar_usuario();
            

        }

        public void Cancelar_inscricao_Competicao()
        {

            SqlCommand cmd = new SqlCommand("DELETE FROM CompeticaoRegistro WHERE registro_usuario=@registro_usuario AND competicao_id = @competicao_id", c.gConenection());
            cmd.Parameters.AddWithValue("@competicao_id", Competicao.Id);
            cmd.Parameters.AddWithValue("@registro_usuario", Atleta.Usuario);
            cmd.ExecuteNonQuery();

        }
        public void inserir_premiacao()
        {
            SqlCommand cmd = new SqlCommand("UPDATE [CompeticaoRegistro] SET tipo_medalha = @inf3 WHERE Registro_usuario = @inf1 AND Competicao_id = @inf2", c.gConenection());
            cmd.Parameters.AddWithValue("@inf1", Atleta.Usuario);
            cmd.Parameters.AddWithValue("@inf2", Competicao.Id);
            cmd.Parameters.AddWithValue("@inf3", Tipo_medalha);
            cmd.ExecuteNonQuery();
            SqlCommand k = new SqlCommand("UPDATE [Competicao] SET status_competicao = 3 WHERE id = @id", c.gConenection());
            k.Parameters.AddWithValue("@id", Competicao.Id);
            k.ExecuteNonQuery();
        }



        public List<Premiacao> totalMedalhas(string login)
        {
            List<Premiacao> l = new List<Premiacao>();
            SqlCommand cmd = new SqlCommand("SELECT Competicao_id, tipo_medalha FROM [CompeticaoRegistro] WHERE Registro_usuario = @login AND tipo_medalha != 0", c.gConenection());
            cmd.Parameters.AddWithValue("@login", login);
            SqlDataReader datar = cmd.ExecuteReader();
            while(datar.Read())
            {
                Premiacao cu = new Premiacao(new Registro(login), new Competicao(int.Parse(datar["Competicao_id"].ToString())), int.Parse(datar["tipo_medalha"].ToString()));
                cu.Competicao.preencher_competicao();
                l.Add(cu);
            }
            return l;
        }
        public List<Premiacao> selecionar_vencedores()
        {
            List<Premiacao> l = new List<Premiacao>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [CompeticaoRegistro] WHERE Competicao_id = @c_id AND tipo_medalha != 0", c.gConenection());
            cmd.Parameters.AddWithValue("@c_id", Competicao.Id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Premiacao p = new Premiacao(new Registro(dr["Registro_usuario"].ToString()), new Competicao(int.Parse(dr["Competicao_id"].ToString())), int.Parse(dr["tipo_medalha"].ToString()));
                p.Atleta = p.Atleta.selecionar_usuario();
                l.Add(p);
            }
            dr.Close();
            return l;
        
        }
        public bool esta_inscrito()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM CompeticaoRegistro WHERE Competicao_id = @c_id AND Registro_Usuario = @a_id", c.gConenection());
            cmd.Parameters.AddWithValue("@c_id", Competicao.Id);
            cmd.Parameters.AddWithValue("@a_id", Atleta.Usuario);
            int qtd = (int)cmd.ExecuteScalar();
            if (qtd > 0)
                return true;
            return false;
        }
    }
}
