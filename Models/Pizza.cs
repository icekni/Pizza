namespace RestoPizza.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string nom { get; set; }
        public float prix { get; set; }
        public bool vegetarienne { get; set; }
        public string ingredients { get; set; }

    }
}
