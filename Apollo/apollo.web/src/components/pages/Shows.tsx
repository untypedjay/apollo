import React, { useEffect, useState } from 'react';
import Navbar from '../organisms/Navbar';
import { fetchShows } from '../../services/showService';
import ShowContainer from '../templates/ShowContainer';
import Footer from '../organisms/Footer';
import Empty from '../molecules/Empty';
import './Shows.css';
import Loader from '../atoms/Loader';

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
    setIsLoading(false);
  }

  const renderContent = () => {
    if (isLoading) {
      return <Loader/>;
    } else if (shows.length === 0) {
      return <Empty/>;
    } else {
      return <ShowContainer shows={shows}/>
    }
  }

  return (
    <div className="shows">
      <Navbar/>
      <main className="shows__container">
        { renderContent() }
      </main>
      <Footer/>
    </div>
  );
}

export default Shows;