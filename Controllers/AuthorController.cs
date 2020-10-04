using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRepository.Models;
using MyRepository.Repositories;
using MyRepository.ViewModels;

namespace MyRepository.Controllers
{
    [ApiController]
    [Route("author")]
    public class AuthorController : ControllerBase
    {
        private IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        { _authorRepository = authorRepository; }

        [HttpGet("")]
        public IEnumerable<Author> GetAllAuthots() => _authorRepository.GetAll();

        [HttpGet("{authorName}")]
        public Task<Author> GetAuthorByName(String authorName) => _authorRepository.GetByName(authorName);

        [HttpPost("")]
        public async Task<ObjectResult> AddAuthor(Author author) {
            Author check = await _authorRepository.GetByName(author.Name);
            if (check == null) {
                return _authorRepository.Insert(author);
            }
            return new ObjectResult(new { status = false, message = "unable to add Author with this name , already exist !!" });
        }

        [HttpPost("author-book")]
        public async Task<ObjectResult> AuthorToBook(AuthorBookView authorBook){
            return await _authorRepository.AddBookToAuthor(authorBook);
    }
        [HttpGet("author-book/{id}")]
        public async Task<ObjectResult> AuthorToBook(Guid id) => await _authorRepository.GetAuthorWithBooks(id);

    }
}