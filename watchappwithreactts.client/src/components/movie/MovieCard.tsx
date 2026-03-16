import React from 'react';
import { Link } from 'react-router-dom';
import type { MovieSummary } from '../../types/movie';
import './MovieCard.css';

interface MovieCardProps {
  movie: MovieSummary;
}

const MovieCard: React.FC<MovieCardProps> = ({ movie }) => {
  return (
    <Link to={`/movie/${movie.id}`} className="movie-card">
      <div className="movie-card-image-container">
        <img src={movie.thumbnailUrl} alt={movie.title} className="movie-card-image" />
        <div className="movie-card-rating">⭐ {movie.rating}</div>
      </div>
      <div className="movie-card-info">
        <h3 className="movie-card-title">{movie.title}</h3>
        <span className="movie-card-year">{movie.releaseYear}</span>
      </div>
    </Link>
  );
};

export default MovieCard;