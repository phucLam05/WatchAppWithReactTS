import React from 'react';
import type { MovieSummary } from '../../types/movie';
import MovieCard from './MovieCard';
import './MovieList.css';

interface MovieListProps {
  movies: MovieSummary[];
}

const MovieList: React.FC<MovieListProps> = ({ movies }) => {
  if (movies.length === 0) {
    return <div className="no-movies">No movies found.</div>;
  }

  return (
    <div className="movie-list">
      {movies.map(movie => (
        <MovieCard key={movie.id} movie={movie} />
      ))}
    </div>
  );
};

export default MovieList;