import Axios from 'axios';
import baseApiModel from './baseApiModel'

class BaseDictionaryApiModel extends baseApiModel {
    search(requestParams) {
        let errorMessage = this._checkControllerEnabled(this._controller);
        if (errorMessage) {
            throw new Error(errorMessage);
        }
        const params = {
            value: requestParams.value || '',
            count: requestParams.count || 20,
            offset: requestParams.offset || 0,
            ignoreCase: requestParams.ignoreCase || true
        }
        const url = `api/${this._controller}/search`;
        const finalUrl = requestParams.ownerId
            ? url + `/ownerId=${requestParams.ownerId}` 
            : url; 
        return Axios.get(finalUrl, { params });
    }
}

export default BaseDictionaryApiModel;