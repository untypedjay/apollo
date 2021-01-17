import React from 'react';
import ShowCard from '../molecules/ShowCard';

interface Props {
  title?: string,
  shows: any[]
};

function ShowContainer({ title, shows }: Props) {
  return (
    <div className="show-container">
      { title && <h3 className="show-container__title">{title}</h3> }
      { shows.map(show => <ShowCard show={show}/>) }
    </div>
  );
}

export default ShowContainer;