import React from 'react';
import { useLocation } from 'react-router-dom';
import AdminContent from '../organisms/AdminContent';
import Menu from '../organisms/Menu';
import './AdminArea.css';

function AdminArea() {
  const location = useLocation();

  return (
    <div className="admin-area">
      <Menu selected={location.pathname}/>
      <AdminContent section={location.pathname}/>
    </div>
  );
}

export default AdminArea;