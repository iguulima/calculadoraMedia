namespace SistemaNotas.Models
{
    public class NotasModel
    {
        public float? Nota1 { get; set; }
        public float? Nota2 { get; set; }
        public float? Media { get; set; }

        public void CalcularMedia()
        {
            Media = (Nota1.Value + Nota2.Value) / 2;
        }
    }
}
