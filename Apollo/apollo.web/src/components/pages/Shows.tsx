import React, { useEffect, useState } from 'react';
import Navbar from '../organisms/Navbar';
import { fetchShows } from '../../services/showService';
import ShowContainer from '../templates/ShowContainer';

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
      <ShowContainer shows={shows}/>
    </div>
  );
}

export default Shows;