import { addNotify } from 'features/notify';
import { shortLanguages } from 'shared/locale';

const actionTypes = {
  GET_SPORTS: 'sportMenu/GET_SPORTS',
  ACTION_PROCESSING: 'sportMenu/ACTION_PROCESSING',
  ACTION_FAILURE: 'sportMenu/ACTION_FAILURE',
  GET_COUNTRIES: 'sportMenu/GET_COUNTRIES',
  ACTION_PROCESSING_COUNRIES: 'sportMenu/ACTION_PROCESSING_COUNRIES',
  CLEAR_COUNTRIES: 'sportMenu/CLEAR_COUNTRIES',
};

function getSports() {
  return async (dispatch, getState, extra) => {
    const { api } = extra;
    const { lang } = getState().userSettings;
    dispatch({ type: actionTypes.ACTION_PROCESSING });
    const response = await api.sportMenu.getSports(shortLanguages[lang]);
    if (response.success) {
      dispatch({ type: actionTypes.GET_SPORTS, payload: response.data });
    } else {
      dispatch({ type: actionTypes.ACTION_FAILURE });
      dispatch(addNotify('Line error', 'error'));
    }
  };
}

function collapseSport(id) {
  return async (dispatch, getState, extra) => {
    const { api } = extra;
    const { lang } = getState().userSettings;
    const collapsedID = getState().sportMenu.collapsedID === id ? null : id;
    dispatch({ type: actionTypes.ACTION_PROCESSING_COUNRIES, payload: collapsedID });
    const response = await api.sportMenu.getCountries(id, shortLanguages[lang]);
    if (response.success) {
      dispatch({ type: actionTypes.CLEAR_COUNTRIES });
      dispatch({ type: actionTypes.GET_COUNTRIES, payload: response.data });
    } else {
      dispatch({ type: actionTypes.ACTION_FAILURE });
      dispatch(addNotify('Line error', 'error'));
    }
  };
}

export {
  actionTypes,
  getSports,
  collapseSport,
};
