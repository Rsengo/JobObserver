import React from 'react';
import ReactDOM from 'react-dom';
import { HashRouter } from 'react-router-dom';
import 'typeface-roboto';

import { App } from './modules/app/';

ReactDOM.render((
  <HashRouter>
     <App />
  </HashRouter>
), document.getElementById('root'))
