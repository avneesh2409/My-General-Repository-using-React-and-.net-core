using System;

namespace MyRepository.Models
{
    public class Book : BaseEntity
    {
        public String Title { get; set; }
        public DateTime Year { get; set; }
    }
}