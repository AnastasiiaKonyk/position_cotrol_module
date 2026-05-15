import React, { useState } from 'react';
import { Icons } from '../../assets';
import './Sidebar.css';

const Sidebar = () => {
  const [isOpen, setIsOpen] = useState(true);
  const [expandedGroups, setExpandedGroups] = useState({});

  const menuItems = [
    {
      id: 'hr',
      label: 'Кадри',
      icon: Icons.Team,
      children: [
        {
          id: 'staff-movements',
          label: 'Кадрові перемiщення',
          path: '/staff-movements',
        },
        {
          id: 'employee-card',
          label: 'Картка працівника',
          path: '/employee-card',
        },
        {
          id: 'position',
          label: 'Посади',
          path: '/position',
        },
        {
          id: 'position-types',
          label: 'Типи посад',
          path: '/position-types',
        },
      ],
    },
    {
      id: 'positions',
      label: 'Щось ще',
      icon: Icons.Team,
      children: [
        {
          id: 'position-types',
          label: 'блаблабла',
          path: '/position-types',
        },
      ],
    },
    // {
    //   id: 'users',
    //   label: 'Користувачі',
    //   path: '/users',
    //   icon: Icons.Account,
    // },
  ];

  const toggleGroup = (groupId) => {
    setExpandedGroups((prev) => ({
      ...prev,
      [groupId]: !prev[groupId],
    }));
  };

  const renderMenuItem = (item) => {
    const isGroup = item.children && item.children.length > 0;
    const isExpanded = expandedGroups[item.id];

    if (isGroup) {
      return (
        <li key={item.id} className="nav-item nav-group">
          <button
            className={`nav-group-toggle ${isExpanded ? 'expanded' : ''}`}
            onClick={() => toggleGroup(item.id)}
          >
            <img src={item.icon} alt={item.label} className="nav-icon" />
            <span className="nav-label">{item.label}</span>
            <svg className="group-arrow" viewBox="0 0 24 24" fill="none" stroke="#797979" strokeWidth="2">
              <path d="M19 8l-7 7-7-7" />
            </svg>
          </button>

          {isExpanded && (
            <ul className="nav-sublist">
              {item.children.map((child) => (
                <li key={child.id} className="nav-item nav-subitem">
                  <a href={child.path} className="nav-link nav-sublink">
                    <span className="nav-label">{child.label}</span>
                  </a>
                </li>
              ))}
            </ul>
          )}
        </li>
      );
    }

    return (
      <li key={item.id} className="nav-item">
        <a href={item.path} className="nav-link">
          <img src={item.icon} alt={item.label} className="nav-icon" />
          <span className="nav-label">{item.label}</span>
        </a>
      </li>
    );
  };

  return (
    <aside className={`sidebar ${isOpen ? 'open' : 'closed'}`}>
      <nav className="sidebar-nav">
        <ul className="nav-list">
          {menuItems.map((item) => renderMenuItem(item))}
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
