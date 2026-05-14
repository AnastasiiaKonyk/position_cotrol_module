import React from 'react';
import './ButtonGroup.css';

const Button = ({ 
  text = 'Кнопка',
  isActive = false,
  onClick,
  variant = 'primary'
}) => {
  return (
    <button 
      className={`btn-group btn-${variant} ${isActive ? 'active' : ''}`} 
      onClick={onClick}
    >
      {text}
    </button>
  );
};

export default Button;
