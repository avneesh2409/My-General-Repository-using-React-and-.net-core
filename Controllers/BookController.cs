using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MyRepository.Models;
using MyRepository.Repositories;
using Microsoft.AspNetCore.Cors;

namespace MyRepository.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private IRepository<Book> bookRepository;
        public BookController(IRepository<Book> bookRepository)
            { this.bookRepository = bookRepository;}

        [HttpGet]
        [Route("")]
        public IEnumerable<Book> GetAllBooks() => bookRepository.GetAll();

        [HttpGet]
        [Route("{bookId}")]
        public Book GetBookById(Guid bookId) => bookRepository.GetById(bookId);

        [HttpPost]
        [Route("")]
        public ObjectResult AddBook(Book book) => bookRepository.Insert(book);

        [HttpDelete]
        [Route("{bookId}")]
        public void DeleteBook(Guid bookId) => bookRepository.Delete(bookId);
    }
}