import React, { FormEvent, useEffect, useState } from 'react';
import List from './List';
import Button from '../atoms/Button';
import { CinemaHall, deleteCinemaHall, fetchCinemaHalls } from '../../services/cinemaHallService';
import './ManageHalls.css';

function ManageHalls() {
  const [halls, setHalls] = useState<CinemaHall[]>([] as CinemaHall[]);
  const [currentHall, setCurrentHall] = useState<CinemaHall>({} as CinemaHall);
  const [isLoading, setIsLoading] = useState(true);
  const [isModalOpen, setIsModalOpen] = useState(false);

  useEffect(() => {
    getHalls();
  }, [isLoading]);

  useEffect(() => {
    setIsLoading(true);
  }, [isModalOpen]);

  const getHalls = async () => {
    const response = await fetchCinemaHalls();
    setHalls(await response.json());
    if (response.status === 200) {
      setIsLoading(false);
    } else {
      alert(`ERROR: Could not load cinema halls (${response.status})`);
      console.log(response);
    }
  };

  const handleInputChange = (event: FormEvent<HTMLInputElement>): void => {
    const eventTarget: any = event.target;
    const updatedHall: CinemaHall = JSON.parse(JSON.stringify(currentHall));
    // @ts-ignore
    updatedHall[eventTarget.name] = eventTarget.value;
    setCurrentHall(updatedHall);
  };

  const editHall = (hallName: string): void => {
    const hall = getHallByName(hallName);
    if (hall) setCurrentHall(hall);
    setIsModalOpen(true);
  };

  const removeHall = async (hallName: string) => {
    const toDelete = window.confirm(`Do you really want to delete "${hallName}"?`);
    const hall = getHallByName(hallName);
    if (toDelete && hall) {
      const response = await deleteCinemaHall(hall);
      if (response.status === 204) {
        setIsLoading(true);
      } else if (response.status === 403) {
        alert(`ERROR: Could not delete cinema hall because there are existing shows playing in that hall!`);
      } else {
        alert(`ERROR: Could not delete cinema hall (${response.status})`);
        console.log(response);
      }
    }
  };

  const openNewHallModal = () => {
    setCurrentHall({} as CinemaHall);
    setIsModalOpen(true);
  }

  const getHallByName = (hallName: string) => {
    return halls.find(hall => hall.name === hallName);
  };

  return (
    <div className="manage-halls">
      { isModalOpen &&
      <HallModal closeModal={() => setIsModalOpen(false)} hall={currentHall} onChange={handleInputChange}/>
      }
      <Button onClick={openNewHallModal}>New Cinema Hall</Button>
      <List title="Cinema Halls" data={halls} property="name" editAction={editHall} deleteAction={removeHall}/>
    </div>
  );
}

export default ManageHalls;