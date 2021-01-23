import React from 'react';
import './ShowCard.css';

interface Props {
  show: any
};

function ShowCard({ show }: Props) {
  return (
    <button className="show-card">
      <img className="show-card__image" src={show.movie?.imageURL} alt={show.movie?.title}/>
      <p className="show-card__details">{show.startsAt}</p>
      <h3 className="show-card__title">{show.movie?.title}</h3>
    </button>
  );
}

export default ShowCard;