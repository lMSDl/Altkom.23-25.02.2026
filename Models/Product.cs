namespace Models
{
    public class Product    
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; //ustalamy wartość domyślną, inną niż null
        public float Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; //ustalamy wartość domyślną na aktualny czas
    }
}
