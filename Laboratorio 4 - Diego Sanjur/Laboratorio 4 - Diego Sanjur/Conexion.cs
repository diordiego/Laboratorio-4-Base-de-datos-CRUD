using MySql.Data.MySqlClient;

namespace Laboratorio_4___Diego_Sanjur
{
    public class Conexion
    {
        private static string cadenaConexion = "Server=localhost;Database=laboratorio4;Uid=root;Pwd=Xeneize217-";
        public static MySqlConnection? ObtenerConexion()
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(cadenaConexion);
                conexion.Open();
                return conexion;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al conectar: " + ex.Message);
                return null;
            }
        }
        public static List<Producto> GetProductos(string filtro)
        {
            List<Producto> listaProductos = new List<Producto>();
            string sqlQuery = "SELECT id, nombre, precio, cantidad, imagen FROM productos";   // ← precio agregado

            if (!string.IsNullOrEmpty(filtro))
            {
                sqlQuery += " WHERE id LIKE @filtro OR nombre LIKE @filtro " +               // ← espacio al inicio
                            "OR precio LIKE @filtro OR cantidad LIKE @filtro";
            }

            using (MySqlConnection? conexion = ObtenerConexion())
            {
                if (conexion == null) return listaProductos;

                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, conexion))
                {
                    if (!string.IsNullOrEmpty(filtro))
                    {
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                    }

                    using (MySqlDataReader mReader = cmd.ExecuteReader())
                    {
                        while (mReader.Read())
                        {
                            Producto prod = new Producto();
                            prod.Id = Convert.ToInt32(mReader["id"]);
                            prod.Nombre = mReader["nombre"].ToString();
                            prod.Precio = Convert.ToDecimal(mReader["precio"]);
                            prod.Cantidad = Convert.ToInt32(mReader["cantidad"]);
                            prod.Imagen = mReader["imagen"] != DBNull.Value ? (byte[])mReader["imagen"] : null;
                            listaProductos.Add(prod);
                        }
                    }
                }
            }
            return listaProductos;   // ← lo que faltaba
        }
        public static bool InsertSeguro(string tbName, Dictionary<string, object> data)
        {
            var columns = string.Join(", ", data.Keys);
            var placeholders = "@" + string.Join(", @", data.Keys);
            string sql = $"INSERT INTO {tbName} ({columns}) VALUES ({placeholders})";

            try
            {
                using (MySqlConnection? conexion = ObtenerConexion())
                {
                    if (conexion == null) return false;

                    using (MySqlCommand stmt = new MySqlCommand(sql, conexion))
                    {
                        foreach (var kvp in data)
                        {
                            stmt.Parameters.AddWithValue("@" + kvp.Key, kvp.Value ?? DBNull.Value);
                        }
                        stmt.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en INSERT: " + ex.Message);
                return false;
            }
        }
        public static bool DeleteSeguro(string tbName, string idColumna, int idValor)
        {
            string sql = $"DELETE FROM {tbName} WHERE {idColumna} = @idWhere";

            try
            {
                using (MySqlConnection? conexion = ObtenerConexion())
                {
                    if (conexion == null) return false;

                    using (MySqlCommand stmt = new MySqlCommand(sql, conexion))
                    {
                        stmt.Parameters.AddWithValue("@idWhere", idValor);

                        int filasAfectadas = stmt.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en DELETE: " + ex.Message);
                return false;
            }
        }
        public static bool UpdateSeguro(string tbName, Dictionary<string, object> data, string idColumna, int idValor)
        {
            // "nombre = @nombre, precio = @precio, cantidad = @cantidad, imagen = @imagen"
            var sets = string.Join(", ", data.Keys.Select(k => $"{k} = @{k}"));
            string sql = $"UPDATE {tbName} SET {sets} WHERE {idColumna} = @idWhere";

            try
            {
                using (MySqlConnection? conexion = ObtenerConexion())
                {
                    if (conexion == null) return false;

                    using (MySqlCommand stmt = new MySqlCommand(sql, conexion))
                    {
                        foreach (var kvp in data)
                        {
                            stmt.Parameters.AddWithValue("@" + kvp.Key, kvp.Value ?? DBNull.Value);
                        }
                        stmt.Parameters.AddWithValue("@idWhere", idValor);

                        int filasAfectadas = stmt.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en UPDATE: " + ex.Message);
                return false;
            }
        }
    }
}