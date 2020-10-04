using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyRepository.Models;
using MyRepository.ViewModels;

namespace MyRepository.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<Author> GetByName(string firstName);
        Task<ObjectResult> AddBookToAuthor(AuthorBookView authorBook);
        Task<ObjectResult> GetAuthorWithBooks(Guid id);
    }
}