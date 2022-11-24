using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebEjercicio
{
    public class RepositorioEstudiante
    {
        SqlConnection cnn = new SqlConnection("Data source=localhost\\SQLEXPRESS;initial catalog=DB_Estudents; integrated security=true;");


        public DataTable ListarEstudiantes()
        {
            SqlCommand cmm = new SqlCommand("select * from Estudiante", cnn);
            cnn.Open();
            using (SqlDataReader dr = cmm.ExecuteReader())
            {
                var tb = new DataTable();
                tb.Load(dr);
                return tb;
            }
        }

        public DataTable ListarPeriodos() 
        {
            SqlCommand cmm = new SqlCommand("select * from periodo", cnn);
            cnn.Open();
            using (SqlDataReader dr = cmm.ExecuteReader())
            {
                var tb = new DataTable();
                tb.Load(dr);
                return tb;
            }
        }

        public DataTable ListarNotas(int IdEst, int IdPer, int IdMat)
        {

            cnn.Open();
            SqlCommand cmm = new SqlCommand("ObtenerNotas", cnn);
            cmm.CommandType = CommandType.StoredProcedure;  
            cmm.Parameters.Add(new SqlParameter("@IdEstudiante", IdEst));
            cmm.Parameters.Add(new SqlParameter("@IdPeriodo", IdPer));
            cmm.Parameters.Add(new SqlParameter("@IdMateria", IdMat));
            
            using (SqlDataReader dr = cmm.ExecuteReader())
            {
                var tb = new DataTable();
                tb.Load(dr);
                return tb;
            }
            
        }

        public DataTable ListarMaterias()
        {
            cnn.Open();
            SqlCommand cmm = new SqlCommand("select * from Materia", cnn);

            using (SqlDataReader dr = cmm.ExecuteReader())
            {
                var tb = new DataTable();
                tb.Load(dr);
                return tb;
            }
        }

        public void AdicionarRegistro(int IdEst, int IdPer, int IdMat,decimal Nota)
        {
            cnn.Open();
            SqlCommand cmm = new SqlCommand("insert into MatCursoEstudiante(IdPeriodo,IdEstudiante,IdMateria,Nota) values(@IdPer,@IdEst,@IdMat,@Nota) ", cnn);
            cmm.Parameters.AddWithValue("@IdPer", IdPer);
            cmm.Parameters.AddWithValue("@IdEst", IdEst);
            cmm.Parameters.AddWithValue("@IdMat", IdMat);
            cmm.Parameters.AddWithValue("@Nota", Nota);

            cmm.ExecuteNonQuery();
            cnn.Close();
        }
        public void EliminarRegistro(int Id)
        {
            cnn.Open();
            SqlCommand cmm = new SqlCommand("Delete from MatCursoEstudiante Where IdMatCursoEst = @id", cnn);
            cmm.Parameters.AddWithValue("@id", Id);

            cmm.ExecuteNonQuery();
            cnn.Close();
        }

        public void ActualizarRegistro(int Id, double Nota)
        {
            cnn.Open();
            SqlCommand cmm = new SqlCommand("Update MatCursoEstudiante set Nota=@Nota Where IdMatCursoEst = @id", cnn);
            cmm.Parameters.AddWithValue("@id", Id);
            cmm.Parameters.AddWithValue("@Nota", Nota);

            cmm.ExecuteNonQuery();
            cnn.Close();
        }
    }
}