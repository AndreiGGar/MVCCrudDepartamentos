using MVCCrudDepartamentos.Models;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;

namespace MVCCrudDepartamentos.Repositories
{
    public class RepositoryDepartamentos
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryDepartamentos() 
        {
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;User ID=sa; Password=";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public List<Departamento> GetDepartamentos()
        {
            string sql = "SELECT * FROM DEPT";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Departamento> departamentos = new List<Departamento>();
            while (this.reader.Read())
            {
                Departamento departamento = new Departamento();
                departamento.IdDepartamento = int.Parse(this.reader["DEPT_NO"].ToString());
                departamento.Nombre = this.reader["DNOMBRE"].ToString();
                departamento.Localidad = this.reader["LOC"].ToString();
                departamentos.Add(departamento);
            }
            this.reader.Close();
            this.cn.Close();
            return departamentos;
        }

        public Departamento FindDepartamento(int id)
        {
            string sql = "SELECT * FROM DEPT WHERE DEPT_NO=@IDDEPT";
            SqlParameter pamid = new SqlParameter("@IDDEPT", id);
            this.com.Parameters.Add(pamid);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.reader.Read();
            Departamento departamento = new Departamento();
            departamento.IdDepartamento = int.Parse(this.reader["DEPT_NO"].ToString());
            departamento.Nombre = this.reader["DNOMBRE"].ToString();
            departamento.Localidad = this.reader["LOC"].ToString();
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return departamento;
        }

        public void InsertDepartamento(int id, string nombre, string localidad)
        {
            string sql = "INSERT INTO DEPT VALUES (@ID, @NOMBRE, @LOCALIDAD)";
            SqlParameter pamid = new SqlParameter("@ID", id);
            SqlParameter pamnombre = new SqlParameter("@NOMBRE", nombre);
            SqlParameter pamloc = new SqlParameter("@LOCALIDAD", localidad);
            this.com.Parameters.Add(pamid);
            this.com.Parameters.Add(pamnombre);
            this.com.Parameters.Add(pamloc);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        public void UpdateDepartamento(int id, string nombre, string localidad)
        {
            string sql = "UPDATE DEPT SET DNOMBRE=@NOMBRE, LOC=@LOCALIDAD WHERE DEPT_NO=@ID";
            SqlParameter pamid = new SqlParameter("@ID", id);
            SqlParameter pamnombre = new SqlParameter("@NOMBRE", nombre);
            SqlParameter pamloc = new SqlParameter("@LOCALIDAD", localidad);
            this.com.Parameters.Add(pamid);
            this.com.Parameters.Add(pamnombre);
            this.com.Parameters.Add(pamloc);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        public void DeleteDepartamento(int id)
        {
            string sql = "DELETE FROM DEPT WHERE DEPT_NO=@ID";
            SqlParameter pamid = new SqlParameter("@ID", id);
            this.com.Parameters.Add(pamid);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.cn.Close();
            this.com.Parameters.Clear();
        }
    }
}
