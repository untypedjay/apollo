import React, { useState } from 'react';
import {Show} from '../../services/showService';
import Modal from '../templates/Modal';
import {formatTimeStamp, getVideoIdFromUrl} from '../../helpers/converter';
import './ShowDetails.css';

interface Props {
  show: Show;
  close: () => void;
}

function ShowDetails({ show, close }: Props) {
  const videoId = getVideoIdFromUrl(show.movie.trailerURL);
  const [availableSeats, setAvailableSeats] = useState(0);
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
        <p>{ `${formatTimeStamp(show.startsAt)} | ${show.cinemaHall.name} | ${show.movie.length} Minutes` }</p>
        <div className="show-details__information">
          <div className="show-details__divider">
            <h3>{ show.movie.title }</h3>
            <p>{ show.movie.description }</p>
          </div>
          <div>
            <p><span className="show-details__text--grey">Cast: </span><span>{ show.movie.actors }</span></p>
            <p><span className="show-details__text--grey">Genres: </span><span>{ show.movie.genre }</span></p>
          </div>
        </div>
        <p>There are { availableSeats } seats available for this show.</p>
      </div>

    </Modal>
  );
}

export default ShowDetails;