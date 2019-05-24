import axios from 'axios';
import roles from '../settings/roles'

const HOST_URL = 'http://localhost:5105'

class WebApiService {   
    login(obj) {
        const url = `${HOST_URL}/account/login/`;
        return axios.post(url, obj);
    }

    registration(role, data) {
        var url = `${HOST_URL}/registration/${role}`;
        return axios.post(url, data);
    }
}

export default WebApiService