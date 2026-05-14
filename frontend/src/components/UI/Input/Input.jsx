import React from 'react';
import './Input.css';

const Input = ({ 
  label, 
  name, 
  placeholder, 
  value, 
  onChange, 
  type = 'text'
}) => {
  return (
    <div className="input-group">
      {label && <label htmlFor={name}>{label}</label>}
      <input
        id={name}
        type={type}
        name={name}
        placeholder={placeholder}
        value={value}
        onChange={onChange}
        // className="input-field"
        className={`input-field ${value ? 'has-content' : ''}`}
      />
    </div>
  );
};

export default Input;
