using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Aeho
{
    public class Competicao
    {
        private Conexao c;
        private string nome, modalidade, genero, descricao, organizador_usuario, rua, bairro, uf, cidade, cep, complemento, foto_da_competicao;

        public string Complemento
        {
            get { return complemento; }
            set { complemento = value; }
        }

        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        public string Uf
        {
            get { return uf; }
            set { uf = value; }
        }

        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        public string Rua
        {
            get { return rua; }
            set { rua = value; }
        }

        public string Organizador_usuario
        {
            get { return organizador_usuario; }
            set { organizador_usuario = value; }
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public string Genero
        {
            get { return genero; }
            set { genero = value; }
        }

        public string Modalidade
        {
            get { return modalidade; }
            set { modalidade = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Foto_da_competicao
        {
            get { return foto_da_competicao; }
            set { foto_da_competicao = value; }
        }
        private string inscricaoinicio, inscricaofim, competicaoinicio, competicaofim;

        public string Competicaofim
        {
            get { return competicaofim; }
            set { competicaofim = value; }
        }

        public string Competicaoinicio
        {
            get { return competicaoinicio; }
            set { competicaoinicio = value; }
        }
        private double valorInscricao;
        public string Inscricaofim
        {
            get { return inscricaofim; }
            set { inscricaofim = value; }
        }

        public string Inscricaoinicio
        {
            get { return inscricaoinicio; }
            set { inscricaoinicio = value; }
        }
        private TimeSpan horainicio;

        public TimeSpan Horainicio
        {
            get { return horainicio; }
            set { horainicio = value; }
        }
        private int status_competicao, numero, maximoinscritos, id;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public int Maximoinscritos
        {
            get { return maximoinscritos; }
            set { maximoinscritos = value; }
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public int Status_competicao
        {
            get { return status_competicao; }
            set { status_competicao = value; }
        }

        public double ValorInscricao
        {
            get { return valorInscricao; }
            set { valorInscricao = value; }
        }
        public Competicao(int Id, string Nome, string Modalidade, string Genero, string Descricao, string Organizador_usuario, string Foto_da_competicao, string Rua, string Bairro, string Uf, string Cidade, string Cep, string Complemento, int Maximoinscritos, int Numero, int Status_competicao, TimeSpan Horainicio, string Competicaoinicio, string Competicaofim, string Inscricaoinicio, string Inscricaofim, double ValorInscricao)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Modalidade = Modalidade;
            this.Genero = Genero;
            this.Descricao = Descricao;
            this.Organizador_usuario = Organizador_usuario;
            this.Foto_da_competicao = Foto_da_competicao;
            this.Rua = Rua;
            this.Bairro = Bairro;
            this.Uf = Uf;
            this.Cidade = Cidade;
            this.Cep = Cep;
            this.Complemento = Complemento;
            this.Maximoinscritos = Maximoinscritos;
            this.Numero = Numero;
            this.Status_competicao = Status_competicao;
            this.Horainicio = Horainicio;
            this.Competicaoinicio = Competicaoinicio;
            this.Competicaofim = Competicaofim;
            this.Inscricaoinicio = Inscricaoinicio;
            this.Inscricaofim = Inscricaofim;
            this.ValorInscricao = ValorInscricao;
            c = new Conexao();

        }
        public Competicao(string Nome, string Modalidade, string Genero, string Descricao, string Organizador_usuario, string Foto_da_competicao, string Rua, string Bairro, string Uf, string Cidade, string Cep, string Complemento, int Maximoinscritos, int Numero, int Status_competicao, TimeSpan Horainicio, string Competicaoinicio, string Competicaofim, string Inscricaoinicio, string Inscricaofim, double ValorInscricao)
        {
            this.Nome = Nome;
            this.Modalidade = Modalidade;
            this.Genero = Genero;
            this.Descricao = Descricao;
            this.Organizador_usuario = Organizador_usuario;
            this.Foto_da_competicao = Foto_da_competicao;
            this.Rua = Rua;
            this.Bairro = Bairro;
            this.Uf = Uf;
            this.Cidade = Cidade;
            this.Cep = Cep;
            this.Complemento = Complemento;
            this.Maximoinscritos = Maximoinscritos;
            this.Numero = Numero;
            this.Status_competicao = Status_competicao;
            this.Horainicio = Horainicio;
            this.Competicaoinicio = Competicaoinicio;
            this.Competicaofim = Competicaofim;
            this.Inscricaoinicio = Inscricaoinicio;
            this.Inscricaofim = Inscricaofim;
            this.ValorInscricao = ValorInscricao;
            c = new Conexao();

        }

        public Competicao(int Id)
        {
            this.Id = Id;
            // TODO: Complete member initialization
            c = new Conexao();
        }

        public Competicao()
        {
            // TODO: Complete member initialization
            c = new Conexao();
        }

        public int pegar_qtd_inscritos()
        {
            SqlCommand cmd2 = new SqlCommand("SELECT COUNT (*) FROM CompeticaoRegistro WHERE Competicao_id = @id ", c.gConenection());
            cmd2.Parameters.AddWithValue("@id", Id);
            int qtd = (int)cmd2.ExecuteScalar();
            //c.gConenection().Close();
            return qtd;
        }

        public List<Competicao> Selecionar_competicoes_com_status(int status)
        {
            List<Competicao> lista = new List<Competicao>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Competicao WHERE status_competicao = @s_id", c.gConenection());
            cmd.Parameters.AddWithValue("@s_id", status);
            //c.gConenection().Open();
            SqlDataReader datar = cmd.ExecuteReader();
            while (datar.Read())
            {
                Competicao comp = new Competicao(int.Parse(datar["id"].ToString()), datar["nome"].ToString(), datar["modalidade"].ToString(), datar["genero"].ToString(), datar["descricao"].ToString(), datar["organizador_usuario"].ToString(), datar["foto_da_competicao"].ToString(), datar["rua"].ToString(), datar["bairro"].ToString(), datar["uf"].ToString(), datar["cidade"].ToString(), datar["cep"].ToString(), datar["complemento"].ToString(), int.Parse(datar["numeromaximoinscritos"].ToString()), int.Parse(datar["numero"].ToString()), int.Parse(datar["status_competicao"].ToString()), TimeSpan.Parse(datar["horario"].ToString()), datar["dataEvento"].ToString(), datar["dataFimEvento"].ToString(), datar["inicioInscricao"].ToString(), datar["encerramentoInscricao"].ToString(), double.Parse(datar["valorInscricao"].ToString()));
                lista.Add(comp);
            }
            c.gConenection().Close();
            return lista;
        }

        public List<Competicao> Selecionar_competicoes_com_status(int status, bool abertas)
        {
            List<Competicao> lista = new List<Competicao>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Competicao WHERE status_competicao = 1 AND GETDATE() BETWEEN inicioInscricao AND encerramentoInscricao", c.gConenection());
            cmd.Parameters.AddWithValue("@s_id", status);
            //c.gConenection().Open();
            SqlDataReader datar = cmd.ExecuteReader();
            while (datar.Read())
            {
                Competicao comp = new Competicao(int.Parse(datar["id"].ToString()), datar["nome"].ToString(), datar["modalidade"].ToString(), datar["genero"].ToString(), datar["descricao"].ToString(), datar["organizador_usuario"].ToString(), datar["foto_da_competicao"].ToString(), datar["rua"].ToString(), datar["bairro"].ToString(), datar["uf"].ToString(), datar["cidade"].ToString(), datar["cep"].ToString(), datar["complemento"].ToString(), int.Parse(datar["numeromaximoinscritos"].ToString()), int.Parse(datar["numero"].ToString()), int.Parse(datar["status_competicao"].ToString()), TimeSpan.Parse(datar["horario"].ToString()), datar["dataEvento"].ToString(), datar["dataFimEvento"].ToString(), datar["inicioInscricao"].ToString(), datar["encerramentoInscricao"].ToString(), double.Parse(datar["valorInscricao"].ToString()));
                lista.Add(comp);
            }
            c.gConenection().Close();
            return lista;
        }

        public void preencher_competicao()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Competicao WHERE id = @id", c.gConenection());
            cmd.Parameters.AddWithValue("@id", Id);
            SqlDataReader datar = cmd.ExecuteReader();
            while (datar.Read())
            {
                Nome = datar["nome"].ToString();
                Modalidade = datar["modalidade"].ToString();
                Genero = datar["genero"].ToString();
                Descricao = datar["descricao"].ToString();
                Organizador_usuario = datar["organizador_usuario"].ToString();
                Foto_da_competicao = datar["foto_da_competicao"].ToString();
                Rua = datar["rua"].ToString();
                Bairro = datar["bairro"].ToString();
                Uf = datar["uf"].ToString();
                Cidade = datar["cidade"].ToString();
                Cep = datar["cep"].ToString();
                Complemento = datar["complemento"].ToString();
                Maximoinscritos = int.Parse(datar["numeromaximoinscritos"].ToString());
                Numero = int.Parse(datar["numero"].ToString());
                Status_competicao = int.Parse(datar["status_competicao"].ToString());
                Horainicio = TimeSpan.Parse(datar["horario"].ToString());
                Competicaoinicio = datar["dataEvento"].ToString();
                Competicaofim = datar["dataFimEvento"].ToString();
                Inscricaoinicio = datar["inicioInscricao"].ToString();
                Inscricaofim = datar["encerramentoInscricao"].ToString();
                ValorInscricao = double.Parse(datar["valorInscricao"].ToString());
            }
        }
        public List<Competicao> Selecionar_suas_competicoes(string org)
        {
            List<Competicao> lista = new List<Competicao>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Competicao WHERE Organizador_usuario = @s_id", c.gConenection());
            cmd.Parameters.AddWithValue("@s_id", org);
            //c.gConenection().Open();
            SqlDataReader datar = cmd.ExecuteReader();
            while (datar.Read())
            {
                Competicao comp = new Competicao(int.Parse(datar["id"].ToString()), datar["nome"].ToString(), datar["modalidade"].ToString(), datar["genero"].ToString(), datar["descricao"].ToString(), datar["organizador_usuario"].ToString(), datar["foto_da_competicao"].ToString(), datar["rua"].ToString(), datar["bairro"].ToString(), datar["uf"].ToString(), datar["cidade"].ToString(), datar["cep"].ToString(), datar["complemento"].ToString(), int.Parse(datar["numeromaximoinscritos"].ToString()), int.Parse(datar["numero"].ToString()), int.Parse(datar["status_competicao"].ToString()), TimeSpan.Parse(datar["horario"].ToString()), datar["dataEvento"].ToString(), datar["dataFimEvento"].ToString(), datar["inicioInscricao"].ToString(), datar["encerramentoInscricao"].ToString(), double.Parse(datar["valorInscricao"].ToString()));
                lista.Add(comp);
            }
            c.gConenection().Close();
            return lista;
        }
        public List<Competicao> Selecionar_suas_competicoes_encerradas(string org)
        {
            List<Competicao> lista = new List<Competicao>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Competicao WHERE Organizador_usuario = @s_id AND status_competicao = 2", c.gConenection());
            cmd.Parameters.AddWithValue("@s_id", org);
            //c.gConenection().Open();
            SqlDataReader datar = cmd.ExecuteReader();
            while (datar.Read())
            {
                Competicao comp = new Competicao(int.Parse(datar["id"].ToString()), datar["nome"].ToString(), datar["modalidade"].ToString(), datar["genero"].ToString(), datar["descricao"].ToString(), datar["organizador_usuario"].ToString(), datar["foto_da_competicao"].ToString(), datar["rua"].ToString(), datar["bairro"].ToString(), datar["uf"].ToString(), datar["cidade"].ToString(), datar["cep"].ToString(), datar["complemento"].ToString(), int.Parse(datar["numeromaximoinscritos"].ToString()), int.Parse(datar["numero"].ToString()), int.Parse(datar["status_competicao"].ToString()), TimeSpan.Parse(datar["horario"].ToString()), datar["dataEvento"].ToString(), datar["dataFimEvento"].ToString(), datar["inicioInscricao"].ToString(), datar["encerramentoInscricao"].ToString(), double.Parse(datar["valorInscricao"].ToString()));
                lista.Add(comp);
            }
            c.gConenection().Close();
            return lista;
        }

        public List<Competicao> Selecionar_suas_competicoesAtle(string atle)
        {
            List<Competicao> lista2 = new List<Competicao>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM CompeticaoRegistro WHERE Registro_usuario = @us_id", c.gConenection());
            cmd.Parameters.AddWithValue("@us_id", atle);
            SqlDataReader datar = cmd.ExecuteReader();
            while (datar.Read())
            {
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM Competicao WHERE id = @id", c.gConenection());
                cmd2.Parameters.AddWithValue("@id", int.Parse(datar["Competicao_id"].ToString()));
                SqlDataReader datar2 = cmd2.ExecuteReader();
                while (datar2.Read())
                {
                    Competicao comp = new Competicao(int.Parse(datar2["id"].ToString()), datar2["nome"].ToString(), datar2["modalidade"].ToString(), datar2["genero"].ToString(), datar2["descricao"].ToString(), datar2["organizador_usuario"].ToString(), datar2["foto_da_competicao"].ToString(), datar2["rua"].ToString(), datar2["bairro"].ToString(), datar2["uf"].ToString(), datar2["cidade"].ToString(), datar2["cep"].ToString(), datar2["complemento"].ToString(), int.Parse(datar2["numeromaximoinscritos"].ToString()), int.Parse(datar2["numero"].ToString()), int.Parse(datar2["status_competicao"].ToString()), TimeSpan.Parse(datar2["horario"].ToString()), datar2["dataEvento"].ToString(), datar2["dataFimEvento"].ToString(), datar2["inicioInscricao"].ToString(), datar2["encerramentoInscricao"].ToString(), double.Parse(datar2["valorInscricao"].ToString()));
                    lista2.Add(comp);
                }
            }
            c.gConenection().Close();
            return lista2;
        }

        public Competicao CompeticaoIndi(int idCompeticao)
        {
            List<Competicao> lista = new List<Competicao>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Competicao WHERE id = @s_id", c.gConenection());
            cmd.Parameters.AddWithValue("@s_id", idCompeticao);
            //c.gConenection().Open();
            SqlDataReader datar = cmd.ExecuteReader();
            Competicao comp = new Competicao();
            while (datar.Read())
            {
                comp = new Competicao(int.Parse(datar["id"].ToString()), datar["nome"].ToString(), datar["modalidade"].ToString(), datar["genero"].ToString(), datar["descricao"].ToString(), datar["organizador_usuario"].ToString(), datar["foto_da_competicao"].ToString(), datar["rua"].ToString(), datar["bairro"].ToString(), datar["uf"].ToString(), datar["cidade"].ToString(), datar["cep"].ToString(), datar["complemento"].ToString(), int.Parse(datar["numeromaximoinscritos"].ToString()), int.Parse(datar["numero"].ToString()), int.Parse(datar["status_competicao"].ToString()), TimeSpan.Parse(datar["horario"].ToString()), datar["dataEvento"].ToString(), datar["dataFimEvento"].ToString(), datar["inicioInscricao"].ToString(), datar["encerramentoInscricao"].ToString(), double.Parse(datar["valorInscricao"].ToString()));
            }
            c.gConenection().Close();
            return comp;
        }
        public void Inserir_competicao()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Competicao (nome, inicioInscricao, encerramentoInscricao, dataEvento, dataFimEvento, modalidade, horario, genero, rua, numero, bairro, cep, complemento, cidade, uf, ValorInscricao, descricao, numeromaximoInscritos, status_competicao, Organizador_usuario, foto_da_competicao) VALUES (@inf1, @inf2, @inf3, @inf4, @inf5, @inf6, @inf7, @inf8, @inf9, @inf10, @inf11, @inf12, @inf13, @inf14, @inf15, @inf16, @inf17, @inf18, @inf19, @inf20, @infofoto)", c.gConenection());
            cmd.Parameters.AddWithValue("@inf1", Nome);
            cmd.Parameters.AddWithValue("@inf2", Inscricaoinicio);
            cmd.Parameters.AddWithValue("@inf3", Inscricaofim);
            cmd.Parameters.AddWithValue("@inf4", Competicaoinicio);
            cmd.Parameters.AddWithValue("@inf5", Competicaofim);
            cmd.Parameters.AddWithValue("@inf6", Modalidade);
            cmd.Parameters.AddWithValue("@inf7", Horainicio);
            cmd.Parameters.AddWithValue("@inf8", Genero);
            cmd.Parameters.AddWithValue("@inf9", Rua);
            cmd.Parameters.AddWithValue("@inf10", Numero);
            cmd.Parameters.AddWithValue("@inf11", Bairro);
            cmd.Parameters.AddWithValue("@inf12", Cep);
            cmd.Parameters.AddWithValue("@inf13", Complemento);
            cmd.Parameters.AddWithValue("@inf14", Cidade);
            cmd.Parameters.AddWithValue("@inf15", Uf);
            cmd.Parameters.AddWithValue("@inf16", ValorInscricao);
            cmd.Parameters.AddWithValue("@inf17", Descricao);
            cmd.Parameters.AddWithValue("@inf18", Maximoinscritos);
            cmd.Parameters.AddWithValue("@inf19", Status_competicao);
            cmd.Parameters.AddWithValue("@inf20", Organizador_usuario);
            cmd.Parameters.AddWithValue("@infofoto", Foto_da_competicao);
            cmd.ExecuteNonQuery();
        }

        public void Update_competicao()
        {
            SqlCommand cmd = new SqlCommand("UPDATE [Competicao] SET nome = @inf1, inicioInscricao = @inf2, encerramentoInscricao = @inf3, dataEvento = @inf4, dataFimEvento = @inf5, modalidade = @inf6, horario = @inf7, genero = @inf8, rua = @inf9, numero = @inf10, bairro = @inf11, cep = @inf12, complemento = @inf13, cidade = @inf14, uf = @inf15, valorInscricao = @inf16, descricao = @inf17, numeromaximoInscritos = @inf18, status_competicao = @inf19, organizador_Usuario = @inf20, foto_da_competicao = @infofoto WHERE id=@id", c.gConenection());
            cmd.Parameters.AddWithValue("@id", Id);
            cmd.Parameters.AddWithValue("@inf1", Nome);
            cmd.Parameters.AddWithValue("@inf2", Inscricaoinicio);
            cmd.Parameters.AddWithValue("@inf3", Inscricaofim);
            cmd.Parameters.AddWithValue("@inf4", Competicaoinicio);
            cmd.Parameters.AddWithValue("@inf5", Competicaofim);
            cmd.Parameters.AddWithValue("@inf6", Modalidade);
            cmd.Parameters.AddWithValue("@inf7", Horainicio);
            cmd.Parameters.AddWithValue("@inf8", Genero);
            cmd.Parameters.AddWithValue("@inf9", Rua);
            cmd.Parameters.AddWithValue("@inf10", Numero);
            cmd.Parameters.AddWithValue("@inf11", Bairro);
            cmd.Parameters.AddWithValue("@inf12", Cep);
            cmd.Parameters.AddWithValue("@inf13", Complemento);
            cmd.Parameters.AddWithValue("@inf14", Cidade);
            cmd.Parameters.AddWithValue("@inf15", Uf);
            cmd.Parameters.AddWithValue("@inf16", ValorInscricao);
            cmd.Parameters.AddWithValue("@inf17", Descricao);
            cmd.Parameters.AddWithValue("@inf18", Maximoinscritos);
            cmd.Parameters.AddWithValue("@inf19", Status_competicao);
            cmd.Parameters.AddWithValue("@inf20", Organizador_usuario);
            cmd.Parameters.AddWithValue("@infofoto", Foto_da_competicao);
            cmd.ExecuteNonQuery();

        }

        public void Delete_Competicao(int Id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Competicao WHERE id=@id", c.gConenection());
            cmd.Parameters.AddWithValue("@id", Id);
            cmd.ExecuteNonQuery();
        }

        public void InscreverSeEm_Competicao(Registro r)
        {

            SqlCommand cmd = new SqlCommand("INSERT INTO CompeticaoRegistro (Competicao_id, Registro_usuario, tipo_medalha) VALUES (@inf1, @inf2, @inf3)", c.gConenection());
            cmd.Parameters.AddWithValue("@inf1", id);
            cmd.Parameters.AddWithValue("@inf2", r.Usuario);
            cmd.Parameters.AddWithValue("@inf3", 0);
            cmd.ExecuteNonQuery();

        }

        public Competicao selecionar_competicao(int id, string organizador)
        {
            Competicao compete = new Competicao();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Competicao WHERE id=@id", c.gConenection());
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader datar = cmd.ExecuteReader();
            while (datar.Read())
            {
                compete = new Competicao(int.Parse(datar["id"].ToString()), datar["nome"].ToString(), datar["modalidade"].ToString(), datar["genero"].ToString(), datar["descricao"].ToString(), datar["organizador_usuario"].ToString(), datar["foto_da_competicao"].ToString(), datar["rua"].ToString(), datar["bairro"].ToString(), datar["uf"].ToString(), datar["cidade"].ToString(), datar["cep"].ToString(), datar["complemento"].ToString(), int.Parse(datar["numeromaximoinscritos"].ToString()), int.Parse(datar["numero"].ToString()), int.Parse(datar["status_competicao"].ToString()), TimeSpan.Parse(datar["horario"].ToString()), datar["dataEvento"].ToString(), datar["dataFimEvento"].ToString(), datar["inicioInscricao"].ToString(), datar["encerramentoInscricao"].ToString(), double.Parse(datar["valorInscricao"].ToString()));
            }
            return compete;
        }

        public void validar_competicao()
        {

            SqlCommand cmd = new SqlCommand("UPDATE Competicao SET status_competicao = 1 WHERE id = @id", c.gConenection());
            cmd.Parameters.AddWithValue("@id", Id);
            cmd.ExecuteNonQuery();
        }

        public List<Competicao> selecionartodas()
        {
            List<Competicao> lista = new List<Competicao>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Competicao WHERE status_competicao != 0", c.gConenection());
            SqlDataReader datar = cmd.ExecuteReader();
            while (datar.Read())
            {
                Competicao comp = new Competicao(int.Parse(datar["id"].ToString()), datar["nome"].ToString(), datar["modalidade"].ToString(), datar["genero"].ToString(), datar["descricao"].ToString(), datar["organizador_usuario"].ToString(), datar["foto_da_competicao"].ToString(), datar["rua"].ToString(), datar["bairro"].ToString(), datar["uf"].ToString(), datar["cidade"].ToString(), datar["cep"].ToString(), datar["complemento"].ToString(), int.Parse(datar["numeromaximoinscritos"].ToString()), int.Parse(datar["numero"].ToString()), int.Parse(datar["status_competicao"].ToString()), TimeSpan.Parse(datar["horario"].ToString()), datar["dataEvento"].ToString(), datar["dataFimEvento"].ToString(), datar["inicioInscricao"].ToString(), datar["encerramentoInscricao"].ToString(), double.Parse(datar["valorInscricao"].ToString()));
                lista.Add(comp);
            }
            c.gConenection().Close();
            return lista;
        }




         public List<Competicao> buscar(string strbsc)
        {
            List<Competicao> bscr = new List<Competicao>();
            

            string strCompeticao = "SELECT * FROM Competicao WHERE nome LIKE '%' + @busca + '%' AND status_competicao != 0 AND status_competicao != 2";

            SqlCommand cmdComp = new SqlCommand(strCompeticao, c.gConenection());
            cmdComp.Parameters.AddWithValue("@busca", strbsc);
             SqlDataReader datar = cmdComp.ExecuteReader();

            while (datar.Read())
            {
               Competicao comp = new Competicao(int.Parse(datar["id"].ToString()), datar["nome"].ToString(), datar["modalidade"].ToString(), datar["genero"].ToString(), datar["descricao"].ToString(), datar["organizador_usuario"].ToString(), datar["foto_da_competicao"].ToString(), datar["rua"].ToString(), datar["bairro"].ToString(), datar["uf"].ToString(), datar["cidade"].ToString(), datar["cep"].ToString(), datar["complemento"].ToString(), int.Parse(datar["numeromaximoinscritos"].ToString()), int.Parse(datar["numero"].ToString()), int.Parse(datar["status_competicao"].ToString()), TimeSpan.Parse(datar["horario"].ToString()), datar["dataEvento"].ToString(), datar["dataFimEvento"].ToString(), datar["inicioInscricao"].ToString(), datar["encerramentoInscricao"].ToString(), double.Parse(datar["valorInscricao"].ToString()));
                bscr.Add(comp);
            }
            datar.Close();

            return bscr;
        }


    }
}

