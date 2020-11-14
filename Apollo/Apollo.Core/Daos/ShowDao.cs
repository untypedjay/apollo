using Apollo.Core.Interface.Daos;
using Apollo.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo.Core.Daos
{
    public abstract class ShowDao : IShowDao
    {
        private readonly AdoTemplate template;

        public ShowDao(IConnectionFactory connectionFactory)
        {
            template = new AdoTemplate(connectionFactory);
        }

        public virtual async Task<bool> DelegeAsync(Show show)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<Show>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<Show>> FindByCinemaHall(CinemaHall cinemaHall)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<Show>> FindByDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<Show>> FindByExactDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<Show>> FindByMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> InsertAsync(Show show)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> UpdateAsync(Show show)
        {
            throw new NotImplementedException();
        }
    }
}
