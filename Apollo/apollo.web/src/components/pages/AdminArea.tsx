import React, { useEffect } from 'react';
import { useLocation, useHistory } from 'react-router-dom';
import { useAuth0 } from '@auth0/auth0-react';
import AdminContent from '../organisms/AdminContent';
import Menu from '../organisms/Menu';
import './AdminArea.css';

function AdminArea() {
  const { isLoading, isAuthenticated } = useAuth0();
  const location = useLocation();
  const history = useHistory();

  useEffect(() => {
    if(!isLoading && !isAuthenticated) {
      history.push('/');
    }
  }, [isLoading, isAuthenticated]);

  return (
    <div className="admin-area">
      <Menu selected={location.pathname}/>
      <AdminContent section={location.pathname}/>
    </div>
  );
}

export default AdminArea;