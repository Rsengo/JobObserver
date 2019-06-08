import { initialState } from '../initial';
import { actionTypes } from '../actions';

export function reducer(state = initialState, action) {
  switch (action.type) {
    case actionTypes.SIGN_IN_SUCCESS: {
      return {
        ...state,
        isAuth: true,
      };
    }
    default: {
      return state;
    }
  }
}