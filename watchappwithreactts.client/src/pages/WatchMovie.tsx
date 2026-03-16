import { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { fetchMovieStream, fetchMovieDetail } from '../services/api';
import type { StreamData, MovieDetail as MovieDetailType } from '../types/movie';
import './WatchMovie.css';

const WatchMovie = () => {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();
  
  const [streamData, setStreamData] = useState<StreamData | null>(null);
  const [movieDetail, setMovieDetail] = useState<MovieDetailType | null>(null);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    if (!id) return;

    const loadData = async () => {
      try {
        setLoading(true);
        const [streamRes, detailRes] = await Promise.all([
          fetchMovieStream(id),
          fetchMovieDetail(id)
        ]);

        if (streamRes.success && detailRes.success) {
          setStreamData(streamRes.data);
          setMovieDetail(detailRes.data);
        } else {
          setError('Failed to load streaming data.');
        }
      } catch (err) {
        setError('An error occurred. Please try again later.');
      } finally {
        setLoading(false);
      }
    };

    loadData();
  }, [id]);

  if (loading) {
    return <div className="watch-message">Loading player...</div>;
  }

  if (error || !streamData || !movieDetail) {
    return (
      <div className="watch-message error">
        {error || 'Video not found.'}
        <button onClick={() => navigate(-1)} className="back-button">Go Back</button>
      </div>
    );
  }

  return (
    <div className="watch-container">
      <button className="back-button-top" onClick={() => navigate(-1)}>
        &larr; Back to Details
      </button>
      
      <div className="video-player-placeholder">
        <div className="play-icon">▶</div>
        <p>Video Player Placeholder</p>
        <p className="manifest-url">Manifest: {streamData.manifestUrl}</p>
      </div>

      <div className="watch-info">
        <h1 className="watch-title">{movieDetail.title}</h1>
        <p className="watch-description">{movieDetail.description}</p>
      </div>
    </div>
  );
};

export default WatchMovie;