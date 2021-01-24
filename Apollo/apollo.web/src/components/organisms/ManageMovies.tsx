import React, { useEffect, useState } from 'react';
import {Movie, fetchMovies, deleteMovie} from '../../services/movieService';
import List from './List';
import Button from '../atoms/Button';
import './ManageMovies.css';
import MovieModal from './MovieModal';

function ManageMovies() {
  const [movies, setMovies] = useState<Movie[]>([] as Movie[]);
  const [isLoading, setIsLoading] = useState(true);
  const [isModalOpen, setIsModalOpen] = useState(false);

  useEffect(() => {
    getMovies();
  }, [isLoading]);

  useEffect(() => {
    setIsLoading(true);
  }, [isModalOpen]);

  const getMovies = async () => {
    const response = await fetchMovies();
    setMovies(await response.json());
    if (response.status === 200) {
      setIsLoading(false);
    } else {
      alert(`ERROR: Could not load movies (${response.status})`);
      console.log(response);
    }
  };

  const editMovie = (movieTitle: string): void => {
    alert('Edit Movie');
  };

  const removeMovie = async (movieTitle: string) => {
    const toDelete = window.confirm(`Do you really want to delete "${movieTitle}"?`);
    const movie = getMovieByTitle(movieTitle);
    if (toDelete && movie) {
      const response = await deleteMovie(movie);
      if (response.status === 204) {
        setIsLoading(true);
      } else {
        alert(`ERROR: Could not delete movie (${response.status})`);
        console.log(response);
      }
    }
  };

  const getMovieByTitle = (movieTitle: string) => {
    return movies.find(movie => movie.title === movieTitle);
  };

  return (
    <div className="manage-movies">
      { isModalOpen && <MovieModal closeModal={() => setIsModalOpen(false)}/> }
      <Button onClick={() => setIsModalOpen(true)}>New Movie</Button>
      <List title="Movies" data={movies} property="title" editAction={editMovie} deleteAction={removeMovie}/>
    </div>
  );
}

export default ManageMovies;