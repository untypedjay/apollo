import React, { useState, useEffect } from 'react';
import InfoCard from '../molecules/InfoCard';
import './AdminOverview.css';
import {fetchMovies} from '../../services/movieService';
import {fetchShows} from '../../services/showService';
import {fetchCinemaHalls} from '../../services/cinemaHallService';
import {fetchSeatCategories} from '../../services/seatCategoryService';

function AdminOverview() {
  const [showNumber, setShowNumber] = useState(0);
  const [movieNumber, setMovieNumber] = useState(0);
  const [hallNumber, setHallNumber] = useState(0);
  const [seatCategoryNumber, setSeatCategoryNumber] = useState(0);

  useEffect(() => {
    fetchData();
  }, []);

  const fetchData = async () => {
    const showResponse = await fetchShows();
    const shows = await showResponse.json();
    setShowNumber(shows.length);

    const movieResponse = await fetchMovies();
    const movies = await movieResponse.json();
    setMovieNumber(movies.length);

    const hallResponse = await fetchCinemaHalls();
    const halls = await hallResponse.json();
    setHallNumber(halls.length);

    const seatCategoryResponse = await fetchSeatCategories();
    const seatCategories = await seatCategoryResponse.json();
    setSeatCategoryNumber(seatCategories.length);
  };

  return (
    <div className="admin-overview">
      <InfoCard description="Number of Shows">{ showNumber }</InfoCard>
      <InfoCard description="Number of Movies">{ movieNumber }</InfoCard>
      <InfoCard description="Number of Cinema Halls">{ hallNumber }</InfoCard>
      <InfoCard description="Number of Seat Categories">{ seatCategoryNumber }</InfoCard>
    </div>
  );
}

export default AdminOverview;