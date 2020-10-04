using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyRepository.Models;

namespace MyRepository.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        ObjectResult Insert(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}