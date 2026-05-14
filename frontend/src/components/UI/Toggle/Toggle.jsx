import React from 'react';
import './Toggle.css';

const Toggle = ({ isOn, handleToggle, label }) => {
  return (
    <div className="toggle-wrapper">
      <div 
        className={`toggle-switch ${isOn ? 'on' : 'off'}`} 
        onClick={handleToggle}
      >
        <div className="toggle-circle"></div>
      </div>
      {label && <span className="toggle-label">{label}</span>}
    </div>
  );
};

export default Toggle;