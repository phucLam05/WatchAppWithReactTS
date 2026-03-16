import { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { fetchMovieDetail } from '../services/api';
import type { MovieDetail as MovieDetailType } from '../types/movie';
import './MovieDetail.css';

const MovieDetail = () => {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();
  
  const [movie, setMovie] = useState<MovieDetailType | null>(null);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    if (!id) return;

    const loadMovieDetail = async () => {
      try {
        setLoading(true);
        const response = await fetchMovieDetail(id);
        if (response.success) {
          setMovie(response.data);
        } else {
          setError('Failed to load movie details.');
        }
      } catch (err) {
        setError('An error occurred. Please try again later.');
      } finally {
        setLoading(false);
      }
    };

    loadMovieDetail();
  }, [id]);

  if (loading) {
    return <div className="detail-message">Loading details...</div>;
  }

  if (error || !movie) {
    return (
      <div className="detail-message error">
        {error || 'Movie not found.'}
        <button onClick={() => navigate(-1)} className="back-button">Go Back</button>
      </div>
    );
  }

  return (
    <div className="detail-container">
      <div className="detail-cover" style={{ backgroundImage: `url(${movie.coverUrl})` }}>
        <div className="detail-cover-overlay"></div>
      </div>
      
      <div className="detail-content">
        <div className="detail-poster">
          <img src={movie.thumbnailUrl} alt={movie.title} />
        </div>
        
        <div className="detail-info">
          <h1 className="detail-title">{movie.title}</h1>
          
          <div className="detail-meta">
            <span>{movie.releaseYear}</span>
            <span>{movie.durationMinutes} min</span>
            <span className="detail-rating">⭐ {movie.rating}</span>
            {movie.isAvailableInHD && <span className="detail-hd">HD</span>}
          </div>

          <div className="detail-genres">
            {movie.genres.map((genre) => (
              <span key={genre} className="genre-tag">{genre}</span>
            ))}
          </div>

          <p className="detail-description">{movie.description}</p>
          
          <div className="detail-crew">
            <p><strong>Director:</strong> {movie.director}</p>
            <p><strong>Cast:</strong> {movie.cast.join(', ')}</p>
          </div>

          <button className="watch-button" onClick={() => navigate(`/watch/${movie.id}`)}>
            ▶ Watch Now
          </button>
        </div>
      </div>
    </div>
  );
};

export default MovieDetail;