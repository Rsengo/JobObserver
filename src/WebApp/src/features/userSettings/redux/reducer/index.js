import { initialState } from '../initial';
import { actionTypes } from '../actions';

export function reducer(state = initialState, action) {
  switch (action.type) {
    case actionTypes.CHANGE_LANG:
      return {
        ...state,
        lang: action.payload,
      };

    case actionTypes.LOAD_DICTIONARIES_SUCCESS:
      return {
        ...state,
        dictionaries: action.payload,
      };

    default:
      return { ...state };
  }
}