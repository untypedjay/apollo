import React, { FormEvent, useEffect, useState } from 'react';
import Modal from '../templates/Modal';
import Input from '../atoms/Input';
import { insertShow, Show } from '../../services/showService';
import './ShowModal.css';
import {getCinemaHallNameArray, getMovieTitleArray} from '../../helpers/converter';

interface Props {
  closeModal: () => void;
}

function ShowModal({ closeModal }: Props) {
  const [show, setShow] = useState({} as Show);
  const title = 'New Show';
  const movieArray = getMovieTitleArray();
  const hallArray = getCinemaHallNameArray();

  const handleInputChange = (event: FormEvent<HTMLInputElement>): void => {
    const eventTarget: any = event.target;
    const updatedShow: Show = JSON.parse(JSON.stringify(show));
    // @ts-ignore
    updatedShow[eventTarget.name] = eventTarget.value;
    setShow(updatedShow);
  };

  const addMovie = async () => {
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
        <Input type="datetime-local" name="timeStamp" onChange={handleInputChange}>Start Time</Input>
        <Input type="select" name="movie" onChange={handleInputChange} optionList={movieArray}>Movie</Input>
        <Input type="select" name="cinemaHall" onChange={handleInputChange} optionList={hallArray}>Cinema Hall</Input>
      </div>
    </Modal>
  );
}

export default ShowModal;