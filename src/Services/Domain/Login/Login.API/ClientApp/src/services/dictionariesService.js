import axios from 'axios';

const APIGW_URL = 'https://31.211.116.12:5200/';
const SEARCH_CITIES_POSTFIX = 'd/api/v1/areas/search/cities';
const SEARCH_EMPLOYERS_POSTFIX = 'e/api/v1/employers/search';
const SEARCH_EDUCATIONAL_INSTITUTIONS_POSTFIX = 'ei/api/v1/educationalinstitutions/search'
const GET_ALL_POSTFIX = 'd/api/v1/dictionaries';

const searchCities = inputValue => {
    const url = APIGW_URL + SEARCH_CITIES_POSTFIX;
    return _doSearchRequest(url, inputValue);
}

const getAll = () => {
    const url = APIGW_URL + GET_ALL_POSTFIX;
    return axios.get(url);
}

const searchEmployers = inputValue => {
    const url = APIGW_URL + SEARCH_EMPLOYERS_POSTFIX;
    return _doSearchRequest(url, inputValue);
}

const searchEducationalInstitutions = inputValue => {
    const url = APIGW_URL + SEARCH_EDUCATIONAL_INSTITUTIONS_POSTFIX;
    return _doSearchRequest(url, inputValue);
}

const _doSearchRequest = (url, inputValue) => {
    const searchObj = {
        template: inputValue,
        count: 10,
        offset: 0,
        case_sensitive: false
    }
    return axios.post(url, searchObj);
}

export default { searchCities, searchEmployers, searchEducationalInstitutions, getAll }