import { fetchShows, Show } from '../services/showService';

export async function searchByMovieTitle(movieTitle: string) {
  const response = await fetchShows();
  const shows = await response.json();
  return shows.filter((show: Show) => show.movie.title.includes(movieTitle));
}

export async function searchByDate(dateString: string) {
  const date = new Date(dateString);
  const response = await fetchShows();
  const shows = await response.json();
  return shows.filter((show: Show) => {
    const startsAt = new Date(show.startsAt);
    console.log(startsAt.toLocaleDateString());
    console.log(date.toLocaleDateString());
    return startsAt.toLocaleDateString() === date.toLocaleDateString();

  });
}