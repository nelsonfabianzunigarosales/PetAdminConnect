﻿using PetAdminConnect.Shared.DTOs;
using PetAdminConnect.Shared.Entities;
using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Intertfaces.UnitOfWork
{
    public interface ISpeciesUnitOfWork
    {
        Task<Response<Specie>> GetAsync(int id);
        Task<Response<IEnumerable<Specie>>> GetAsync(PaginationDTO pagination);
        Task<IEnumerable<Specie>> GetComboAsync();
        Task<Response<int>> GetTotalPagesAsync(PaginationDTO pagination);
    }
}