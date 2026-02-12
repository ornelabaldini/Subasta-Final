namespace Subastas_Final.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public Postor Postor { get; set; }
        public Subastador Subastador { get; set; }


        public bool EsPostor { get; set; }
        public bool EsSubastador { get; set; }
    }
}
