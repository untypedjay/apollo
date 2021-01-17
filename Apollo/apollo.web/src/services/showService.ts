const BASE_ENDPOINT = 'http://localhost:5000/api/shows';

export async function fetchShows() {
  return await fetch(BASE_ENDPOINT, {
    method: 'GET',
    headers: { 'Content-Type': 'application/json' }
  });
}