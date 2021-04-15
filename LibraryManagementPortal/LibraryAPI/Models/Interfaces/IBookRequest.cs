using System;

namespace LibraryAPI.Models.Interfaces
{
    public interface IBookRequest
    {
        Guid BookId { get; set; }
        Guid RequestId { get; set; }
    }
}
