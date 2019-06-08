import { actionTypes } from '../actions';
import initialState from '../initial';

function reducer(state = initialState, action) {
  switch (action.type) {
    case actionTypes.ACTION_PROCESSING:
      return { ...state, actionProcessing: action.payload };

    case actionTypes.LOAD_STATISTIC_SUCCESS:
      return { ...state, statisticList: action.payload };

    case actionTypes.LOAD_FULL_EVENT_SUCCESS:
      return { ...state, event: action.payload };

    case actionTypes.CHANGE_VISIBLE_ALL_GROUPS: {
      const newCoefGroups = state.event.coefGroups.map(temp => ({ ...temp, isOpen: action.payload }));
      const newEvent = { ...state.event, coefGroups: newCoefGroups };
      return { ...state, event: newEvent };
    }

    case actionTypes.CHANGE_VISIBLE_GROUP: {
      const newCoefGroups = state.event.coefGroups.map(temp => {
        return (temp.ID === action.payload.groupID) ? { ...temp, isOpen: action.payload.visible } : temp;
      });
      const newEvent = { ...state.event, coefGroups: newCoefGroups };
      return { ...state, event: newEvent };
    }

    default:
      return state;
  }
}

export default reducer;
