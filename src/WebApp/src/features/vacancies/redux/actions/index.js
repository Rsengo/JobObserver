import { addNotify } from 'features/notify';

const actionTypes = {
  ACTION_PROCESSING: 'resumes/ACTION_PROCESSING',
  LOAD_USER_RESUMES_SUCCESS: 'resumes/LOAD_USER_RESUMES_SUCCESS',
  LOAD_RESUME_SUCCESS: 'resumes/LOAD_RESUME_SUCCESS',
  ACTION_FAILURE: 'resumes/ACTION_FAILURE',
};

const loadCompanyVacancy = () => async (dispatch, getState, extra) => {
  const { api } = extra;
  const { userID } = getState().auth;
  dispatch({ type: actionTypes.ACTION_PROCESSING, payload: true });
  const response = await api.vacancy.loadCompanyVacancy(userID);

  if (response.success) {
    dispatch({ type: actionTypes.LOAD_FULL_EVENT_SUCCESS, payload: response.data });
  } else dispatch({ type: actionTypes.ACTION_FAILURE, payload: response.errorMessage });
};

const loadVacancyyID = resumeID => async (dispatch, getState, extra) => {
  const { api } = extra;
  dispatch({ type: actionTypes.ACTION_PROCESSING, payload: true });
  const response = await api.resume.loadVacancyyID(resumeID);

  if (response.success) {
    dispatch({ type: actionTypes.LOAD_RESUME_SUCCESS, payload: response.data });
  } else dispatch({ type: actionTypes.ACTION_FAILURE, payload: response.errorMessage });
};

const updateResume = (resumeID, resume) => async (dispatch, getState, extra) => {
  const { api } = extra;
  dispatch({ type: actionTypes.ACTION_PROCESSING, payload: true });
  const response = await api.resume.updateResume(resumeID, resume);
  dispatch({ type: actionTypes.ACTION_PROCESSING, payload: false });

  if (response.success) dispatch(addNotify('Ваше резюме успешно обновлено', 'success'));
  else dispatch(addNotify('Ошибка при обновлении резюме', 'error'));

  // if (response.success) {
  //   dispatch({ type: actionTypes.LOAD_RESUME_SUCCESS, payload: response.data });
  // } else dispatch({ type: actionTypes.ACTION_FAILURE, payload: response.errorMessage });
};

export {
  actionTypes,
  loadCompanyVacancy,
  loadVacancyyID,
  updateResume,
};
