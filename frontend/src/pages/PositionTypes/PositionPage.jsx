import React, { useState, useEffect } from 'react';
import api from '../../interceptors/auth.interceptor';
import { setupAutoLogin } from '../../services/authService';
import { status_labels, category_labels } from './PositionPageEnums';

import CreateButton from '../../components/UI/Buttons/CreateButton/Button';
import Table from '../../components/Table/Table';
import CreatePositionModal from '../../components/Modals/CreatePositionModal';
import Toggle from '../../components/UI/Toggle/Toggle';
import Search from '../../components/Search/Search';
import { Icons } from '../../assets';
import './PositionPage.css';

const PositionPage = () => {
  const [showArchived, setShowArchived] = useState(false);
  const [isModalOpen, setIsModalOpen] = useState(false);
  
  const [positions, setPositions] = useState([]);
  const [loading, setLoading] = useState(true);

  const fetchPositions = async () => {
    try {
        setLoading(true);
        await setupAutoLogin(); 

        const response = await api.get('/TypePosad');
        setPositions(response.data.items || response.data);
    } catch (error) {
        console.error("Помилка:", error);
    } finally {
        setLoading(false);
    }
  };

  useEffect(() => {
    fetchPositions();
  }, []);

  const [isEdit, setIsEdit] = useState(false);
  const [editData, setEditData] = useState(null);

  // Визначаємо колонки
  const columns = [
    { header: '№', key: 'id' },
    { header: 'Назва', key: 'name' },
    { header: 'Повна назва', key: 'nameFull' },
    { header: 'Тип обліку', key: 'status', render: (val) => status_labels[val] },
    { header: 'Категорія', key: 'category', render: (val) => category_labels[val] },
    { 
      header: 'Активація AD', 
      key: 'activeAd', 
      render: (val) => <input type="checkbox" checked={val} readOnly className="custom-checkbox"/> 
    },
  ];

  const handleCreatePosition = (formData) => {
    if (isEdit) {
      console.log('Редаговано посаду:', formData);
      setIsEdit(false);
      setEditData(null);
    } else {
      console.log('Нова посада:', formData);
    }
    setIsModalOpen(false);
  };

  const handleEdit = (row) => {
    setEditData(row);
    setIsEdit(true);
    setIsModalOpen(true);
  };

  const handleArchive = (row) => {
    console.log('Архівувано:', row);
  };

  // Тимчасові тестові дані (поки бекенд готується)
  const testData = [
    { id: 1, name: 'Адміністратор', fullName: 'Адміністратор систем', accountingType: 'Фактичний', category: 'Стандарт', activeAd: true },
    { id: 2, name: 'Бухгалтер', fullName: 'Старший бухгалтер', accountingType: 'Бухгалтерський', category: 'Стандарт', activeAd: false },
  ];

  const handleOpenCreateModal = () => {
    setIsEdit(false);
    setEditData(null);
    setIsModalOpen(true);
  };

  return (
    <div className="page-wrapper">
      <div className="top-bar">
        <div className="title-section">
          <Search />
        </div>
        <div className="actions-section">
          <Toggle 
            isOn={showArchived} 
            handleToggle={() => setShowArchived(!showArchived)} 
            label="Архівні посади" 
          />
          <span className="divider"></span>
          <CreateButton 
            text="Створити" 
            variant="primary" 
            icon={Icons.Add}
            onClick={handleOpenCreateModal}
          />
        </div>
      </div>

      {loading ? (
        <p>Завантаження даних...</p>
      ) : (
        <Table columns={columns} data={positions} />
      )}

      <CreatePositionModal 
        isOpen={isModalOpen}
        onClose={() => setIsModalOpen(false)}
        onCreate={handleCreatePosition}
      />
        <Table 
          columns={columns} 
          data={testData}
          onEdit={handleEdit}
          onArchive={handleArchive}
        />

        <CreatePositionModal 
          isOpen={isModalOpen}
          onClose={() => setIsModalOpen(false)}
          onCreate={handleCreatePosition}
          isEdit={isEdit}
          editData={editData}
        />
      
    </div>
  );
};

export default PositionPage;