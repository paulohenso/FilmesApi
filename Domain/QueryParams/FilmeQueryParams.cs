namespace Domain.QueryParams
{
    public class FilmeQueryParams
    {
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Pagina { get; set; } = 1;
        public int Limite { get; set; } = 20;
    }
}
