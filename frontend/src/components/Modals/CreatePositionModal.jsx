import React, { useState } from 'react';
import { Icons } from '../../assets';
import Input from '../UI/Input/Input';
import Select from '../UI/Select/Select';
import Button from '../UI/Buttons/ButtonGroup/ButtonGroup';
import './CreatePositionModal.css';

const CreatePositionModal = ({ isOpen, onClose, onCreate }) => {
  const [formData, setFormData] = useState({
    name: '',
    fullName: '',
    accountingType: '',
    category: '',
    activeAd: false,
  });

  const handleInputChange = (e) => {
    const { name, value, type, checked } = e.target;
    setFormData({
      ...formData,
      [name]: type === 'checkbox' ? checked : value,
    });
  };

  const handleCreate = () => {
    onCreate(formData);
    setFormData({
      name: '',
      fullName: '',
      accountingType: '',
      category: '',
      activeAd: false,
    });
  };

  if (!isOpen) return null;

  return (
    <div className="modal-overlay" onClick={onClose}>
      <div className="modal-content" onClick={(e) => e.stopPropagation()}>
        <div className="modal-header">
          <h2>Створення типу посади</h2>
          <button className="modal-close" onClick={onClose}>
            <img src={Icons.Close} alt="close" />
          </button>
        </div>

        <div className="modal-body">
          <Input
            label="Назва"
            name="name"
            placeholder="Введіть значення"
            value={formData.name}
            onChange={handleInputChange}
          />

          <Input
            label="Повна назва"
            name="fullName"
            placeholder="Введіть значення"
            value={formData.fullName}
            onChange={handleInputChange}
          />

          <Select
            label="Тип обліку"
            name="accountingType"
            value={formData.accountingType}
            onChange={handleInputChange}
            options={[
              { value: 'Фактичний', label: 'Фактичний' },
              { value: 'Бухгалтерський', label: 'Бухгалтерський' },
            ]}
          />

          <Select
            label="Категорія"
            name="category"
            value={formData.category}
            onChange={handleInputChange}
            options={[
              { value: 'Стандарт', label: 'Стандарт' },
              { value: 'Магазини', label: 'Магазини' },
            ]}
          />

          <div className="form-group checkbox-group">
            <input
              type="checkbox"
              name="activeAd"
              checked={formData.activeAd}
              onChange={handleInputChange}
              id="activeAd"
            />
            <label htmlFor="activeAd">Активація AD</label>
          </div>

          <div className="modal-footer">
            <Button 
              text="Створити"
              variant="primary"
              onClick={handleCreate}
            />
            <Button 
              text="Скасувати"
              variant="secondary"
              onClick={onClose}
            />
          </div>
        </div>
      </div>
    </div>
  );
};

export default CreatePositionModal;
