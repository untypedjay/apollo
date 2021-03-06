﻿using Apollo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Interface.Services
{
    public interface IShowService
    {
        Task<IEnumerable<Show>> GetAllShows();
        Task<IEnumerable<Show>> GetShowsToday();
        Task<IEnumerable<Show>> GetShowsByMovieSearch(string search);
        Task<IEnumerable<Show>> GetShowsByGenreSearch(string search);
        Task<int> GetCapacityByShow(Show show);
        Task<bool> ShowExists(Show show);
        Task<bool> Insert(Show show);
        Task<bool> Delete(Show show);
    }
}
