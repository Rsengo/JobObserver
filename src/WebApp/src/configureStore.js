import {
  compose,
  applyMiddleware,
  combineReducers,
  createStore,
} from 'redux';
import thunk from 'redux-thunk';
import persistState from 'redux-localstorage';

import { reducer as localeReducer } from './features/locale';
import { reducer as userSettingsReducer } from './features/userSettings';
import { reducer as authReducer } from './features/auth';
import { reducer as notifyReducer } from './features/notify';
import { reducer as profileReducer } from './features/profile';
import { reducer as resumeReducer } from './features/resumes';
import { reducer as vacancyReducer } from './features/vacancies';

function configureStore(extra) {
  const middlewares = [
    thunk.withExtraArgument(extra),
  ];

  const reducer = createReducer();

  // TODO: отключить devtools в production
  const store = createStore(
    reducer,
    compose(
      applyMiddleware(...middlewares),
      persistState('userSettings'),
      window.__REDUX_DEVTOOLS_EXTENSION__ ? window.__REDUX_DEVTOOLS_EXTENSION__() : (arg => arg),
    ),
  );

  return store;
}

function createReducer() {
  return combineReducers({
    userSettings: userSettingsReducer,
    auth: authReducer,
    notify: notifyReducer,
    locale: localeReducer,
    profile: profileReducer,
    resume: resumeReducer,
    vacancy: vacancyReducer,
  });
}


export { createReducer };
export default configureStore;
