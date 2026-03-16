import React from 'react';
import NavBar from './NavBar';
import './Layout.css';

interface LayoutProps {
  children: React.ReactNode;
}

const Layout: React.FC<LayoutProps> = ({ children }) => {
  return (
    <div className="layout">
      <NavBar />
      <main className="main-content">
        {children}
      </main>
    </div>
  );
};

export default Layout;