import Hero from "./Hero";
import { Link } from "react-router-dom";
import imageSrc from "../images/Not-found.jpg";

const MovieCard = ({ movie }) => {
  const posterPath = movie.poster_path;
  const posterUrl = `https://image.tmdb.org/t/p/w500${posterPath}`;
  const detailUrl = `/movies/${movie.id}`;

  if (posterPath !== null) {
    return (
      <div className="col-lg-4 col-md-3 col-2 my-4">
        <div className="card">
          <img
            src={posterUrl}
            className="card-img-top"
            alt={movie.original_title}
          />
          <div className="card-body">
            <h5 className="card-title">{movie.original_title}</h5>
            <p className="card-text"></p>
            <Link to={detailUrl} className="btn btn-primary">
              Show Details
            </Link>
          </div>
        </div>
      </div>
    );
  }

  if (posterPath === null) {
    return (
      <div className="col-lg-4 col-md-3 col-2 my-4">
        <div className="card">
          <img
            src={imageSrc}
            className="card-img-top"
            alt={movie.original_title}
          />
          <div className="card-body">
            <h5 className="card-title">{movie.original_title}</h5>
            <p className="card-text"></p>
            <Link to={detailUrl} className="btn btn-primary">
              Show Details
            </Link>
          </div>
        </div>
      </div>
    );
  }
};

const SearchView = ({ keyword, searchResults }) => {
  const title = `You are searching for ${keyword}`;

  const resultsHtml = searchResults.map((obj, i) => {
    return <MovieCard movie={obj} key={i} />;
  });

  return (
    <div>
      <Hero text={title} />
      {resultsHtml && (
        <div className="container">
          <div className="row">{resultsHtml}</div>
        </div>
      )}
    </div>
  );
};

export default SearchView;
