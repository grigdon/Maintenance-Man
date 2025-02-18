import { Link } from "react-router-dom"

// Static navigation bar with routing to other pages, cojoined with 'Layout'

export function Navbar() {
    return (
        <>
            <Link to="/">
                <button>Home</button>
            </Link>
            <Link to="/carprofile">
                <button>Car Profile</button>
            </Link>
            <Link to="/userprofile">
                <button>User Profile</button>
            </Link>
        </>
    )
}