import React, { useEffect, useState } from 'react';
import Navbar from '../organisms/Navbar';
import Footer from '../organisms/Footer';
import Loader from '../atoms/Loader';
import Empty from '../molecules/Empty';
import ShowContainer from '../templates/ShowContainer';
import './Today.css';
import {searchByDate} from '../../helpers/search';

function Today() {
  const [shows, setShows] = useState([]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    getShows();
  }, []);

  const getShows = async () => {
    const filteredShows = await searchByDate(new Date().toString());
    setShows(filteredShows);
    setIsLoading(false);
  };

  const renderContent = () => {
    if (isLoading) {
      return <Loader/>;
    } else if (shows.length === 0) {
      return <Empty/>;
    } else {
      return <ShowContainer shows={shows} title="Today playing"/>;
    }
  };

  return (
    <div className="today">
      <Navbar/>
      <main className="today__container">
        { renderContent() }
      </main>
      <Footer/>
    </div>
  );
}

export default Today;