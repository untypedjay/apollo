using Apollo.Core.Interface.Daos;
using Apollo.Domain;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Apollo.Core.Daos
{
    public abstract class CinemaHallDao : ICinemaHallDao
    {
        private readonly AdoTemplate template;

        public CinemaHallDao(IConnectionFactory connectionFactory)
        {
            template = new AdoTemplate(connectionFactory);
        }

        public virtual async Task<bool> DeleteAsync(CinemaHall cinemaHall)
        {
            return (await template.ExecuteAsync(
                "DELETE FROM CinemaHall WHERE HallName=@hn",
                new QueryParameter("@hn", cinemaHall.Name)
                )) == 1;
        }

        public virtual async Task<IEnumerable<CinemaHall>> FindAllAsync()
        {
            return await template.QueryAsync<CinemaHall>("SELECT * FROM CinemaHall", MapRowToCinemaHall);
        }

        public virtual async Task<CinemaHall> FindByNameAsync(string name)
        {
            return await template.QuerySingleAsync<CinemaHall>(
                "SELECT * FROM CinemaHall WHERE HallName=@hn",
                MapRowToCinemaHall,
                new QueryParameter("@hn", name));
        }

        public virtual async Task<bool> InsertAsync(CinemaHall cinemaHall)
        {
            return (await template.ExecuteAsync(
                "INSERT INTO CinemaHall (HallName, RowAmount, SeatAmount) VALUES (@hn, @ra, @sa)",
                new QueryParameter("@hn", cinemaHall.Name),
                new QueryParameter("@ra", cinemaHall.RowAmount),
                new QueryParameter("@sa", cinemaHall.SeatAmount)
                )) == 1;
        }

        public virtual async Task<bool> UpdateAsync(CinemaHall cinemaHall)
        {
            return (await template.ExecuteAsync(
                "UPDATE CinemaHall SET RowAmount=@ra, SeatAmount=@sa WHERE HallName=@hn",
                new QueryParameter("@ra", cinemaHall.RowAmount),
                new QueryParameter("@sa", cinemaHall.SeatAmount),
                new QueryParameter("@hn", cinemaHall.Name)
                )) == 1;
        }

        private CinemaHall MapRowToCinemaHall(IDataRecord row)
        {
            return new CinemaHall(
                (string)row["HallName"],
                (int)row["RowAmount"],
                (int)row["SeatAmount"]
            );
        }
    }
}
