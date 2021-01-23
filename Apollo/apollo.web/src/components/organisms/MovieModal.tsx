import React, { FormEvent, useState } from 'react';
import { Movie } from '../../services/movieService';
import Modal from '../templates/Modal';
import Input from '../atoms/Input';

interface Props {
  closeModal: () => void;
}

function MovieModal({ closeModal }: Props) {
  const [movie, setMovie] = useState<Movie | {}>({});

  const handleInputChange = (event: FormEvent<HTMLInputElement>): void => {
    const eventTarget: any = event.target;
    const updatedMovie: Movie | {} = movie;
    // @ts-ignore
    updatedMovie[eventTarget.name] = eventTarget.value;
    setMovie(updatedMovie);
  };

  const saveMovie = () => {
    alert('saved');
    closeModal();
  };

  return (
    <Modal closeAction={closeModal} secondaryAction={closeModal} primaryAction={saveMovie}>
      <>
        <Input value={movie.title} name="title" onChange={handleInputChange}>Title</Input>
        <Input value={movie.description} name="description" onChange={handleInputChange}>Description</Input>
        <Input value={movie.genre} name="genre" onChange={handleInputChange}>Genres</Input>
        <Input type="number" value={movie.length} name="length" onChange={handleInputChange}>Length</Input>
        <Input value={movie.actors} name="actors" onChange={handleInputChange}>Actors</Input>
        <Input value={movie.imageURL} name="imageURL" onChange={handleInputChange}>Wallpaper URL</Input>
        <Input value={movie.trailerURL} name="trailerURL" onChange={handleInputChange}>Trailer URL</Input>
      </>
    </Modal>
  );
}

export default MovieModal;