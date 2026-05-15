import React, { useState } from 'react'; 
// import GroupButton from '../../components/UI/GroupButton/Button';
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
  const [isEdit, setIsEdit] = useState(false);
  const [editData, setEditData] = useState(null);

  // Визначаємо колонки
  const columns = [
    { header: '№', key: 'id' },
    { header: 'Назва', key: 'name' },
    { header: 'Повна назва', key: 'fullName' },
    { header: 'Тип обліку', key: 'accountingType' },
    { header: 'Категорія', key: 'category' },
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
          {/* <h1>Типи посад</h1>
          <img src={Icons.Team} alt="team" />        */}
          <Search/>

        </div>
        <div className="actions-section">


          {/* <label className="archive-label">
            <input 
              type="checkbox" 
              checked={showArchived} 
              onChange={() => setShowArchived(!showArchived)} 
            />
            Показувати архівні посади
          </label> */}

          <Toggle isOn={showArchived} handleToggle={() => setShowArchived(!showArchived)} label="Архівні посади" />
          <span className="divider"></span>
          <CreateButton 
            text="Створити" 
            variant="primary" 
            icon={Icons.Add}
            onClick={handleOpenCreateModal}
          />
        </div>
      </div>
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