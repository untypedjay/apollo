import React from 'react';
import AdminOverview from './AdminOverview';
import ManageShows from './ManageShows';
import ManageMovies from './ManageMovies';
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
      { section === '/admin/movies' && <ManageMovies/> }
      { section === '/admin/halls' && <ManageHalls/> }
    </main>
  );
}

export default AdminContent;
