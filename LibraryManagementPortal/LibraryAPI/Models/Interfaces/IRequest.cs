using System;

namespace LibraryAPI.Interfaces
{
    public interface IRequest
    {
        Guid Id { get; set; }
        string Status { get; set; }
        DateTime RequestedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}