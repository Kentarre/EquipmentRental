using System;

namespace Domain.Models;

public interface IDomainModel
{
    Guid Id { get; set; }
}