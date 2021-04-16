using System;
using System.Collections.Generic;
using LibraryAPI.Interfaces;

namespace LibraryAPI.Models
{
    public class Category : ICategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
        public Category()
        {
        }
        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public bool CheckEmptyFields()
        {
            return string.IsNullOrWhiteSpace(Name);
        }
    }
}