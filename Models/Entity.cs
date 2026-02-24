namespace Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; //ustalamy wartość domyślną, inną niż null

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }

    }
}
