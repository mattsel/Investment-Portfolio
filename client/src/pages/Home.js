// src/pages/Home.js
import React from 'react';
import { Link } from 'react-router-dom'; // Import Link

const Home = () => {
    return (
        <div>
            <h1>Welcome to the Portfolio Manager</h1>
            <Link to="/login">
                <button>Login</button> {/* Button to navigate to login page */}
            </Link>
        </div>
    );
};

export default Home;
