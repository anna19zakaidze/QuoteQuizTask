using System.ComponentModel.DataAnnotations;

namespace QuoteManagement.API.Models.Entities
{
    public class Author
    {
        [Key] //primary key
        public Guid AuthorId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreateAt { get; init; }
        public DateTimeOffset? UpdateAt { get; set; }

        public Guid QuoteId { get; set; }
        public ICollection<Quote> Quotes { get; set; }
    }
}
