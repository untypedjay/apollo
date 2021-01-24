import React, { FormEvent, useEffect, useState } from 'react';
import Modal from '../templates/Modal';
import Input from '../atoms/Input';
import { insertMovie, Movie } from '../../services/movieService';
import './MovieModal.css';

interface Props {
  closeModal: () => void;
  movie: Movie;
  onChange: (event: FormEvent<HTMLInputElement>) => void;
}

function MovieModal({ closeModal, movie, onChange }: Props) {
  const [title, setTitle] = useState('Edit Movie');

  useEffect(() => {
    if (!movie.title) {
      setTitle('New Movie');
    }
  }, [])

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

  const updateMovie = () => {
    alert('Updta')
  };

  return (
    <Modal
      title={title}
      closeAction={closeModal}
      secondaryAction={closeModal}
      primaryAction={title === 'Edit Movie' ? updateMovie : saveMovie}
    >
      <div className="movie-modal__container movie-modal__container--vertical">
        <Input value={movie.title} name="title" onChange={onChange} required={true}>Title</Input>
        <Input value={movie.description} name="description" onChange={onChange} required={true}>
          Description
        </Input>
        <div className="movie-modal__container movie-modal__container--horizontal">
          <Input value={movie.genre} name="genre" onChange={onChange} required={true}>Genres</Input>
          <Input type="number" value={movie.length} name="length" onChange={onChange} required={true}>
            Length
          </Input>
        </div>
        <Input value={movie.actors} name="actors" onChange={onChange} required={true}>Actors</Input>
        <Input value={movie.imageURL} name="imageURL" onChange={onChange} required={true}>
          Wallpaper URL
        </Input>
        <Input value={movie.trailerURL} name="trailerURL" onChange={onChange} required={true}>
          Trailer URL
        </Input>
      </div>
    </Modal>
  );
}

export default MovieModal;