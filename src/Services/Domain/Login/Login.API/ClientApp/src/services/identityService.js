import axios from 'axios';

const IDENTITY_URL = 'https://31.211.113.168:5105/';

const USER_INFO_POSTFIX = 'connect/userInfo/';

const AUTHORIZE_POSTFIX = 'connect/authorize';

const LOGOUT_POSTFIX = 'connect/endsession'

const SCOPES = [
    'openid',
    'profile',
    'brandedtemplates',
    'careerdays',
    'educationalinstitutions',
    'employers',
    'paidservices',
    'resumes',
    'vacancies',
    'dictionaries',
    'moodle'
];

const RESPONSE_TYPE = 'id_token token';

const CLIENT_ID = 'web_app';

const authorize = redirect_uri => {
    const scope = SCOPES.join(' ');
    const nonce = 'N' + Math.random() + '' + Date.now();
    const state = Date.now() + '' + Math.random();

    const url =
        IDENTITY_URL + AUTHORIZE_POSTFIX + '?' +
        'response_type=' + encodeURI(RESPONSE_TYPE) + '&' +
        'client_id=' + encodeURI(CLIENT_ID) + '&' +
        'redirect_uri=' + encodeURI(redirect_uri) + '&' +
        'scope=' + encodeURI(scope) + '&' +
        'nonce=' + encodeURI(nonce) + '&' +
        'state=' + encodeURI(state);

    window.location.href = url;
}

const getUserInfo = access_token => {
    const url = IDENTITY_URL + USER_INFO_POSTFIX;

    const authHeader = `Bearer ${access_token}`;
    const headers = { Authorization: authHeader };

    return axios.get(url, { headers })
};

const logout = (id_token_hint, post_logout_redirect_uri) => {
    const url =
        IDENTITY_URL + LOGOUT_POSTFIX + '?' +
        'id_token_hint=' + encodeURI(id_token_hint) + '&' +
        'post_logout_redirect_uri=' + encodeURI(post_logout_redirect_uri);

    window.location.href = url;
}

export default { authorize, getUserInfo, logout }

