import { Movie } from './movieService';
import { CinemaHall } from './cinemaHallService';

const BASE_ENDPOINT = 'http://localhost:5000/api/shows';

export type Show = {
  startsAt: string,
  movie: Movie,
  cinemaHall: CinemaHall
}

export async function fetchShows() {
  return await fetch(BASE_ENDPOINT, {
    method: 'GET',
    headers: { 'Content-Type': 'application/json' }
  });
}

export async function getShowCapacity(show: Show) {
  const endpoint = `${BASE_ENDPOINT}/capacity`;
  return await fetch(endpoint, {
    method: 'GET',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(show)
  });
}

export async function insertShow(show: Show) {
  return await fetch(BASE_ENDPOINT, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(show)
  });
}

export async function deleteShow(show: Show) {
  return await fetch(BASE_ENDPOINT, {
    method: 'DELETE',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(show)
  });
}