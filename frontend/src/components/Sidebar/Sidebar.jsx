import React, { useState } from 'react';
import { Icons } from '../../assets';
import './Sidebar.css';

const Sidebar = () => {
  const [isOpen, setIsOpen] = useState(true);

  const menuItems = [
    {
      label: 'Посади',
      path: '/positions',
      icon: Icons.Team,
    },
    {
      label: 'Користувачі',
      path: '/users',
      icon: Icons.Account,
    },
  ];

  return (
    <aside className={`sidebar ${isOpen ? 'open' : 'closed'}`}>
      <nav className="sidebar-nav">
        <ul className="nav-list">
          {menuItems.map((item) => (
            <li key={item.path} className="nav-item">
              <a href={item.path} className="nav-link">
                <img src={item.icon} alt={item.label} className="nav-icon" />
                <span className="nav-label">{item.label}</span>
              </a>
            </li>
          ))}
        </ul>
      </nav>

      {/* Collapse Button */}
      <button
        className="sidebar-toggle"
        onClick={() => setIsOpen(!isOpen)}
        title={isOpen ? 'Згорнути' : 'Розгорнути'}
      >
        <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2">
          {isOpen ? (
            <path d="M15 19l-7-7 7-7" />
          ) : (
            <path d="M9 19l7-7-7-7" />
          )}
        </svg>
      </button>
    </aside>
  );
};

export default Sidebar;
