export interface MovieSummary {
  id: string;
  title: string;
  thumbnailUrl: string;
  releaseYear: number;
  durationMinutes: number;
  genres: string[];
  rating: number;
}

export interface MovieDetail extends MovieSummary {
  description: string;
  coverUrl: string;
  director: string;
  cast: string[];
  isAvailableInHD: boolean;
}

export interface Pagination {
  currentPage: number;
  totalPages: number;
  totalItems: number;
  limit: number;
}

export interface PaginatedResponse<T> {
  success: boolean;
  data: {
    items: T[];
    pagination: Pagination;
  };
}

export interface MovieDetailResponse {
  success: boolean;
  data: MovieDetail;
}

export interface Subtitle {
  language: string;
  label: string;
  url: string;
}

export interface StreamData {
  movieId: string;
  streamType: string;
  manifestUrl: string;
  subtitles: Subtitle[];
  thumbnailSprites: string;
}

export interface StreamResponse {
  success: boolean;
  data: StreamData;
}
