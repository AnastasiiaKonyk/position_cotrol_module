import React, { useState } from 'react';
import { Icons } from '../../assets';
import './Header.css';

const Header = ({ userName = 'Користувач' }) => {
  const [isDarkMode, setIsDarkMode] = useState(false);
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  const toggleDarkMode = () => {
    setIsDarkMode(!isDarkMode);
    // TODO: Реалізувати перемикання теми
  };

  const toggleMenu = () => {
    setIsMenuOpen(!isMenuOpen);
  };

  return (
    <header className="header">
      <div className="header-container">
        <div className="header-left">
          {/* <button className="header-btn menu-btn" title="Меню">
            <img src={Icons.Menu} alt="Меню" className="icon" />
          </button> */}
          {/* Logo */}
          <div className="header-logo">
            <img src={Icons.Logo} alt="Berta Group" className="logo-img" />
          </div>
        </div>
        {/* Right Section */}
        <div className="header-right">
          {/* Theme Toggle */}
          <button 
            className="header-btn theme-toggle"
            onClick={toggleDarkMode}
            title="Перемикнути тему"
          >
            <img src={Icons.Sun} alt="Тема" className="icon" />
          </button>

          {/* User Menu */}
          <div className="user-menu">
            <button 
              className="header-btn account-btn"
              onClick={toggleMenu}
              title="Меню користувача"
            >
              <span className="user-name">{userName}</span>
              <div className="account-icon-wrapper">
              <img src={Icons.Account} alt="Профіль" className="iconAccount" />
              </div>

            </button>

            {/* Dropdown Menu */}
            {isMenuOpen && (
              <div className="dropdown-menu">
                <a href="#profile" className="dropdown-item">Профіль</a>
                <a href="#settings" className="dropdown-item">Налаштування</a>
                <hr className="dropdown-divider" />
                <a href="#logout" className="dropdown-item logout">Вихід</a>
              </div>
            )}
          </div>
        </div>
      </div>
    </header>
  );
};

export default Header;
