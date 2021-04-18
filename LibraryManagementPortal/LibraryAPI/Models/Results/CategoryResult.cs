using System;
using System.Collections.Generic;

namespace LibraryAPI.Models.Results
{
    public class CategoryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<BookResult> Books { get; set; }
    }
}