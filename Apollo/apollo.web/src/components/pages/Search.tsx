import React, {FormEvent, useState} from 'react';
import Navbar from '../organisms/Navbar';
import Footer from '../organisms/Footer';
import Input from '../atoms/Input';
import './Search.css';
import Button from '../atoms/Button';
import {searchByMovieTitle} from '../../helpers/search';
import ShowContainer from '../templates/ShowContainer';

function Search() {
  const [movieSearch, setMovieSearch] = useState('');
  const [dateSearch, setDateSearch] = useState('');
  const [results, setResults] = useState([]);

  const handleInputChange = (event: FormEvent<HTMLInputElement>): void => {
    const eventTarget: any = event.target;
    if (eventTarget.name === 'movie') {
      setMovieSearch(eventTarget.value);
    } else if (eventTarget.name === 'date') {
      setDateSearch(eventTarget.value);
    }
  };

  const search = async () => {
    if (movieSearch.length > 0) {
      const filteredShows = await searchByMovieTitle(movieSearch);
      setResults(filteredShows);
    } else {

    }
  }

  return (
    <div className="search">
      <Navbar/>
      <main className="search__main">
        <div className="search__search-bar">
          <Input value={movieSearch} name="movie" onChange={handleInputChange}>Search by Movie</Input>
          <Input type="datetime-local" value={dateSearch} name="date" onChange={handleInputChange}>Search by Date</Input>
          <Button onClick={search}>Search</Button>
        </div>
        <ShowContainer shows={results}/>
      </main>

      <Footer/>
    </div>
  );
}

export default Search;