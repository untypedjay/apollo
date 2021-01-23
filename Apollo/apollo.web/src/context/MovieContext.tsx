import React, { useContext, useState, ReactNode } from 'react';
import { Movie } from '../services/movieService';

type Props = {
  children: ReactNode
};

type MovieUpdate = (newMovie: Movie) => void;

const MovieContext = React.createContext<Movie>({} as Movie);
const MovieUpdateContext = React.createContext<MovieUpdate | null>(null);

export function useMovie() {
  return useContext(MovieContext);
};

export function useMovieUpdate() {
  return useContext(MovieUpdateContext);
};

export function MovieProvider({ children }: Props) {
  const [movie, setMovie] = useState<Movie>({} as Movie);

  const updateMovie = (newMovie: Movie) => {
    setMovie(newMovie);
  };

  return (
    <MovieContext.Provider value={movie}>
      <MovieUpdateContext.Provider value={updateMovie}>
        { children }
      </MovieUpdateContext.Provider>
    </MovieContext.Provider>
  );
}