using System.ComponentModel.DataAnnotations;

namespace QuizAPI.Models.Dtos
{
    public class Quote
    {
        [Key]
        public Guid QuoteId { get; init; }
        public DateTimeOffset CreateAt { get; init; }
        public DateTimeOffset? UpdateAt { get; set; }
        public string WrongAuthorName1 { get; set; }
        public string WrongAuthorName2 { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public Quote()
        {

        }
        public Quote(Author author)
        {
            Author = author;
            AuthorId = author.AuthorId;
        }

    }
}
