import React, {useEffect, useState} from 'react';
import { Movie, fetchMovies } from '../../services/movieService';
import List from './List';

function ManageMovies() {
  const [movies, setMovies] = useState([]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    getMovies();
  }, []);

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

  const editMovie = (movie: Movie) => {
    alert('Edit Movie');
  };

  const removeMovie = (movie: Movie) => {
    const toDelete = window.confirm(`Do you really want to delete "${movie.title}"?`);
    if (toDelete) {
      alert('Delete Movie');
    }
  };

  return (
    <div className="manage-movies">
      <List title="Movies" data={movies} property="title" editAction={editMovie} deleteAction={removeMovie}/>
    </div>
  );
}

export default ManageMovies;