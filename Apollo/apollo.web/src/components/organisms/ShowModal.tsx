import React, { FormEvent, useEffect, useState } from 'react';
import Modal from '../templates/Modal';
import Input from '../atoms/Input';
import { insertShow, Show } from '../../services/showService';
import {
  getCinemaHallByName,
  getCinemaHallNameArray,
  getMovieByTitle,
  getMovieTitleArray
} from '../../helpers/converter';
import './ShowModal.css';
import {fetchMovies, Movie} from '../../services/movieService';
import {CinemaHall, fetchCinemaHalls} from '../../services/cinemaHallService';

interface Props {
  closeModal: () => void;
}

function ShowModal({ closeModal }: Props) {
  const [show, setShow] = useState({} as Show);
  const [movies, setMovies] = useState<Movie[]>([] as Movie[]);
  const [halls, setHalls] = useState<CinemaHall[]>([] as CinemaHall[]);
  const title = 'New Show';
  const [movieArray, setMovieArray] = useState<string[]>([]);
  const [hallArray, setHallArray] = useState<string[]>([]);

  useEffect(() => {
    getData();
  }, []);

  const getData = async () => {
    const movieResponse = await fetchMovies();
    const hallResponse = await fetchCinemaHalls();
    setMovies(await movieResponse.json());
    setHalls(await hallResponse.json());
    const movieData = await getMovieTitleArray();
    const hallData = await getCinemaHallNameArray();
    setMovieArray(movieData);
    setHallArray(hallData);
  };

  const handleInputChange = (event: FormEvent<HTMLInputElement | HTMLSelectElement>): void => {
    const eventTarget: any = event.target;
    const updatedShow: Show = JSON.parse(JSON.stringify(show));
    if (eventTarget.name === 'movie') {
      const movie = getMovieByTitle(movies, eventTarget.value);
      if (movie) updatedShow.movie = movie;
    } else if (eventTarget.name === 'cinemaHall') {
      const hall = getCinemaHallByName(halls, eventTarget.value);
      if (hall) updatedShow.cinemaHall = hall;
    } else {
      // @ts-ignore
      updatedShow[eventTarget.name] = eventTarget.value;
    }

    setShow(updatedShow);
  };

  const addMovie = async () => {
    if (!show.startsAt || !show.movie || !show.cinemaHall) {
      alert('Please fill out all values!');
      return;
    }

    const response = await insertShow(show);
    if (response.status === 201) {
      closeModal();
    } else if (response.status === 409) {
      alert(`ERROR: This show already exists!`);
    } else {
      alert(`ERROR: Could not add show (${response.status})`);
      console.log(response);
    }
  };

  return (
    <Modal
      title={title}
      closeAction={closeModal}
      secondaryAction={closeModal}
      primaryAction={addMovie}
    >
      <div className="show-modal__container">
        <Input type="datetime-local" name="startsAt" onChange={handleInputChange}>Start Time</Input>
        <Input type="select" name="movie" onChange={handleInputChange} optionList={movieArray}>Movie</Input>
        <Input type="select" name="cinemaHall" onChange={handleInputChange} optionList={hallArray}>Cinema Hall</Input>
      </div>
    </Modal>
  );
}

export default ShowModal;