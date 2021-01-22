import React from 'react';
import './Footer.css';

function Footer() {
  return (
    <div className="footer">
      <p>&#169; Apollo Entertainment, { new Date().getFullYear() }</p>
    </div>
  );
}

export default Footer;