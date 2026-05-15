import React, { useState } from 'react';
import './Table.css';

const Table = ({ columns, data, onEdit, onArchive }) => {
  const [contextMenu, setContextMenu] = useState(null);
  const [selectedRowIndex, setSelectedRowIndex] = useState(null);

  const handleContextMenu = (event, rowIndex) => {
    event.preventDefault();
    setSelectedRowIndex(rowIndex);
    setContextMenu({
      x: event.clientX,
      y: event.clientY,
    });
  };

  const handleCloseMenu = () => {
    setContextMenu(null);
    setSelectedRowIndex(null);
  };

  const handleEdit = () => {
    if (onEdit && selectedRowIndex !== null) {
      onEdit(data[selectedRowIndex]);
    }
    handleCloseMenu();
  };

  const handleArchive = () => {
    if (onArchive && selectedRowIndex !== null) {
      onArchive(data[selectedRowIndex]);
    }
    handleCloseMenu();
  };

  return (
    <div className="table-wrapper" onClick={handleCloseMenu}>
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
            <tr
              key={rowIndex}
              onContextMenu={(e) => handleContextMenu(e, rowIndex)}
            >
              {columns.map((col, colIndex) => (
                <td key={colIndex}>
                  {col.render ? col.render(row[col.key], row) : row[col.key]}
                </td>
              ))}
            </tr>
          ))}
        </tbody>
      </table>

      {/* Context Menu */}
      {contextMenu && (
        <div
          className="context-menu"
          style={{
            top: `${contextMenu.y}px`,
            left: `${contextMenu.x}px`,
          }}
          onClick={(e) => e.stopPropagation()}
        >
          <button className="context-menu-item edit" onClick={handleEdit}>
            <span>Редагувати</span>
          </button>
          <div className="context-menu-divider"></div>
          <button className="context-menu-item archive" onClick={handleArchive}>
            <span>Архівувати</span>
          </button>
        </div>
      )}
    </div>
  );
};

export default Table;