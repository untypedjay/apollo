import React from 'react';
import { MovieProvider } from '../../context/MovieContext';
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
    <MovieProvider>
      <main className="admin-content">
        { section === '/admin' && <AdminOverview/> }
        { section === '/admin/shows' && <ManageShows/> }
        { section === '/admin/movies' && <ManageMovies/> }
        { section === '/admin/halls' && <ManageHalls/> }
      </main>
    </MovieProvider>
  );
}

export default AdminContent;
