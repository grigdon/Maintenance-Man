import { Link } from "react-router-dom";
import "./Navbar.css";
import car from "../../src/assets/car-image.png";

// Static navigation bar with routing to other pages, cojoined with 'Layout'

export function Navbar() {
    return (
        <div className='navbar'>
            <div className="logo-container">
                <img className="car-image" src={car} alt="Car logo"/>
                <span className="nav-title">Maintenance Tracker</span>
            </div>

            <div className='btn-container'>
                <Link to="/">
                    <button className="btn-navbar">Home</button>
                </Link>
                <Link to="/carprofile">
                    <button className="btn-navbar">Car Profile</button>
                </Link>
                <Link to="/userprofile">
                    <button className="btn-navbar">User Profile</button>
                </Link>
            </div>
        </div>
    );
}
