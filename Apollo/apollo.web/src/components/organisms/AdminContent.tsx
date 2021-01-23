import React from 'react';
import AdminOverview from './AdminOverview';
import ManageShows from './ManageShows';
import ManageFilms from './ManageFilms';
import ManageHalls from './ManageHalls';
import './AdminContent.css';

interface Props {
  section: string;
}

function AdminContent({ section }: Props) {
  return (
    <main className="admin-content">
      { section === '/admin' && <AdminOverview/> }
      { section === '/admin/shows' && <ManageShows/> }
      { section === '/admin/films' && <ManageFilms/> }
      { section === '/admin/halls' && <ManageHalls/> }
    </main>
  );
}

export default AdminContent;
