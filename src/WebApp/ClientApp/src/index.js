import React from 'react';
import ReactDOM from 'react-dom';
import {HashRouter } from 'react-router-dom';
import { Provider } from 'react-redux';
// import { ConnectedRouter } from 'react-router-redux';
// import { createBrowserHistory } from 'history';
import { store } from './store/configureStore'

import {App} from './modules/app/';

ReactDOM.render((
  <Provider store={store}>
    <HashRouter>
      <App />
    </HashRouter>
  </Provider>
), document.getElementById('root'))
