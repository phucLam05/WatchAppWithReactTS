import type { MovieDetailResponse, PaginatedResponse, MovieSummary, StreamResponse } from '../types/movie';

const API_BASE_URL = 'https://localhost:7072/api/v1';

export const fetchMovies = async (page = 1, limit = 20, category?: string, sort?: string): Promise<PaginatedResponse<MovieSummary>> => {
  const url = new URL(`${API_BASE_URL}/movies`);
  url.searchParams.append('page', page.toString());
  url.searchParams.append('limit', limit.toString());
  if (category) url.searchParams.append('category', category);
  if (sort) url.searchParams.append('sort', sort);

  const response = await fetch(url.toString());
  if (!response.ok) {
    throw new Error('Failed to fetch movies');
  }
  return await response.json();
};

export const fetchMovieDetail = async (id: string): Promise<MovieDetailResponse> => {
  const response = await fetch(`${API_BASE_URL}/movies/${id}`);
  if (!response.ok) {
    throw new Error('Failed to fetch movie details');
  }
  return await response.json();
};

export const fetchMovieStream = async (id: string): Promise<StreamResponse> => {
  const response = await fetch(`${API_BASE_URL}/movies/${id}/stream`);
  if (!response.ok) {
    throw new Error('Failed to fetch movie stream');
  }
  return await response.json();
};
