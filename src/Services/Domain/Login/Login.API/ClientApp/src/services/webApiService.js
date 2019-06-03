import axios from 'axios';

class WebApiService {   
    login(obj) {
        const url = '/account/login/';
        return axios.post(url, obj);
    }

    registration(role, data) {
        var url = `/registration/${role}`;
        return axios.post(url, data);
    }
}

export default WebApiService