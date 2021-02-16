import React from 'react';
import { FaKiwiBird } from 'react-icons/fa';
import './Empty.css';

function Empty() {
  const iconSize = '100px';
  return (
    <div className="empty">
      <FaKiwiBird size={iconSize}/>
      <p className="empty__text">Nothing to see here...</p>
    </div>
  );
}

export default Empty;