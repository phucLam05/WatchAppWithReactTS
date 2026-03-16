import { Link } from 'react-router-dom';
import './NavBar.css';

const NavBar = () => {
    return (
        <nav className="navbar">
            <div className="navbar-container">
                <Link to="/" className="navbar-brand">
                    MovieWatch
                </Link>
                <div className="navbar-menu">
                    <button className="navbar-item" onClick={() => console.log("Search clicked")}>Search</button>
                    <button className="navbar-item" onClick={() => console.log("Category clicked")}>Categories</button>
                    <button className="navbar-item" onClick={() => console.log("Login clicked")}>Login</button>
                </div>
            </div>
        </nav>
    );
};

export default NavBar;
