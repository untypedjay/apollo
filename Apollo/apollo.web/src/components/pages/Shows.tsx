import React, { useEffect, useState } from 'react';
import Navbar from '../organisms/Navbar';
import { fetchShows } from '../../services/showService';

function Shows() {
  const [shows, setShows] = useState([]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    getShows();
  }, []);

  const getShows = async () => {
    const response = await fetchShows();
    console.log(response);
    setShows(await response.json());
    //setIsLoading(false);
  }

  return (
    <div className="shows">
      <Navbar/>
      <main className="sh">

      </main>
    </div>
  );
}

export default Shows;