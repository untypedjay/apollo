import React from 'react';
import ListItem from '../molecules/ListItem';
import { Show } from '../../services/showService';
import './List.css';
import {formatTimeStamp} from '../../helpers/converter';

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
              extraInfo={`${formatTimeStamp(show.startsAt)} | ${show.cinemaHall?.name}`}
              show={show}
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