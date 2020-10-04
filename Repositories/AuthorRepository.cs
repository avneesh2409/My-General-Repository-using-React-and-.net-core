using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRepository.Models;
using MyRepository.ViewModels;

namespace MyRepository.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(DatabaseContext context) : base(context) { }

        public async Task<ObjectResult> AddBookToAuthor(AuthorBookView authorBook)
        {
            try
            {
                Author author = await context.authors.Include(s=>s.Books).Where(x => x.Id == authorBook.AuthorId).FirstOrDefaultAsync();
                Book book = await context.books.Where(e => e.Id == authorBook.BookId).FirstOrDefaultAsync();
                if (author != null && book != null)
                {
                    author.Books.Add(book);
                    context.SaveChanges();
                    return new ObjectResult(new { message = "Success", status = true });
                }
                return new ObjectResult(new { message="failed",status=false});
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        public async Task<ObjectResult> GetAuthorWithBooks(Guid id)
        {
            var result = await context.authors.Where(s=>s.Id==id).Include(e => e.Books).FirstOrDefaultAsync();
            return new ObjectResult(new { status=true,data=result});
        }

        public Task<Author> GetByName(string name) 
        {
           return FindByCondition(author => author.Name == name);
        }
    }
}