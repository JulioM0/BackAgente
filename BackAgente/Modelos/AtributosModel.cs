namespace BackAgente.Modelos
{
    public class AtributosModel
    {
        public int TipoObjetoAtributoID { get; set; }
        public string TipoObjetoAtributo { get; set; }
        public string Descripcion { get; set; }
        public int EsUnico { get; set; }
        public int TipoAtributoID { get; set; }
        public int TipoObjetoID {  get; set; }
        public bool Eliminado {  get; set; }
    }
}
