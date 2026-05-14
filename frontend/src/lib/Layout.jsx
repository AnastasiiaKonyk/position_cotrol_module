import React from 'react';
import Header from '../components/Header/Header';
import Sidebar from '../components/Sidebar/Sidebar';
import './Layout.css';

const Layout = ({ children, userName = 'Користувач' }) => {
  return (
    <div className="layout">
      <Header userName={userName} />
      <div className="layout-body">
        <Sidebar />
        <main className="layout-content">
          {children}
        </main>
      </div>
    </div>
  );
};

export default Layout;
