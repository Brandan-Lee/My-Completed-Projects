import imagaSrc from '../images/Error.jpg';

const PageNotFound = () => {
    return (
        <div>
            <div className="container mt-5">
                <img src={imagaSrc} alt="error" />
            </div>
        </div>
    )
}

export default PageNotFound;