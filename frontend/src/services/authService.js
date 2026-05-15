import api from '../interceptors/auth.interceptor';

export const setupAutoLogin = async () => {
    let token = localStorage.getItem('token');

    if (!token) {
        try {
            const response = await api.get('/auth/auto-login');
            token = response.data.token;
            localStorage.setItem('token', token);
            console.log("Successfully performed auto-login, token stored.");
            return token;
        } catch (error) {
            console.error("Failed to perform auto-login:", error);
            return null;
        }
    }
    return token;
};
