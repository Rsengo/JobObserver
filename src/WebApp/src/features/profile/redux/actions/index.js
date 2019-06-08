const actionTypes = {
  ACTION_PROCESSING: 'fullEvent/ACTION_PROCESSING',
  LOAD_FULL_EVENT_SUCCESS: 'fullEvent/LOAD_FULL_EVENT_SUCCESS',
  LOAD_STATISTIC_SUCCESS: 'fullEvent/LOAD_STATISTIC_SUCCESS',
  CHANGE_VISIBLE_ALL_GROUPS: 'fullEvent/CHANGE_VISIBLE_ALL_GROUPS',
  CHANGE_VISIBLE_GROUP: 'fullEvent/CHANGE_VISIBLE_GROUP',
  ACTION_FAILURE: 'fullEvent/ACTION_FAILURE',
};

function loadApplicantProfile(eventID, lang, mainEventID) {
  return async (dispatch, getState, extra) => {
    const { api } = extra;
    dispatch({ type: actionTypes.ACTION_PROCESSING, payload: true });
    const response = await api.fullEvent.loadFullEventLine(eventID, lang);
    const fullEvent = response.data;

    if (response.success) {
      dispatch({ type: actionTypes.LOAD_FULL_EVENT_SUCCESS, payload: response.data });
    } else dispatch({ type: actionTypes.ACTION_FAILURE, payload: response.errorMessage });
  };
}

export {
  actionTypes,
  loadApplicantProfile,
};
