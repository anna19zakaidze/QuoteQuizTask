namespace QuoteManagement.API.Models.Entities.PostQuoteRequest
{
    public class PostQuoteReq
    {
        public string Content { get; set; }
        public PostAuthorReq Author { get; set; }
        public string WrongAuthorName1 { get; set; }
        public string WrongAuthorName2 { get; set; }
    }
}
