import React from 'react';
import { Link } from 'react-router-dom';

function Header() {
  return (
    <nav className="navbar navbar-dark bg-dark">
      <div className="container-fluid">
        <Link className="navbar-brand mb-0 h1 mx-auto" to="/">PizzaHouse - Chemist Warehouse Group</Link>
      </div>
    </nav>
  );
}

export default Header;
