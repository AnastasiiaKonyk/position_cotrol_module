import React from 'react';
import './Button.css';

const Button = ({ text, onClick, variant = 'primary', icon }) => {
  return (
    <button className={`btn ${variant}`} onClick={onClick}>
      <span className="btn-text">{text}</span>
      {icon && (
        <span className="btn-icon">
          {typeof icon === 'string' ? (
            <img src={icon} alt="button-icon" className="icon-image" />
          ) : (
            icon
          )}
        </span>
      )}
    </button>
  );
};

export default Button;