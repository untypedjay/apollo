import React from 'react';
import ListItem from '../molecules/ListItem';
import { Show } from '../../services/showService';
import './List.css';

interface Props {
  shows: Show[];
  deleteAction: (item: any) => void;
}

function ShowList({ shows, deleteAction }: Props) {

  return (
    <div className="list">
      <h3 className="list__title">Shows</h3>
      <div className="list__container">
        { shows.map(show => {
          return (
            <ListItem
              key={`${show.movie?.title}${show.cinemaHall?.name}${show.startsAt}`}
              deleteAction={deleteAction}
              extraInfo={`${show.startsAt} | ${show.cinemaHall?.name}`}
            >
              { show.movie?.title }
            </ListItem>
          );
        })}
      </div>
    </div>
  );
}

export default ShowList;