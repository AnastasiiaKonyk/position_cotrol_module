import { useEffect } from 'react';
import Layout from './lib/Layout';
import PositionPage from './pages/PositionTypes/PositionPage';
import { setupAutoLogin } from './services/authService';

function App() {
  useEffect(() => {
    setupAutoLogin();
  }, []);

  return (
    <Layout userName="Писар Богдан">
      <PositionPage />
    </Layout>
  );
}

export default App;
