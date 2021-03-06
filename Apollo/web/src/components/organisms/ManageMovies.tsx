import React, { FormEvent, useEffect, useState } from 'react';
import List from './List';
import Button from '../atoms/Button';
import MovieModal from './MovieModal';
import { Movie, fetchMovies, deleteMovie } from '../../services/movieService';
import './ManageMovies.css';
import Empty from '../molecules/Empty';
import ShowList from './ShowList';

function ManageMovies() {
  const [movies, setMovies] = useState<Movie[]>([] as Movie[]);
  const [currentMovie, setCurrentMovie] = useState<Movie>({} as Movie);
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

  const renderContent = () => {
    if (!isLoading && movies.length === 0) {
      return <Empty/>;
    } else {
      return (
        <List
          title="Movies"
          data={movies}
          property="title"
          editAction={editMovie}
          deleteAction={removeMovie}
          extraProperty="genre"
        />
      );
    }
  };

  const handleInputChange = (event: FormEvent<HTMLInputElement>): void => {
    const eventTarget: any = event.target;
    const updatedMovie: Movie = JSON.parse(JSON.stringify(currentMovie));
    // @ts-ignore
    updatedMovie[eventTarget.name] = eventTarget.value;
    setCurrentMovie(updatedMovie);
  };

  const editMovie = (movieTitle: string): void => {
    const movie = getMovieByTitle(movieTitle);
    if (movie) setCurrentMovie(movie);
    setIsModalOpen(true);
  };

  const removeMovie = async (movieTitle: string) => {
    const toDelete = window.confirm(`Do you really want to delete "${movieTitle}"?`);
    const movie = getMovieByTitle(movieTitle);
    if (toDelete && movie) {
      const response = await deleteMovie(movie);
      if (response.status === 204) {
        setIsLoading(true);
      } else if (response.status === 403) {
        alert(`ERROR: Could not delete movie because there are existing shows depending on that movie!`);
      } else {
        alert(`ERROR: Could not delete movie (${response.status})`);
        console.log(response);
      }
    }
  };

  const openNewMovieModal = () => {
    setCurrentMovie({} as Movie);
    setIsModalOpen(true);
  }

  const getMovieByTitle = (movieTitle: string) => {
    return movies.find(movie => movie.title === movieTitle);
  };

  return (
    <div className="manage-movies">
      { isModalOpen &&
        <MovieModal closeModal={() => setIsModalOpen(false)} movie={currentMovie} onChange={handleInputChange}/>
      }
      <Button onClick={openNewMovieModal}>New Movie</Button>
      { renderContent() }
    </div>
  );
}

export default ManageMovies;