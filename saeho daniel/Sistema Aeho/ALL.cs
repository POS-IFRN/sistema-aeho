using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sistema_Aeho
{
    public class ALL
    {
        private Conexao c;
        string nome, cidade, genero, uf, modalidade, descricao, status_competicao, Organizador_usuario;

        public string Organizador_usuario1
        {
            get { return Organizador_usuario; }
            set { Organizador_usuario = value; }
        }

        public string Status_competicao
        {
            get { return status_competicao; }
            set { status_competicao = value; }
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public string Modalidade
        {
            get { return modalidade; }
            set { modalidade = value; }
        }
        

        public ALL()
        {
            c = new Conexao();
        }

        public ALL(string Nome, string Cidade, string Genero, string Uf, string Modalidade, string Descricao, string Status_competicao, string Organizador_usuario)
        {
            this.Nome = Nome;
            this.Cidade = Cidade;
            this.Genero = Genero;
            this.Uf = Uf;
            this.Modalidade = Modalidade;
            this.Descricao = Descricao;
            this.Status_competicao = Status_competicao;
            this.Organizador_usuario = Organizador_usuario1;
            c = new Conexao();
        }

        public string Uf
        {
            get { return uf; }
            set { uf = value; }
        }

        public string Genero
        {
            get { return genero; }
            set { genero = value; }
        }

        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }



        public List<ALL> buscar(string strbsc)
        {
            List<ALL> bscr = new List<ALL>();
            strbsc = "'%" + strbsc + "%'";

            
            string strAtleta = "select r.nome as 'Nome do Atleta', r.cidade as 'Cidade do Atleta', r.genero as 'Gênero do Atleta', r.uf as 'UF do Atleta' from Registro r where (r.nome like " + strbsc + ") OR (r.genero like " + strbsc+ ") OR (r.cidade like " + strbsc + ") OR (r.uf like " + strbsc+ ")";
           

            SqlCommand cmdAt = new SqlCommand(strAtleta, c.gConenection());
            SqlDataReader rdrAt = cmdAt.ExecuteReader();

            ALL fsql = null;
            while (rdrAt.Read())
            {
                fsql = new ALL();
                fsql.nome = rdrAt["Nome do Atleta"].ToString();
                fsql.genero = rdrAt["Gênero do Atleta"].ToString();
                fsql.cidade = rdrAt["Cidade do Atleta"].ToString();
                fsql.uf = rdrAt["UF do Atleta"].ToString();

                bscr.Add(fsql);
            }

            rdrAt.Close();


            string strCompeticao = "select c.nome as [Nome da Competição], c.modalidade as [Modalidade], c.genero as [Gênero], c.descricao as [Descrição], c.status_competicao as [Status da Competição], c.Organizador_usuario  as [Organizador] from Competicao c where (c.nome like " + strbsc + " ) OR (c.modalidade like " + strbsc + " ) OR (c.genero like " + strbsc + ") OR (c.descricao like " + strbsc + ") OR (status_competicao like " + strbsc + ") OR (c.Organizador_usuario like " + strbsc + ")";

            SqlCommand cmdComp = new SqlCommand(strCompeticao, c.gConenection());
            SqlDataReader rdrComp = cmdComp.ExecuteReader();

            ALL fsqlCo = null;
            while (rdrComp.Read())
            {
                fsqlCo = new ALL();
                fsqlCo.nome = rdrComp["Nome da Competição"].ToString();
                fsqlCo.modalidade = rdrComp["Modalidade"].ToString();
                fsqlCo.genero = rdrComp["Gênero"].ToString();
                fsqlCo.descricao = rdrComp["Descrição"].ToString();
                fsqlCo.status_competicao = rdrComp["Status da Competição"].ToString();
                fsqlCo.Organizador_usuario = rdrComp["Organizador"].ToString();
                bscr.Add(fsqlCo);
            }

            rdrComp.Close();

            return bscr;
        }

        
        

    }
}
