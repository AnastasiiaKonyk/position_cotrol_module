import React from 'react';
import { Icons } from '../../../assets';
import './Select.css';

const Select = ({ 
  label, 
  name, 
  value, 
  onChange, 
  options = []
}) => {
  return (
    // <div className="select-group">
    //   {label && <label htmlFor={name}>{label}</label>}
    //   <div className="select-wrapper">
    //     <select
    //       id={name}
    //       name={name}
    //       value={value}
    //       onChange={onChange}
    //       className="select-field"
    //     >
    //       <option value="">Обрати значення...</option>
    //       {options.map((option) => (
    //         <option key={option.value} value={option.value}>
    //           {option.label}
    //         </option>
    //       ))}
    //     </select>
    //     <img src={Icons.Down} alt="dropdown" className="select-icon" />
    //   </div>
    // </div>
    <div className="select-group">
      {label && <label htmlFor={name}>{label}</label>}
      <div className="select-wrapper">
        <select
          id={name}
          name={name}
          value={value}
          onChange={onChange}
          /* ДОДАЄМО ЦЮ ЛОГІКУ: */
          className={`select-field ${value ? 'has-value' : ''}`}
        >
          {/* Додаємо атрибут disabled та hidden, щоб "Обрати значення" не можна було вибрати повторно */}
          <option value="" disabled hidden>Обрати значення...</option>
          {options.map((option) => (
            <option key={option.value} value={option.value}>
              {option.label}
            </option>
          ))}
        </select>
        <img src={Icons.Down} alt="dropdown" className="select-icon" />
      </div>
    </div>
  );
};

export default Select;
