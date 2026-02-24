namespace Models
{
    public class Product    : Entity
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; //ustalamy wartość domyślną na aktualny czas

        public override string ToString()
        {
            return $"{base.ToString()} - {Price} - {CreatedAt}";
        }
    }
}
