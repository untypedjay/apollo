import { Movie, fetchMovies } from '../services/movieService';
import { CinemaHall, fetchCinemaHalls } from '../services/cinemaHallService';

const dateOptions = { weekday: 'short', year: 'numeric', month: 'long', day: 'numeric' };
const timeOptions = { hour: '2-digit', minute: '2-digit' };

export function formatTimeStamp(timeStamp: string): string {
  const date = new Date(timeStamp);
  return `${date.toLocaleDateString('en-US', dateOptions)} | ${date.toLocaleTimeString('en-US', timeOptions)}`;
}

export async function getMovieTitleArray() {
  const movieTitleArray: string[] = [] as string[];
  const response = await fetchMovies();
  const movieList = await response.json();

  movieList.forEach((movie: Movie) => {
    movieTitleArray.push(movie.title);
  });

  return movieTitleArray;
}

export async function getCinemaHallNameArray() {
  const cinemaHallNameArray: string[] = [] as string[];
  const response = await fetchCinemaHalls();
  const hallList = await response.json();

  hallList.forEach((hall: CinemaHall) => {
    cinemaHallNameArray.push(hall.name);
  });

  return cinemaHallNameArray;
}

export function getMovieByTitle(movieList: Movie[], movieTitle: string) {
  return movieList.find((movie: Movie) => movie.title === movieTitle);
}

export function getCinemaHallByName(hallList: CinemaHall[], hallName: string) {
  return hallList.find((hall: CinemaHall) => hall.name === hallName);
}

export function getVideoIdFromUrl(videoURL: string) {
  return videoURL.split('=')[1];
}