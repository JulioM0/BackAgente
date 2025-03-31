namespace BackAgente.Modelos
{
    public class EsquemasModel
    {
        public int EsquemaID {  get; set; }
        public string Esquema {  get; set; }
        public string Clave {  get; set; }
        public string Descripcion {  get; set; }
        public bool Eliminado { get; set; }
    }
}
