import React, { FormEvent, useEffect, useState } from 'react';
import Modal from '../templates/Modal';
import Input from '../atoms/Input';
import { CinemaHall, insertCinemaHall, updateCinemaHall } from '../../services/cinemaHallService';
import './HallModal.css';

interface Props {
  closeModal: () => void;
  hall: CinemaHall;
  onChange: (event: FormEvent<HTMLInputElement>) => void;
}

function HallModal({ closeModal, hall, onChange }: Props) {
  const [title, setTitle] = useState('Edit Cinema Hall');

  useEffect(() => {
    if (!hall.name) {
      setTitle('New Cinema Hall');
    }
  }, [hall.name])

  const addHall = async () => {
    if (!hall.name || hall.name.replace(/ /g, '').length === 0) {
      alert('Please fill out a hall name!');
      return;
    }

    const response = await insertCinemaHall(hall);
    if (response.status === 201) {
      closeModal();
    } else if (response.status === 409) {
      alert(`ERROR: A cinema hall with the name "${hall.name}" already exists!`);
    } else {
      alert(`ERROR: Could not add cinema hall (${response.status})`);
      console.log(response);
    }
  };

  const saveHall = async () => {
    const response = await updateCinemaHall(hall);
    if (response.status === 204) {
      closeModal();
    } else if (response.status === 409) {
      alert(`ERROR: A cinema hall with the title "${hall.name}" already exists!`);
    } else if (response.status === 403) {
      alert('ERROR: Could not update cinema hall because there are shows relying on that data!');
    } else {
      alert(`ERROR: Could not update cinema hall (${response.status})`);
      console.log(response);
    }
  };

  return (
    <Modal
      title={title}
      closeAction={closeModal}
      secondaryAction={closeModal}
      primaryAction={title === 'Edit Cinema Hall' ? saveHall : addHall}
    >
      <div className="hall-modal__container">
        <Input value={hall.name} name="name" onChange={title === 'New Cinema Hall' ? onChange : () => {}} required={true}>Name</Input>
        <Input type="number" value={hall.rowAmount} name="rowAmount" onChange={onChange} required={true}>
          Number of Rows
        </Input>
        <Input type="number" value={hall.seatAmount} name="seatAmount" onChange={onChange} required={true}>
          Number of Seats
        </Input>
      </div>
    </Modal>
  );
}

export default HallModal;