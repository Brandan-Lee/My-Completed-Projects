import Hero from "./Hero";
import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import imageSrc from '../images/Not-found.jpg';
import PageNotFound from "./PageNotFound";

const MovieView = () => {
    const {id} = useParams();
    const [movieDetails, setMovieDetails] = useState({});
    const [isLoading, setIsLoading] = useState(true);
    
    useEffect(() => {
        const url = `https://api.themoviedb.org/3/movie/${id}`;
        const options = {
        method: 'GET',
        headers: {
            accept: 'application/json',
            Authorization: 'Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIyMjE2ZWZiNmM3ZTY2ZTA5MDlmNzIwZGJiMDYwYWNkMCIsInN1YiI6IjY0YjY1NDQxYWM0MTYxMDEzOTFkMWZkZiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.x0KenUhe6ViAMjydRyVdc2pOkk4vTDxRaEFZVZhCzFw'
            }
        };
        
        fetch(url, options)
            .then(response => response.json())
            .then(data => {
                setMovieDetails(data)
                setIsLoading(false)
            })
    }, [id])

    function RenderMovieDetails() {
        if (isLoading) {
            return <Hero text="Loading..."/>
        }

        if (movieDetails) {
            const posterPath = movieDetails.poster_path;
            const backdropUrl = `https://image.tmdb.org/t/p/original${movieDetails.backdrop_path}`

            if (posterPath !== null) {
                return (
                    <div>
                        <Hero text={movieDetails.original_title} backdrop={backdropUrl}/>
                        <div className="container my-5">
                            <div className="row">
                                <div className="col-md-3">
                                    <img src={posterPath} alt={movieDetails.original_title} className="img-fluid shadow rounded" />
                                </div>
                                <div className="col-md-9">
                                    <h2>{movieDetails.original_title}</h2>
                                    <p className="lead">
                                        {movieDetails.overview}
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                ) 
            } else if (movieDetails === null) {
                <PageNotFound />
            }

            if (posterPath === null) {
                return (
                    <div>
                    <Hero text={movieDetails.original_title}/>
                    <div className="container my-5">
                        <div className="row">
                            <div className="col-md-3">
                                <img src={imageSrc} alt={movieDetails.original_title} className="img-fluid shadow rounded" />
                            </div>
                            <div className="col-md-9">
                                <h2>{movieDetails.original_title}</h2>
                                <p className="lead">
                                    {movieDetails.overview}
                                </p>
                            </div>
                        </div>
                    </div>
                </div> 
                )
            }
        }

    }

    return RenderMovieDetails()
  };

export default MovieView;