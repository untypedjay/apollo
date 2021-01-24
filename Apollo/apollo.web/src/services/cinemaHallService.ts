const BASE_ENDPOINT = 'http://localhost:5000/api/cinemahalls';

export type CinemaHall = {
  name: string,
  rowAmount: number,
  seatAmount: number
}

export async function fetchCinemaHalls() {
  return await fetch(BASE_ENDPOINT, {
    method: 'GET',
    headers: { 'Content-Type': 'application/json' }
  });
}

export async function updateCinemaHall(cinemaHall: CinemaHall) {
  return await fetch(BASE_ENDPOINT, {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(cinemaHall)
  });
}

export async function insertCinemaHall(cinemaHall: CinemaHall) {
  return await fetch(BASE_ENDPOINT, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(cinemaHall)
  });
}

export async function deleteCinemaHall(cinemaHall: CinemaHall) {
  return await fetch(BASE_ENDPOINT, {
    method: 'DELETE',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(cinemaHall)
  });
}