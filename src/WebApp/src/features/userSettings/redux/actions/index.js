import BaseApi from 'shared/api/BaseApi'; 
import dayjs from 'dayjs';

// импорт локализации dayjs для языков
import 'dayjs/locale/ru';
import 'dayjs/locale/en';
import 'dayjs/locale/kk';

import { actionTypes as localeActionTypes } from 'features/locale/redux/actions';
import { shortLanguages } from 'shared/locale';

const actionTypes = {
  CHANGE_LANG: 'userSettings/CHANGE_LANG',
  LOAD_DICTIONARIES_SUCCESS: 'userSettings/LOAD_DICTIONARIES_SUCCESS',
  ACTION_FAILURE: 'userSettings/ACTION_FAILURE',
};

function changeLang(lang) {
  return async dispatch => {
    const { locale } = await import(`shared/locale/${lang}/index`); // code-spliting для словарей
    document.querySelector('html').lang = shortLanguages[lang];
    dayjs.locale(shortLanguages[lang]);
    dispatch({ type: actionTypes.CHANGE_LANG, payload: lang });
    dispatch({ type: localeActionTypes.CHANGE_LOCALE, payload: locale });
    BaseApi.setLang(lang);
  };
}

const loadDictionaries = () => async (dispatch, getState, extra) => {
  const { api } = extra;
  const response = await api.userSettings.loadDictionaries();

  if (response.success) {
    dispatch({ type: actionTypes.LOAD_DICTIONARIES_SUCCESS, payload: response.data });
  } else dispatch({ type: actionTypes.ACTION_FAILURE, payload: response.errorMessage });
};

export {
  actionTypes,
  changeLang,
  loadDictionaries,
};
