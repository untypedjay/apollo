import React from 'react';
import './Footer.css';

function Footer() {
  return (
    <div className="footer">
      <p>&#169; 2020-{ new Date().getFullYear() } Apollo Entertainment Inc.</p>
    </div>
  );
}

export default Footer;