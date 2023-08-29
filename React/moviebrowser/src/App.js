import './App.css';
import { useState, useEffect } from 'react';
import Navbar from './Components/Navbar'
import Home from './Components/Home'
import AboutView from './Components/AboutView';
import SearchView from './Components/SearchView';
import MovieView from './Components/MovieView';
import PageNotFound from './Components/PageNotFound';
import { Routes ,Route } from 'react-router-dom';

function App() {
  const [searchResults, setSearchResults] = useState([]);
  const [searchText, setSearchText] = useState("");

  useEffect(() => {
    const url = `https://api.themoviedb.org/3/search/movie?query=${searchText}&include_adult=false&page=1`;
    const options = {
      method: 'GET',
      headers: {
        accept: 'application/json',
        Authorization: 'Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIyMjE2ZWZiNmM3ZTY2ZTA5MDlmNzIwZGJiMDYwYWNkMCIsInN1YiI6IjY0YjY1NDQxYWM0MTYxMDEzOTFkMWZkZiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.x0KenUhe6ViAMjydRyVdc2pOkk4vTDxRaEFZVZhCzFw'
      }
    };

    if (searchText) {
      fetch(url, options)
        .then(response => response.json())
        .then(data => {
          setSearchResults(data.results)
        })
    }

  }, [searchText])

  return (
    <div>
      <Navbar searchText={searchText} setSearchText={setSearchText} />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/about" element={<AboutView />} />
        <Route path="/search" element={<SearchView keyword={searchText} searchResults={searchResults} />} />
        <Route path="/movies/:id" element={<MovieView />} />
        <Route path="*" element={<PageNotFound />} />
      </Routes>
    </div>
  );
}

export default App;
