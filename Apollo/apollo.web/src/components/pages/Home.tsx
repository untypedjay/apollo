import React, {useEffect, useState} from 'react';
import Navbar from '../organisms/Navbar';
import Footer from '../organisms/Footer';
import ShowCard from '../molecules/ShowCard';
import {fetchShows} from '../../services/showService';
import Loader from '../atoms/Loader';
import Empty from '../molecules/Empty';
import ShowContainer from '../templates/ShowContainer';
import './Home.css';

function Home() {
  const [shows, setShows] = useState([]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    getShows();
  }, [isLoading]);

  const getShows = async () => {
    const response = await fetchShows();
    setShows(await response.json());
    if (response.status === 200) {
      setIsLoading(false);
    } else {
      alert(`ERROR: Could not load shows (${response.status})`);
      console.log(response);
    }
  };

  const renderContent = () => {
    if (isLoading) {
      return <Loader/>;
    } else if (shows.length === 0) {
      return <Empty/>;
    } else {
      return (
        <>
          <ShowContainer shows={shows} title="Featured"/>
        </>
      );
    }
  }

  return (
    <div className="home">
     <Navbar/>
      { renderContent() }
     <Footer/>
    </div>
  );
}

export default Home;