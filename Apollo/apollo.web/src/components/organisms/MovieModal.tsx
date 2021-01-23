import React, { FormEvent, useState } from 'react';
import { Movie } from '../../services/movieService';
import Modal from '../templates/Modal';
import Input from '../atoms/Input';
import './MovieModal.css';

interface Props {
  title: string;
  closeModal: () => void;
}

function MovieModal({ title, closeModal }: Props) {
  const [movie, setMovie] = useState<Movie>({} as Movie);

  const handleInputChange = (event: FormEvent<HTMLInputElement>): void => {
    const eventTarget: any = event.target;
    const updatedMovie: Movie = movie;
    // @ts-ignore
    updatedMovie[eventTarget.name] = eventTarget.value;
    setMovie(updatedMovie);
  };

  const saveMovie = () => {
    alert('saved');
    closeModal();
  };

  return (
    <Modal title={title} closeAction={closeModal} secondaryAction={closeModal} primaryAction={saveMovie}>
      <div className="movie-modal__container">
        <Input value={movie.title} name="title" onChange={handleInputChange}>Title</Input>
        <Input value={movie.description} name="description" onChange={handleInputChange}>Description</Input>
        <Input value={movie.genre} name="genre" onChange={handleInputChange}>Genres</Input>
        <Input type="number" value={movie.length} name="length" onChange={handleInputChange}>Length</Input>
        <Input value={movie.actors} name="actors" onChange={handleInputChange}>Actors</Input>
        <Input value={movie.imageURL} name="imageURL" onChange={handleInputChange}>Wallpaper URL</Input>
        <Input value={movie.trailerURL} name="trailerURL" onChange={handleInputChange}>Trailer URL</Input>
      </div>
    </Modal>
  );
}

export default MovieModal;