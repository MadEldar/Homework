using System;

namespace LibraryAPI.Interfaces
{
    public interface ICategory
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}