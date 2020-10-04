using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRepository.ViewModels
{
    public class AuthorBookView
    {
        public Guid AuthorId { get; set; }
        public Guid BookId { get; set; }
    }
}
