import React from 'react';
import { Link } from 'react-router-dom';
import Logo from '../../images/apollo-logo.png';
import './Navbar.css';

function Navbar() {
  return (
    <nav className="navbar">
      <Link to="/"><img className="navbar__logo" src={Logo} alt="Apollo"/></Link>
      <ul className="navbar__menu">
        <li><Link className="navbar__link" to="/shows">Shows</Link></li>
        <li><Link className="navbar__link" to="/today">Today</Link></li>
        <li><Link className="navbar__link" to="/search">Search</Link></li>
        <li><Link className="navbar__link" to="/login">Login</Link></li>
      </ul>
    </nav>
  );
}

export default Navbar;