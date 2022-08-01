using Newtonsoft.Json;
using QuizAPI.Data;
using QuizAPI.Models.Dtos;
using QuizAPI.Models.Entities;
using QuizAPI.Models.Helpers;
using System.Net.Http.Headers;

namespace QuizAPI.Repositories
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private readonly QuizDbContext _context;
        string Baseurl = "http://localhost:5018";
        public QuestionsRepository(QuizDbContext context)
        {
            _context = context;
        }
        public Task DeleteQuestion(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Question> GetQuestionById(int id)
        {
            var question = new Question();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var uri = $"api/quotes/{id}";
                HttpResponseMessage Res = await client.GetAsync(uri);
                if (Res.IsSuccessStatusCode)
                {
                    var QuoteResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    var quote = JsonConvert.DeserializeObject<Quote>(QuoteResponse);

                    question.QuestionText = quote.Content;
                    question.Option1 = quote.Author.Name;
                    question.Option2 = quote.WrongAuthorName1;
                    question.Option3 = quote.WrongAuthorName2;
                }
                if (question!=null)
                    return question;
                return null;
            }
        }

        public async Task<List<Question>> GetQuestions()
        {
            List<Question> QuestionInfo = new();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/quotes");
                if (Res.IsSuccessStatusCode)
                {
                    var QuoteResponse = Res.Content.ReadAsStringAsync().Result;
                    var quotes = JsonConvert.DeserializeObject<List<Quote>>(QuoteResponse);
                    foreach (var quote in quotes)
                    {

                        var question = new Question()
                        {
                           QuestionText = quote.Content,
                           Option1 = quote.Author.Name,
                           Option2 = quote.WrongAuthorName1,
                           Option3 = quote.WrongAuthorName2
                        };
                        QuestionInfo.Add(question);
                    }
                }
                if(QuestionInfo.Count > 0)
                    return QuestionInfo;
                return null;
            }
        }

        public Task<Question> PostQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public Task PutQuestion(int id, Question question)
        {
            throw new NotImplementedException();
        }

        public Task<bool> QuestionExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
