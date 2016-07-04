using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Aeho
{
    public class Registro
    {
        private string nome, rg, cpf, genero, email, usuario, senha, foto_de_perfil, rua, bairro, uf, cidade, complemento, cep;
	    private int numero, privilegio;
	    private string nascimento;
        private Conexao c;
	    public string Nome
	    {
		    get { return nome;}
           	    set { nome = value; }
	    }
	
	    public string Rg
	    {
		    get { return rg;}
           	    set { rg = value; }
	    }
	
	    public string Cpf
	    {
		    get { return cpf ;}
           	    set { cpf = value; }
	    }

	    public string Genero
	    {
		    get { return genero;}
           	    set { genero= value; }
	    }

	    public string Email
	    {
		    get { return email;}
           	    set { email= value; }
	    }

	    public string Usuario
	    {
		    get { return usuario;}
           	set { usuario = value; }
	    }

	    public string Senha
	    {
		    get { return senha;}
           	    set { senha= value; }
	    }

	    public string Foto_do_perfil
	    {
		    get { return foto_de_perfil;}
            set { foto_de_perfil= value; }
	    }

	    public string Rua
	    {
		    get { return rua;}
           	    set { rua= value; }
	    }

	    public int Numero
	    {
		    get { return numero;}
           	    set { numero= value; }
	    }

	    public string Bairro
	    {
		    get { return bairro;}
           	    set { bairro= value; }
	    }

	    public string Uf
	    {
		    get { return uf;}
           	    set { uf= value; }
	    }

	    public string Cidade
	    {
		    get { return cidade;}
           	    set { cidade = value; }
	    }

	    public string Cep
	    {
		    get { return cep;}
           	    set { cep = value; }
	    }

	    public string Complemento
	    {
		    get { return complemento;}
           	    set { complemento = value; }
	    }

	    public int Privilegio
	    {
		    get { return privilegio;}
           	    set { privilegio = value; }
	    }

	    public string Nascimento
	    {
		    get {return nascimento; }
		    set {nascimento = value;}
	    }
	    public Registro(string Nome, string Nascimento, string Rg, string Cpf, string Genero, string Email, string Usuario, string Senha, string Foto_do_perfil, string Rua, int Numero, string Bairro, string Uf, string Cidade, string Cep, string Complemento, int Privilegio )
	    {
		    this.Nome = Nome;
		    this.Nascimento = Nascimento;
		    this.Rg = Rg;
		    this.Cpf = Cpf;
		    this.Genero = Genero;
		    this.Email = Email;
		    this.Usuario = Usuario;
		    this.Senha = Senha;
		    this.Foto_do_perfil = Foto_do_perfil;
		    this.Rua = Rua;
		    this.Numero = Numero;
		    this.Bairro = Bairro;
		    this.Uf = Uf;
		    this.Cidade = Cidade;
		    this.Cep = Cep;
		    this.Complemento = Complemento;
		    this.Privilegio = Privilegio;
            c = new Conexao();
	    }

        public Registro()
        {
            c = new Conexao();
        }

        public Registro(string Usuario, string Senha)
        {
            this.Usuario = Usuario;
            this.Senha = Senha;
            c = new Conexao();
        }
        public Registro(string Usuario, string Nome, string Nascimento)
        {
            this.Usuario = Usuario;
            this.Nome = Nome;
            this.Nascimento = Nascimento;
            c = new Conexao();
        }

        public Registro(string Usuario)
        {
            this.Usuario = Usuario;
            c = new Conexao();
        }
        public Registro(string Usuario, string Senha, int Privilegio)
        {
            this.Usuario = Usuario;
            this.Senha = Senha;
            this.Privilegio = Privilegio;
            c = new Conexao();
        }

        public bool usuario_existe()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Registro WHERE usuario=@usuario and senha=@senha and privilegio != 999", c.gConenection());
            cmd.Parameters.AddWithValue("@usuario",Usuario);
            cmd.Parameters.AddWithValue("@senha", Senha);
            int k = int.Parse(cmd.ExecuteScalar().ToString());
            if(k>0)
            {
                return true;
            }
            return false;
        }
        public bool adm_existe()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Registro WHERE usuario=@usuario and senha=@senha and privilegio=999", c.gConenection());
            cmd.Parameters.AddWithValue("@usuario", Usuario);
            cmd.Parameters.AddWithValue("@senha", Senha);
            int k = int.Parse(cmd.ExecuteScalar().ToString());
            if (k > 0) return true;
            return false;
        }

        public Registro selecionar_usuario()
        {
            Registro r = new Registro();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Registro WHERE usuario=@usuario", c.gConenection());
            cmd.Parameters.AddWithValue("@usuario", Usuario);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                r = new Registro(dr["nome"].ToString(), dr["nascimento"].ToString(), dr["rg"].ToString(), dr["cpf"].ToString(), dr["genero"].ToString(), dr["email"].ToString(), dr["usuario"].ToString(), dr["senha"].ToString(), dr["foto_de_perfil"].ToString(), dr["rua"].ToString(), int.Parse(dr["numero"].ToString()), dr["bairro"].ToString(), dr["uf"].ToString(), dr["cidade"].ToString(), dr["cep"].ToString(), dr["complemento"].ToString(), int.Parse(dr["privilegio"].ToString()));
            }
            return r;
        }

        public void inserir_Usuario()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Registro (nome, nascimento, rg, cpf, genero, email, usuario, senha, foto_de_perfil, rua, numero, bairro, uf, cidade, cep, complemento, privilegio) VALUES (@inf1, @inf2, @inf3, @inf4, @inf5, @inf6, @inf7, @inf8, @inf9, @inf10, @inf11, @inf12, @inf13, @inf14, @inf15, @inf16, @inf17)", c.gConenection());
            cmd.Parameters.AddWithValue("@inf1", Nome);
            cmd.Parameters.AddWithValue("@inf2", Nascimento);
            cmd.Parameters.AddWithValue("@inf3", Rg);
            cmd.Parameters.AddWithValue("@inf4", Cpf);
            cmd.Parameters.AddWithValue("@inf5", Genero);
            cmd.Parameters.AddWithValue("@inf6", Email);
            cmd.Parameters.AddWithValue("@inf7", Usuario);
            cmd.Parameters.AddWithValue("@inf8", Senha);
            cmd.Parameters.AddWithValue("@inf9", Foto_do_perfil);
            cmd.Parameters.AddWithValue("@inf10", Rua);
            cmd.Parameters.AddWithValue("@inf11", Numero);
            cmd.Parameters.AddWithValue("@inf12", Bairro);
            cmd.Parameters.AddWithValue("@inf13", Uf);
            cmd.Parameters.AddWithValue("@inf14", Cidade);
            cmd.Parameters.AddWithValue("@inf15", Cep);
            cmd.Parameters.AddWithValue("@inf16", Complemento);
            cmd.Parameters.AddWithValue("@inf17", Privilegio);
            cmd.ExecuteNonQuery();
        }

        public void Update_Usuario()
        {
            SqlCommand cmd = new SqlCommand("UPDATE [Registro] SET nome = @inf1, nascimento = @inf2, rg = @inf3, cpf = @inf4, genero = @inf5, email = @inf6, usuario = @inf7, senha = @inf8, foto_de_perfil = @inf9, rua = @inf10, numero = @inf11, bairro = @inf12, uf = @inf13, cidade = @inf14, cep = @inf15, complemento = @inf16, privilegio = @inf17 WHERE usuario=@inf7", c.gConenection());
            cmd.Parameters.AddWithValue("@inf1", Nome);
            cmd.Parameters.AddWithValue("@inf2", Nascimento);
            cmd.Parameters.AddWithValue("@inf3", Rg);
            cmd.Parameters.AddWithValue("@inf4", Cpf);
            cmd.Parameters.AddWithValue("@inf5", Genero);
            cmd.Parameters.AddWithValue("@inf6", Email);
            cmd.Parameters.AddWithValue("@inf7", Usuario);
            cmd.Parameters.AddWithValue("@inf8", Senha);
            cmd.Parameters.AddWithValue("@inf9", Foto_do_perfil);
            cmd.Parameters.AddWithValue("@inf10", Rua);
            cmd.Parameters.AddWithValue("@inf11", Numero);
            cmd.Parameters.AddWithValue("@inf12", Bairro);
            cmd.Parameters.AddWithValue("@inf13", Uf);
            cmd.Parameters.AddWithValue("@inf14", Cidade);
            cmd.Parameters.AddWithValue("@inf15", Cep);
            cmd.Parameters.AddWithValue("@inf16", Complemento);
            cmd.Parameters.AddWithValue("@inf17", Privilegio);
            cmd.ExecuteNonQuery();
        }
        public void Update_Usuario_senha(string s)
        {
            SqlCommand cmd = new SqlCommand("UPDATE [Registro] SET senha = @senha WHERE usuario = @usuario", c.gConenection());
            cmd.Parameters.AddWithValue("@usuario", Usuario);
            cmd.Parameters.AddWithValue("@senha", s);
            cmd.ExecuteNonQuery();
        }
        public void Delete_Usuario()
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Registro WHERE usuario=@usuario", c.gConenection());
            cmd.Parameters.AddWithValue("@usuario", Nome);
        }
        public List<Registro> atletas_inscritos(int c_id)
        {
            SqlCommand cmd = new SqlCommand("SELECT r.nome as rn, r.usuario as ru, r.nascimento as rnas FROM CompeticaoRegistro cr INNER JOIN Registro r ON r.usuario = cr.Registro_usuario WHERE Competicao_id = @c_id", c.gConenection());
            cmd.Parameters.AddWithValue("@c_id", c_id);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Registro> Lista = new List<Registro>();
            while (dr.Read())
            {
                Registro r = new Registro( dr["ru"].ToString(), dr["rn"].ToString(), dr["rnas"].ToString());
                Lista.Add(r);

            }
            dr.Close();
            return Lista;
        }

        public List<Registro> RegAtleta(string idAtleta)
        {
            List<Registro> lista = new List<Registro>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Registro WHERE usuario = @s_id", c.gConenection());
            cmd.Parameters.AddWithValue("@s_id", idAtleta);
            //c.gConenection().Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Registro comp = new Registro(); //dr["nome"].ToString(), DateTime.Parse(dr["nascimento"].ToString()), dr["rg"].ToString(), dr["cpf"].ToString(), dr["genero"].ToString(), dr["email"].ToString(), dr["usuario"].ToString(), null, dr["foto_de_perfil"].ToString(), dr["rua"].ToString(), int.Parse(dr["numero"].ToString()), dr["bairro"].ToString(), dr["uf"].ToString(), int.Parse(dr["cidade"].ToString()), int.Parse(dr["cep"].ToString()), int.Parse(dr["complemento"].ToString()), dr["privilegio"].ToString());
                comp.nome = dr["nome"].ToString();
                comp.nascimento = dr["nascimento"].ToString();
                comp.rg = dr["rg"].ToString();
                comp.cpf = dr["cpf"].ToString();
                comp.genero = dr["genero"].ToString();
                comp.email = dr["email"].ToString();
                comp.usuario = dr["email"].ToString();
                comp.senha = null;
                comp.foto_de_perfil = dr["foto_de_perfil"].ToString();
                comp.numero = int.Parse(dr["numero"].ToString());
                comp.rua = dr["rua"].ToString();
                comp.bairro = dr["bairro"].ToString();
                comp.uf = dr["uf"].ToString();
                comp.cidade = dr["cidade"].ToString();
                comp.cep = dr["cep"].ToString();
                comp.complemento = dr["complemento"].ToString();
                comp.privilegio = int.Parse(dr["privilegio"].ToString());
                lista.Add(comp);
            }
            c.gConenection().Close();
            return lista;
        }

        public List<Registro> selec_all()
        {
            List<Registro> lista = new List<Registro>();
            SqlCommand cmd = new SqlCommand("SELECT usuario FROM Registro", c.gConenection());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) lista.Add(new Registro(dr["usuario"].ToString()));
            return lista;     
        }
        public List<Registro> selec_all(int privilegio)
        {
            List<Registro> lista = new List<Registro>();
            SqlCommand cmd = new SqlCommand("SELECT usuario FROM Registro WHERE privilegio != @privilegio", c.gConenection());
            cmd.Parameters.AddWithValue("@privilegio", privilegio);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) lista.Add(new Registro(dr["usuario"].ToString()));

            return lista;
        }

        public List<Registro> selec_all_adm()
        {
            List<Registro> lista = new List<Registro>();
            SqlCommand cmd = new SqlCommand("SELECT login FROM Administrador", c.gConenection());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) lista.Add(new Registro(dr["login"].ToString()));
            return lista;
        }

        public List<Registro> buscar(string strbsc)
        {
            List<Registro> bscr = new List<Registro>();
            strbsc = "'%" + strbsc + "%'";


            string strAtleta = "select r.nome as 'Nome do Atleta', r.cidade as 'Cidade do Atleta', r.genero as 'Gênero do Atleta', r.uf as 'UF do Atleta' from Registro r where (r.nome like " + strbsc + ") OR (r.genero like " + strbsc + ") OR (r.cidade like " + strbsc + ") OR (r.uf like " + strbsc + ")";


            SqlCommand cmdAt = new SqlCommand(strAtleta, c.gConenection());
            SqlDataReader rdrAt = cmdAt.ExecuteReader();

            Registro fsql = null;
            while (rdrAt.Read())
            {
                fsql = new Registro();
                fsql.nome = rdrAt["Nome do Atleta"].ToString();
                fsql.genero = rdrAt["Gênero do Atleta"].ToString();
                fsql.cidade = rdrAt["Cidade do Atleta"].ToString();
                fsql.uf = rdrAt["UF do Atleta"].ToString();

                bscr.Add(fsql);
            }

            rdrAt.Close();

            return bscr;
        }


    }

    }

