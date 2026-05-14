import React from 'react';
import './Search.css';
import { Icons } from '../../assets';

const Search = ({ 
  placeholder = 'Текстовий пошук',
  value, 
  onChange
}) => {
  return (
    <div className="search-wrapper">
      <input
        type="text"
        placeholder={placeholder}
        value={value}
        onChange={onChange}
        className="search-input"
      />
    {/* <img src={Icons.Search} alt="search" className="search-icon" /> */}
      <button className="search-icon">
           <img src={Icons.Search} alt="search"/>
        </button>
    </div>
  );
};

export default Search;
