const BASE_ENDPOINT = 'http://localhost:5000/api/seatcategories';

export type SeatCategory = {
  name: string,
  price: number
}

export async function fetchSeatCategories() {
  return await fetch(BASE_ENDPOINT, {
    method: 'GET',
    headers: { 'Content-Type': 'application/json' }
  });
}

export async function updateSeatCategory(seatCategory: SeatCategory) {
  return await fetch(BASE_ENDPOINT, {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(seatCategory)
  });
}

export async function insertSeatCategory(seatCategory: SeatCategory) {
  return await fetch(BASE_ENDPOINT, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(seatCategory)
  });
}

export async function deleteSeatCategory(seatCategory: SeatCategory) {
  return await fetch(BASE_ENDPOINT, {
    method: 'DELETE',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(seatCategory)
  });
}