const actionTypes = {
  SIGN_IN_SUCCESS: 'auth/SIGN_IN',
  SIGN_UP_SUCCESS: 'auth/SIGN_UP',
  LOG_OUT: 'auth/LOG_OUT',
  ACTION_FAILURE: 'auth/ACTION_FAILURE',
};

function signIn(phone, password) {
  return async (dispatch, getState, extra) => {
    const { api } = extra;
    const response = await api.auth.signIn(phone, password);
    if (response.success) {
      dispatch({ type: actionTypes.SIGN_IN_SUCCESS });
    } else {
      dispatch({ type: actionTypes.ACTION_FAILURE });
    }
  };
}

function sendToPhoneCode(phone, callBack) {
  return async (dispatch, getState, extra) => {
    const { api } = extra;
    const response = api.auth.sendToPhoneCode(phone);
    if (response.success) callBack();
  };
}

export {
  actionTypes,
  signIn,
  sendToPhoneCode,
};