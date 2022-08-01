namespace QuoteManagement.API.Models.Entities.UpdateQuoteRequest
{
    public class PutQuoteReq
    {
        public string Content { get; set; }
        public PutAuthorReq Author { get; set; }
        public string WrongAuthorName1 { get; set; }
        public string WrongAuthorName2 { get; set; }
    }
}
