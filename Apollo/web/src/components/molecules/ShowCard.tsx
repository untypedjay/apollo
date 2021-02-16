import React, { useState } from 'react';
import { formatTimeStamp } from '../../helpers/converter';
import './ShowCard.css';
import ShowDetails from '../organisms/ShowDetails';

interface Props {
  show: any
};

function ShowCard({ show }: Props) {
  const [isModalOpen, setIsModalOpen] = useState(false);

  return (
    <>
      { isModalOpen && <ShowDetails show={show} close={() => setIsModalOpen(false)}/> }
      <button className="show-card" onClick={() => setIsModalOpen(true)}>
        <img className="show-card__image" src={show?.movie?.imageURL} alt={show?.movie?.title}/>
        <div className="show-card__info">
          <p className="show-card__details">{formatTimeStamp(show?.startsAt)}</p>
          <h3 className="show-card__title">{show?.movie?.title}</h3>
        </div>
      </button>
    </>
  );
}

export default ShowCard;