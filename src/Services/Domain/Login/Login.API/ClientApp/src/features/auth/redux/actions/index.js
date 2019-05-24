import axios from 'axios';
import { AuthTypes } from '../data/types'

const actionTypes = {
    SIGN_IN: 'SIGN_IN',
    SIGN_UP: 'SIGN_UP',
    LOG_OUT: 'LOG_OUT',
    SWITCH_VIEW_AUTH_MODAL: 'SWITCH_VIEW_AUTH_MODAL',
    SWITCH_VIEW_REG_MODAL: 'SWITCH_VIEW_REG_MODAL',
    SIGN_IN_UN: 'SIGN_IN_UN',
    SIGN_IN_COMP: 'SIGN_IN_COMP',
    SIGN_IN_APP: 'SIGN_IN_APP',
};

function signIn(login, password, rememberMe) {
    return async dispatch => {
        const userData = {
            login,
            password,
            rememberMe,
        };

        const url = '/api/user/auth';
        const user = await axios.post(url, userData)

        dispatch({
        // return {
            type: actionTypes.SIGN_IN,
            payload: user.data,
        // }
        })
    }
}

function logOut() {
    return {
        type: actionTypes.LOG_OUT,
        payload: {},
    }
}

function switchViewAuthModal(visible) {
    return {
        type: actionTypes.SWITCH_VIEW_AUTH_MODAL,
        payload: visible,
    }
}

function switchViewRegModal(visible) {
    return {
        type: actionTypes.SWITCH_VIEW_REG_MODAL,
        payload: visible,
    }
}

export {
    actionTypes,
    signIn,
    logOut,
    switchViewAuthModal,
    switchViewRegModal,
}