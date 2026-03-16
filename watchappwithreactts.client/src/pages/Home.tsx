import { useEffect, useState } from 'react';
import { fetchMovies } from '../services/api';
import type { MovieSummary } from '../types/movie';
import MovieList from '../components/movie/MovieList';
import './Home.css';

const Home = () => {
  const [movies, setMovies] = useState<MovieSummary[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const loadMovies = async () => {
      try {
        setLoading(true);
        const response = await fetchMovies(1, 20);
        if (response.success) {
          setMovies(response.data.items);
        } else {
          setError('Failed to fetch movies.');
        }
      } catch (err) {
        setError('An error occurred while fetching movies.');
      } finally {
        setLoading(false);
      }
    };

    loadMovies();
  }, []);

  if (loading) {
    return <div className="home-message">Loading movies...</div>;
  }

  if (error) {
    return <div className="home-message error">{error}</div>;
  }

  return (
    <div className="home-container">
      <h1 className="home-title">Trending Movies</h1>
      <MovieList movies={movies} />
    </div>
  );
};

export default Home;