using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Data;
using QuizAPI.Models.Entities;
using QuizAPI.Models.Helpers;
using QuizAPI.Repositories;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsRepository repository;
        public QuestionsController(IQuestionsRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/Questions
        [HttpGet]
        public async Task<ActionResult<List<Question>>> GetQuestions()
        {
            List<Question>? questions = await repository.GetQuestions();
            if (questions != null)
            {
                return questions;
            }
            return NotFound();
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var question = await repository.GetQuestionById(id);

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }

        // PUT: api/Questions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {
            return Ok();
        }

        // POST: api/Questions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(Question question)
        {
            return Ok();
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            //if (_context.Questions == null)
            //{
            //    return NotFound();
            //}
            //var question = await _context.Questions.FindAsync(id);
            //if (question == null)
            //{
            //    return NotFound();
            //}

            //_context.Questions.Remove(question);
            //await _context.SaveChangesAsync();

            //return NoContent();
            return Ok();
        }

        private bool QuestionExists(int id)
        {
            //return (_context.Questions?.Any(e => e.QuestionId == id)).GetValueOrDefault();
            return true;
        }
    }
}
