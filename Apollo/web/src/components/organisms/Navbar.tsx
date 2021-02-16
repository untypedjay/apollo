import React from 'react';
import {Link, useHistory} from 'react-router-dom';
import { useAuth0 } from '@auth0/auth0-react';
import Button from '../atoms/Button';
import Logo from '../../images/apollo-logo.png';
import './Navbar.css';

function Navbar() {
  const history = useHistory();
  const { isAuthenticated, loginWithRedirect } = useAuth0();

  return (
    <nav className="navbar">
      <Link to="/"><img className="navbar__logo" src={Logo} alt="Apollo"/></Link>
      <ul className="navbar__menu">
        <li><Link className="navbar__link" to="/shows">Shows</Link></li>
        <li><Link className="navbar__link" to="/today">Today</Link></li>
        <li><Link className="navbar__link" to="/search">Search</Link></li>
        { isAuthenticated ?
          <li><Button buttonType="link" onClick={() => history.push('/admin')}>Administrate</Button></li> :
          <li><Button buttonType="link" onClick={loginWithRedirect}>Login</Button></li>
        }
      </ul>
    </nav>
  );
}

export default Navbar;