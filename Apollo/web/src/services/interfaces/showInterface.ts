import { Movie } from '../movieService';
import { CinemaHall } from '../cinemaHallService';

interface ShowInterface {
  fetchShows: () => Show[];
  getShowCapacity: (show: Show) => number;
  insertShow: (show: Show) => boolean;
  deleteShow: (show: Show) => boolean;
}

export type Show = {
  startsAt: string,
  movie: Movie,
  cinemaHall: CinemaHall
}