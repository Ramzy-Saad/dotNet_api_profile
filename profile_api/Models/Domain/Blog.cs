namespace profile_api.Models.Domain
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string? Image { get; set; }
        public Boolean Status { get; set; }
        public int? CategoryId { get; set; }

        // navigation properities
        public Category? Category { get; set; }
    }
}
