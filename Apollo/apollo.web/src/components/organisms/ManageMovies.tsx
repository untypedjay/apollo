import React, {useEffect, useState} from 'react';
import { fetchMovies } from '../../services/movieService';

function ManageMovies() {
  const [movies, setMovies] = useState([]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    getMovies();
  }, []);

  const getMovies = async () => {
    const response = await fetchMovies();
    console.log(response);
    setMovies(await response.json());
    //setIsLoading(false);
  }

  return (
    <div className="manage-movies">
      Movies
    </div>
  );
}

export default ManageMovies;