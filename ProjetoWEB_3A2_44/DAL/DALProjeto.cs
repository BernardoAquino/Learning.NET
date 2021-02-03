using System;
using System.Data; //necessário para a utilização do DataTable
using MySql.Data.MySqlClient;

namespace DAL
{
    class DALProjeto : Conexao
    {
        public DALProjeto(string servidor, string bancodedados, string usuario, string senha)
        {
            // O operador ?? é chamado operador de coalescência nula. 
            // Ele retornará o operando esquerdo se o operando não for nulo; 
            // caso contrário, ele retornará o operando direito.

            this.servidor = servidor ?? throw new ArgumentNullException(nameof(servidor));      //se o servidor for nulo, lança uma exceção
            this.bancodedados = bancodedados ?? throw new ArgumentNullException(nameof(bancodedados));
            this.usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
            this.senha = senha ?? throw new ArgumentNullException(nameof(senha));
        }       

        public int Insert(string tabela, Object objDTO)
        {
            try
            {
                var propriedades = objDTO.GetType().GetProperties();    //propriedades armazena nome e tipo de todos os atributos da DTO recebida por parâmetro

                for (int i = 1; i < propriedades.Length; i++)
                {
                    if (propriedades[i].GetValue(objDTO).ToString() == null)
                    {
                        throw new Exception($"Campo {propriedades[i].Name} não pode ser nulo");
                    }
                }

                string msg = $"INSERT INTO {tabela}(";

                foreach (var atributo in propriedades)
                {   
                    msg += $"{atributo.Name},";
                }

                msg = msg.Remove(msg.Length - 1);
                msg += ") VALUES( ";

                foreach (var atributo in propriedades)
                {
                    if (atributo.GetType().Equals(typeof(DateTime)) || 
                        DateTime.TryParse(atributo.GetValue(objDTO).ToString(), out var y))
                        msg += $"'{Convert.ToDateTime(atributo.GetValue(objDTO)).ToString("yyyy/MM/dd")}',";
                    else if (Decimal.TryParse(atributo.GetValue(objDTO).ToString(), out var x))
                        msg += $"'{atributo.GetValue(objDTO).ToString().Replace(',', '.')}',";
                    else
                        msg += $"'{atributo.GetValue(objDTO).ToString()}',";
                }
                msg = msg.Remove(msg.Length - 1);
                msg += ");";

                return ExecutarComando(msg);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Delete(string tabela, Object objDTO, int indicePK)
        {
            try
            {
                var propriedades = objDTO.GetType().GetProperties();
                
                if (propriedades[indicePK].GetValue(objDTO) == null)
                {
                    throw new Exception($"Campo {propriedades[indicePK].Name} não pode ser nulo");
                }
                string msg = $@"DELETE FROM {tabela} 
                                   WHERE {propriedades[indicePK].Name} = {propriedades[indicePK].GetValue(objDTO).ToString()} ;";
                return ExecutarComando(msg);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public int Update(string tabela, Object objDTO, int indicePK)
        {
            try
            {
                var propriedades = objDTO.GetType().GetProperties();

                for (int i = 0; i < propriedades.Length; i++)
                {
                    if (propriedades[i].GetValue(objDTO) == null)
                    {
                        throw new Exception($"Campo {propriedades[i].Name} nao pode ser nulo");
                    }
                }

                string msg = $"UPDATE {tabela} SET ";

                for (int i = 0; i < propriedades.Length; i++)
                {
                    if (i != indicePK)
                        if (propriedades[i].GetType().Equals(typeof(DateTime)) || DateTime.TryParse(propriedades[i].GetValue(objDTO).ToString(), out var y))
                            msg += $"{propriedades[i].Name} = '{Convert.ToDateTime(propriedades[i].GetValue(objDTO)).ToString("yyyy/MM/dd")}',";
                        else if (Decimal.TryParse(propriedades[i].GetValue(objDTO).ToString(), out var x))
                            msg += $"{propriedades[i].Name} = '{propriedades[i].GetValue(objDTO).ToString().Replace(',', '.')}',";
                        else
                            msg += $"{propriedades[i].Name} = '{propriedades[i].GetValue(objDTO).ToString()}',";
                }

                msg = msg.Remove(msg.Length - 1);
                msg += $" where {propriedades[indicePK].Name} = {propriedades[indicePK].GetValue(objDTO).ToString()} ;";
                return ExecutarComando(msg);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public DataTable Select(string tabela)
        {
            try
            {
                string msg = $"SELECT * FROM {tabela}";
                return ExecutarConsulta(msg);
            }
            catch (Exception)
            {

                throw;
            }            
        }

        public DataTable Select(string tabela, string condicao)
        {
            try
            {
                string msg = $"SELECT * FROM {tabela} WHERE {condicao}";
                return ExecutarConsulta(msg);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Select(string tabela, string condicao, string coluna) //SelectColumnPorId
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Select(tabela, condicao);
                return dt.Rows[0][$"{coluna}"].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    abstract class Conexao //abstract: significa que a classe não pode ser instanciada
    {
        protected string servidor, bancodedados, usuario, senha;

        MySqlConnection conn;
        private void Conectar()
        {
            try
            {
                conn = new MySqlConnection($@"server = {servidor};
                                                uid = {usuario};
                                                pwd = {senha};
                                                database = {bancodedados};
                                                Character Set = utf8");
                conn.Open();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public int ExecutarComando(string SQL) //insert, delete e update
        {
            try
            {
                Conectar();
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                return cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable ExecutarConsulta(string SQL) //select
        {
            try
            {
                Conectar();
                MySqlDataAdapter da = new MySqlDataAdapter(SQL, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}