import React from 'react';
import ReactDOM from 'react-dom';
import { HashRouter } from 'react-router-dom';
import 'typeface-roboto';
import { MuiThemeProvider } from '@material-ui/core'
import { textFieldsTheme } from './styles'

import { App } from './modules/app/';

ReactDOM.render((
  <HashRouter>
    <MuiThemeProvider theme={textFieldsTheme}>
      <App />
    </MuiThemeProvider>
  </HashRouter>
), document.getElementById('root'))
