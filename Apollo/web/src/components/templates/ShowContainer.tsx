import React from 'react';
import ShowCard from '../molecules/ShowCard';
import './ShowContainer.css';

interface Props {
  title?: string,
  shows: any[]
};

function ShowContainer({ title, shows }: Props) {
  return (
    <div className="show-container">
      { title && <h3 className="show-container__title">{title}</h3> }
      <div className="show-container__grid">
        {
          shows.map(show => {
            return (
              <ShowCard key={`${show.movie?.title}${show.cinemaHall?.name}${show.startsAt}`} show={show}/>
            );
          })
        }
      </div>

    </div>
  );
}

export default ShowContainer;