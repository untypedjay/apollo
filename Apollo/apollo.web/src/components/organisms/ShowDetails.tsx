import React from 'react';
import {Show} from '../../services/showService';
import Modal from '../templates/Modal';
import './ShowDetails.css';
import {formatTimeStamp} from '../../helpers/converter';

interface Props {
  show: Show;
  close: () => void;
}

function ShowDetails({ show, close }: Props) {
  const videoId = 'mP0VHJYFOAU';
  return (
    <Modal closeAction={close} fullscreen>
      <div className="show-details__container">
        <iframe
          className="show-details__video"
          src={`https://www.youtube.com/embed/${videoId}?rel=0&mute=1&amp;autoplay=1`}
          frameBorder="0"
          allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
          allowFullScreen
        />
        <div>
          <div>
            <p>{ `${formatTimeStamp(show.startsAt)} | ${show.cinemaHall.name} | ${show.movie.length} Minutes` }</p>
            <h3>{ show.movie.title }</h3>
            <p>{ show.movie.description }</p>
          </div>
          <div>
            <p><span>Cast: </span><span>{ show.movie.actors }</span></p>
            <p><span>Genres: </span><span>{ show.movie.genre }</span></p>
          </div>
        </div>

      </div>

    </Modal>
  );
}

export default ShowDetails;