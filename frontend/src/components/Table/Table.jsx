import React from 'react';
import './Table.css';

const Table = ({ columns, data }) => {
  return (
    <div className="table-wrapper">
      <table className="modern-table">
        <thead>
          <tr>
            {columns.map((col, index) => (
              <th key={index} style={{ width: col.width }}>
                <span className="th-label">{col.header}</span>
              </th>
            ))}
          </tr>
        </thead>
        <tbody>
          {data.map((row, rowIndex) => (
            <tr key={rowIndex}>
              {columns.map((col, colIndex) => (
                <td key={colIndex}>
                  {col.render ? col.render(row[col.key], row) : row[col.key]}
                </td>
              ))}
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Table;