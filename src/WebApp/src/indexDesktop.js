import '@babel/polyfill';

import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { BrowserRouter } from 'react-router-dom';

import configureStore from './configureStore';
import App from './modules/App/desktop';

import { VacanciesModule, ResumesModule, ProfileModule } from './modules/desktop';

import './shared/style/desktop.scss';

import Api from './shared/api';
import { createRoutes } from './createRoutes';

const apiUrl = window.location.href.includes('localhost') ? 'http://31.211.116.12' : '';
const api = new Api(apiUrl);

const modules = [
  new VacanciesModule(),
  new ResumesModule(),
  new ProfileModule(),
];
const childrens = createRoutes(modules);

const store = configureStore({ api });

ReactDOM.render(
  <Provider store={store}>
    <BrowserRouter>
      <App>
        {childrens}
      </App>
    </BrowserRouter>
  </Provider>, document.getElementById('root'),
);