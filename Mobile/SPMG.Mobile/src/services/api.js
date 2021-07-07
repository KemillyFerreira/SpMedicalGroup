import axios from "axios"

const api = axios.create
({
    // guarda o link da URL
    baseURL: 'http://localhost:5000/api',
});

export default api;