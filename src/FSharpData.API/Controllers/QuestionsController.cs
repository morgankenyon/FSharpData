﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSharpData.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FSharpData.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private IQuestionRepository questionRepo;

        public QuestionsController(IQuestionRepository questionRepository)
        {
            questionRepo = questionRepository;
        }
        // GET api/questions
        [Produces("application/json")]
        [HttpGet]
        public async Task<IEnumerable<Question>> Get()
        {
            return await questionRepo.GetQuestions();
        }

        // GET api/questions/5
        [HttpGet("{id}")]
        public async Task<Question> Get(int id)
        {
            return await questionRepo.GetQuestion(id);
        }

        // POST api/questions
        [HttpPost]
        public async Task<Question> Post(Question question)
        {
            return await questionRepo.CreateQuestion(question);
        }
    }
}