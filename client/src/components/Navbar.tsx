import { Link } from "react-router-dom";
import "../components_css/Navbar.css";
import car from "../../src/assets/car-image.png";
import userIcon from "../../src/assets/user-regular.svg"
import githubIcon from "../../src/assets/github-brands.svg"

// Static navigation bar with routing to other pages, cojoined with 'Layout'

export function Navbar() {
    return (
        <div className='navbar'>
            <div className="logo-container">
                <Link to="/">
                    <button className="btn-navbar">
                        <img className="car-image" src={car} alt="Car logo"/>
                    </button>
                </Link>
            </div>
            <div className='btn-container'>
                <div>
                    <Link to="https://github.com/grigdon/Maintenance-Man">
                        <button className="btn-navbar">
                            <img className="image" src={githubIcon} alt="Github Logo"/>
                        </button>
                    </Link>
                </div>
                <div>
                    <Link to="/userprofile">
                        <button className="btn-navbar">
                            <img className="image" src={userIcon} alt="User Logo"/>
                        </button>
                    </Link>
                </div>
                <div>
                    <Link to="/login">
                        <button className="btn-navbar">Login</button>
                    </Link>
                </div>
            </div>
        </div>
    );
}
