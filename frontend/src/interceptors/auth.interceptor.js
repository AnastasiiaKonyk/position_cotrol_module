import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:7149/api', 
});

api.interceptors.request.use((config) => {
    const token = localStorage.getItem('token'); 
    const isAuthRequest = config.url && config.url.includes('auth/auto-login');
    if (token && !isAuthRequest) { 
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
}, (error) => {
    return Promise.reject(error);
});

export default api;