namespace CarRentingSystem.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Categories = new HashSet<Category>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; init; }
    }
}
