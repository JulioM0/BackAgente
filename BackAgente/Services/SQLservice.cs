using BackAgente.Modelos;
using BackAgente.Repositorios;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;

namespace BackAgente.Services
{
    public class SQLservice
    {
        private readonly string _connectionString;
        public SQLservice(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection obtenerConexion()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<List<EsquemasModel>> Esquemas()
        {
            var esquemas = new List<EsquemasModel>();

            using (var connection = obtenerConexion())
            {
                connection.Open();
                var query = "SELECT EsquemaID, Esquema, Clave, Descripcion, Eliminado FROM Activos.Esquemas";

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        esquemas.Add(new EsquemasModel
                        {
                            EsquemaID = reader.GetInt32(0),
                            Esquema = reader.GetString(1),
                            Clave = reader.GetString(2),
                            Descripcion = reader.GetString(3),
                            Eliminado = reader.GetBoolean(4)
                        });
                    }
                }
            }
            return esquemas;
        }

        public async Task<List<TipoObjetoModel>> TipoObjetos(int esquemaID)
        {
            var objetos = new List<TipoObjetoModel>();

            using (var connection = obtenerConexion())
            {
                connection.Open();
                var query = "SELECT TipoObjetoID, TipoObjeto FROM Activos.TipoObjetos WHERE EsquemaID = @EsquemaID";

                using (var comando = new SqlCommand(query, connection))
                {
                    comando.Parameters.AddWithValue("@EsquemaID", esquemaID);
                    using (var reader = await comando.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            objetos.Add(new TipoObjetoModel
                            {
                                TipoObjetoID = reader.GetInt32(0),
                                TipoObjeto = reader.GetString(1),
                            });
                        }
                    }
                }
            }

            return objetos;
        }
    }
}
