import React from 'react';
import { Link } from 'react-router-dom';
import { FaHome, FaChair, FaFilm, FaCalendarAlt, FaSignOutAlt } from 'react-icons/fa';
import MenuItem from '../molecules/MenuItem';
import Logo from '../../images/apollo-logo.png';
import './Menu.css';

interface Props {
  selected: string;
}

function Menu({ selected }: Props) {
  const iconSize = '25px';

  return (
    <div className="menu">
      <Link to="/"><img className="menu__logo" src={Logo} alt="Apollo Logo"/></Link>

      <MenuItem
        selected={selected === '/admin'}
        route="/admin"
        icon={<FaHome className="menu__icon" size={iconSize}/>}
      />

      <MenuItem
        selected={selected === '/admin/shows'}
        route="/admin/shows"
        icon={<FaCalendarAlt className="menu__icon" size={iconSize}/>}
      />

      <MenuItem
        selected={selected === '/admin/movies'}
        route="/admin/movies"
        icon={<FaFilm className="menu__icon" size={iconSize}/>}
      />

      <MenuItem
        selected={selected === '/admin/halls'}
        route="/admin/halls"
        icon={<FaChair className="menu__icon" size={iconSize}/>}
      />

      <MenuItem
        selected={selected === '/'}
        route="/"
        icon={<FaSignOutAlt className="menu__icon" size={iconSize}/>}
        shouldLogout={true}
      />
    </div>
  );
}

export default Menu;