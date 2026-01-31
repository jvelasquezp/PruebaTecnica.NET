using App2.Models;
using Microsoft.Data.SqlClient;

namespace App2.Data
{
    public class Datos
    {
        public List<TareaModel> ListarTareas()
        {
            var listaTareas = new List<TareaModel>();
            var conn = new Connection();
            using (var conexion = new SqlConnection(conn.getConnectionString()))
            {                 
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_LISTAR_TAREAS", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        var tarea = new TareaModel();
                        tarea.IdTarea = Convert.ToInt32(lector["IdTarea"]);
                        tarea.NombreTarea = lector["NombreTarea"].ToString();
                        tarea.EstadoTarea = lector["EstadoTarea"].ToString();
                        tarea.FechaVencimientoTarea = Convert.ToDateTime(lector["FechaVencimientoTarea"]);
                        tarea.FechaCreacionTarea = Convert.ToDateTime(lector["FechaCreacionTarea"]);
                        tarea.IdCategoria = Convert.ToInt32(lector["IdCategoria"]);
                    }
                }
            }
            return listaTareas;
        }

        public List<CategoriaModel> ListarCategorias()
        {
            var listaCategorias = new List<CategoriaModel>();
            var conn = new Connection();
            using (var conexion = new SqlConnection(conn.getConnectionString()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_LISTAR_CATEGORIAS", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        var tarea = new CategoriaModel();
                        tarea.IdCategoria = Convert.ToInt32(lector["IdCategoria"]);
                        tarea.NombreCategoria = lector["NombreCategoria"].ToString();
                    }
                }
            }
            return listaCategorias;
        }

        public TareaModel ObtenerTarea(int idTarea)
        {
            var tarea = new TareaModel();
            var conn = new Connection();
            using (var conexion = new SqlConnection(conn.getConnectionString()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_OBTENER_TAREA", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdTarea", idTarea);
                using (var lector = cmd.ExecuteReader())
                {
                    if (lector.Read())
                    {
                        tarea.IdTarea = Convert.ToInt32(lector["IdTarea"]);
                        tarea.NombreTarea = lector["NombreTarea"].ToString();
                        tarea.EstadoTarea = lector["EstadoTarea"].ToString();
                        tarea.FechaVencimientoTarea = Convert.ToDateTime(lector["FechaVencimientoTarea"]);
                        tarea.FechaCreacionTarea = Convert.ToDateTime(lector["FechaCreacionTarea"]);
                        tarea.IdCategoria = Convert.ToInt32(lector["IdCategoria"]);
                    }
                }
            }
            return tarea;
        }

        public CategoriaModel ObtenerCategoria(int idCategoria)
        {
            var categoria = new CategoriaModel();
            var conn = new Connection();
            using (var conexion = new SqlConnection(conn.getConnectionString()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_OBTENER_CATEGORIA", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdCategoria", idCategoria);
                using (var lector = cmd.ExecuteReader())
                {
                    if (lector.Read())
                    {
                        categoria.IdCategoria = Convert.ToInt32(lector["IdCategoria"]);
                        categoria.NombreCategoria = lector["NombreCategoria"].ToString();
                    }
                }
            }
            return categoria;
        }
        
        public bool GuardarTarea(TareaModel tarea)
        {
            bool guardar = false;
            try
            {
                var cnn = new Connection();
                using (var conexion = new SqlConnection(cnn.getConnectionString()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_GUARDAR_TAREA", conexion);
                    cmd.Parameters.AddWithValue("NombreTarea", tarea.NombreTarea);
                    cmd.Parameters.AddWithValue("EstadoTarea", tarea.EstadoTarea);
                    cmd.Parameters.AddWithValue("FechaVencimientoTarea", tarea.FechaVencimientoTarea);
                    cmd.Parameters.AddWithValue("FechaCreacionTarea", tarea.FechaCreacionTarea);
                    cmd.Parameters.AddWithValue("IdCategoria", tarea.IdCategoria);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    guardar = true;
                }
            }
            catch(Exception e)
            {
                string error = e.Message;
                guardar = false;
            }
            return guardar;
        }


        public bool EditarTarea(TareaModel tarea)
        {
            bool guardar = false;
            try
            {
                var cnn = new Connection();
                using (var conexion = new SqlConnection(cnn.getConnectionString()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_EDITAR_TAREA", conexion);
                    cmd.Parameters.AddWithValue("IdTarea", tarea.IdTarea);
                    cmd.Parameters.AddWithValue("NombreTarea", tarea.NombreTarea);
                    cmd.Parameters.AddWithValue("EstadoTarea", tarea.EstadoTarea);
                    cmd.Parameters.AddWithValue("FechaVencimientoTarea", tarea.FechaVencimientoTarea);
                    cmd.Parameters.AddWithValue("FechaCreacionTarea", tarea.FechaCreacionTarea);
                    cmd.Parameters.AddWithValue("IdCategoria", tarea.IdCategoria);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    guardar = true;
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                guardar = false;
            }
            return guardar;
        }

    }
}
