import React, { ReactNode } from 'react';
import { useHistory } from 'react-router-dom';
import { useAuth0 } from '@auth0/auth0-react';
import './MenuItem.css';

interface Props {
  selected: boolean;
  route: string;
  icon: ReactNode;
  shouldLogout?: boolean;
}

function MenuItem({ selected, route, icon, shouldLogout = false }: Props) {
  const { logout } = useAuth0();
  const history = useHistory();

  const calculateStyling = () => {
    if (selected) return 'menu-item menu-item--selected';
    return 'menu-item';
  };

  const renderDisplayName = () => {
    if (route.includes('admin/')) {
      return `${route.charAt(7).toUpperCase()}${route.substring(8, route.length)}`;
    } else if (shouldLogout) {
      return 'Logout';
    }
    return 'Overview';
  };

  const handleOnClick = () => {
    if (shouldLogout) {
      logout();
    }

    history.push(route);
  };

  return (
    <button className={calculateStyling()} onClick={handleOnClick}>
      { icon }
      <p className="menu-item__text">{ renderDisplayName() }</p>
    </button>
  );
}

export default MenuItem;