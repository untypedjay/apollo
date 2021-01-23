const BASE_ENDPOINT = 'http://localhost:5000/api/movies';

export type Movie = {
  title: string,
  description: string,
  genre: string,
  length: number,
  actors: string,
  imageURL: string,
  trailerURL: string
}

export async function fetchMovies() {
  return await fetch(BASE_ENDPOINT, {
    method: 'GET',
    headers: { 'Content-Type': 'application/json' }
  });
}

export async function updateMovie(movie: Movie) {
  return await fetch(BASE_ENDPOINT, {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(movie)
  });
}

export async function insertMovie(movie: Movie) {
  return await fetch(BASE_ENDPOINT, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(movie)
  });
}

export async function deleteMovie(movie: Movie) {
  return await fetch(BASE_ENDPOINT, {
    method: 'DELETE',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(movie)
  });
}