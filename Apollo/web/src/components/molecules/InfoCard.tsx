import React from 'react';
import './InfoCard.css';

interface Props {
  children: number;
  description: string;
}

function InfoCard({ children, description }: Props) {
  return (
    <div className="info-card">
      <p className="info-card__data">{ children }</p>
      <p>{ description}</p>
    </div>
  );
}

export default InfoCard;