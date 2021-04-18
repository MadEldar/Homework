using System;
using LibraryAPI.Enums;

namespace LibraryAPI.Interfaces
{
    public interface IRequest
    {
        Guid Id { get; set; }
        RequestStatus Status { get; set; }
        DateTime RequestedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}