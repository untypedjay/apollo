import React, { useEffect, useState } from 'react';
import ShowList from './ShowList';
import Button from '../atoms/Button';
import { deleteShow, fetchShows, Show } from '../../services/showService';
import ShowModal from './ShowModal';
import './ManageShows.css';

function ManageShows() {
  const [shows, setShows] = useState<Show[]>([] as Show[]);
  const [isLoading, setIsLoading] = useState(true);
  const [isModalOpen, setIsModalOpen] = useState(false);

  useEffect(() => {
    getShows();
  }, [isLoading]);

  useEffect(() => {
    setIsLoading(true);
  }, [isModalOpen]);

  const getShows = async () => {
    const response = await fetchShows();
    setShows(await response.json());
    if (response.status === 200) {
      setIsLoading(false);
    } else {
      alert(`ERROR: Could not load shows (${response.status})`);
      console.log(response);
    }
  };

  const removeShow = async (show: Show) => {
    const toDelete = window.confirm(`Do you really want to delete this show?`);
    if (toDelete && show) {
      const response = await deleteShow(show);
      if (response.status === 204) {
        setIsLoading(true);
      } else if (response.status === 403) {
        alert('ERROR: Could not delete because there are reservations for this show!');
      } else {
        alert(`ERROR: Could not delete show (${response.status})`);
        console.log(response);
      }
    }
  };

  return (
    <div className="manage-shows">
      { isModalOpen &&
      <ShowModal closeModal={() => setIsModalOpen(false)}/>
      }
      <Button onClick={() => setIsModalOpen(true)}>New Show</Button>
      <ShowList
        shows={shows}
        deleteAction={removeShow}
      />
    </div>
  );
}

export default ManageShows;