using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuoteManagement.API.Data;
using QuoteManagement.API.Models.Entities;
using QuoteManagement.API.Models.Entities.PostQuoteRequest;
using QuoteManagement.API.Models.Entities.UpdateQuoteRequest;

namespace QuoteManagement.API.Controllers
{
    [ApiController] //this is APi controller , not mvc controller
    [Route("api/quotes")]
    public class QuoteController : Controller
    {
        private readonly QuoteDbContext dbContext;

        public QuoteController(QuoteDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<List<Quote>> GetQuotes()
        {
            var quotes = dbContext.Quotes.Include(x => x.Author);
            return await quotes.ToListAsync();
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetQuote([FromRoute] Guid id)
        {
            var quote = await dbContext.Quotes.Include(x => x.Author).Where(x=>x.QuoteId==id).SingleOrDefaultAsync();
            if(quote != null)
            {
                return Ok(quote);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AddQuote(PostQuoteReq postQuoteRequest)
        {   
            var authorId = Guid.NewGuid();
            var quoteId = Guid.NewGuid();

            var author = new Author()
            {
                AuthorId = authorId,
                Name = postQuoteRequest.Author.Name,
                QuoteId = quoteId,
                CreateAt = DateTime.Now,
            };
            await dbContext.Authors.AddAsync(author);

            var quote = new Quote(author)
            {
                QuoteId = quoteId,
                CreateAt = DateTimeOffset.UtcNow,
                Content = postQuoteRequest.Content,
                WrongAuthorName1 = postQuoteRequest.WrongAuthorName1,
                WrongAuthorName2 = postQuoteRequest.WrongAuthorName2
            };
            await dbContext.Quotes.AddAsync(quote);
            
            await dbContext.SaveChangesAsync();
            return Ok(quote);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateQuote([FromRoute] Guid id,PutQuoteReq putQuoteReq)
        {
            var quote = await dbContext.Quotes.FindAsync(id);
            if (quote != null)
            {
                var authorId = quote.AuthorId;
                var author = await dbContext.Authors.FindAsync(authorId);
                if(author != null)
                {
                    author.Name = putQuoteReq.Author.Name;
                    author.UpdateAt = DateTimeOffset.UtcNow;

                    quote.Content = putQuoteReq.Content;
                    quote.WrongAuthorName1 = putQuoteReq.WrongAuthorName1;
                    quote.WrongAuthorName2 = putQuoteReq.WrongAuthorName2;
                    quote.Author.Name = author.Name;
                    quote.Author.UpdateAt = author.UpdateAt;
                    quote.UpdateAt = DateTimeOffset.UtcNow;

                    await dbContext.SaveChangesAsync();
                    return Ok(quote);
                }
                return NotFound("Author not found");
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteQuote([FromRoute] Guid id)
        {
            var quote = await dbContext.Quotes.FindAsync(id);
            if (quote != null)
            {
                dbContext.Remove(quote);
                await dbContext.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }
    }
}
