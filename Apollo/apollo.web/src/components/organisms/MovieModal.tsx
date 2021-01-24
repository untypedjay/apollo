import React, { FormEvent, useEffect, useState } from 'react';
import { useMovie } from '../../context/MovieContext';
import Modal from '../templates/Modal';
import Input from '../atoms/Input';
import { insertMovie, Movie } from '../../services/movieService';
import './MovieModal.css';

interface Props {
  closeModal: () => void;
}

function MovieModal({ closeModal }: Props) {
  const movieToEdit = useMovie();
  const [movie, setMovie] = useState<Movie>({} as Movie);
  const [title, setTitle] = useState('');

  useEffect(() => {
    if (movieToEdit.title) {
      setTitle('Edit Movie');
      setMovie(movieToEdit);
    } else {
      setTitle('New Movie');
    }
  }, [movieToEdit])

  const handleInputChange = (event: FormEvent<HTMLInputElement>): void => {
    const eventTarget: any = event.target;
    const updatedMovie: Movie = movie;
    // @ts-ignore
    updatedMovie[eventTarget.name] = eventTarget.value;
    setMovie(updatedMovie);
  };

  const saveMovie = async () => {
    if (!movie.title || movie.title.replace(/ /g, '').length === 0) {
      alert('Please fill out a movie title!');
      return;
    }

    if (!movie.length || movie.length < 1 || movie.length > 500) {
      alert('Please enter a valid movie length!');
      return;
    }

    const newMovie: Movie = {
      title: movie.title,
      description: movie.description || '',
      genre: movie.genre || '',
      length: movie.length,
      actors: movie.actors || '',
      imageURL: movie.imageURL || '',
      trailerURL: movie.trailerURL || ''
    };

    const response = await insertMovie(newMovie);
    if (response.status === 201) {
      closeModal();
    } else if (response.status === 409) {
      alert(`ERROR: A movie with the title "${newMovie.title}" already exists!`)
    } else {
      alert(`ERROR: Could not add movie (${response.status})`);
      console.log(response);
    }
  };

  return (
    <Modal title={title} closeAction={closeModal} secondaryAction={closeModal} primaryAction={saveMovie}>
      <div className="movie-modal__container movie-modal__container--vertical">
        <Input value={movie.title} name="title" onChange={handleInputChange} required={true}>Title</Input>
        <Input value={movie.description} name="description" onChange={handleInputChange} required={true}>
          Description
        </Input>
        <div className="movie-modal__container movie-modal__container--horizontal">
          <Input value={movie.genre} name="genre" onChange={handleInputChange} required={true}>Genres</Input>
          <Input type="number" value={movie.length} name="length" onChange={handleInputChange} required={true}>
            Length
          </Input>
        </div>
        <Input value={movie.actors} name="actors" onChange={handleInputChange} required={true}>Actors</Input>
        <Input value={movie.imageURL} name="imageURL" onChange={handleInputChange} required={true}>
          Wallpaper URL
        </Input>
        <Input value={movie.trailerURL} name="trailerURL" onChange={handleInputChange} required={true}>
          Trailer URL
        </Input>
      </div>
    </Modal>
  );
}

export default MovieModal;