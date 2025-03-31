namespace BackAgente.Modelos
{
    public class TipoObjetoModel
    {
        public int TipoObjetoID { get; set; }
        public string TipoObjeto {  get; set; }
        public string Icono { get; set; }
        public int TipoObjetoPadreID {  get; set; }
        public string Descripcion { get; set; }
        public bool Eliminado { get; set; }
        public int EsquemaID {  get; set; }
    }
}