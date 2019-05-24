import React from 'react';
import { Component } from 'react'
import PropTypes from 'prop-types'
import { withRouter } from 'react-router-dom'
import { block } from 'bem-cn'
import { bind } from 'decko'
import { Visibility, VisibilityOff } from '@material-ui/icons'
import { 
    TextField, 
    InputAdornment, 
    IconButton,
    MuiThemeProvider
} from '@material-ui/core'
import { textFieldsTheme } from '../../../../styles'


import './LoginContent.styl'

class LoginContent extends Component {
    constructor(props) {
        super(props);

        this.state = {
            showPassword: false,
        };
    }

    @bind
    handleClickShowPassword() {
        this.setState({ ...this.state, showPassword: !this.state.showPassword });
    };

    render() {
        const { callback, returnUrl } = this.props

        var b = block('login_content')
        return (
            <div className={b()}>
            {/* <form action='http://localhost:5105/account/login' method="post"> */}
              <MuiThemeProvider theme={textFieldsTheme}>
                <TextField
                    id='email-input'
                    label='Email'
                    type='email'
                    name='email'
                    autoComplete='email'
                    margin='normal'
                    onChange={callback}
                    variant='outlined'/>

                <TextField
                    id='password-input'
                    label='Password'
                    type={this.state.showPassword ? 'text' : 'password'}
                    name = 'password'
                    autoComplete='current-password'
                    margin='normal'
                    onChange={callback}
                    InputProps={{
                        endAdornment: (
                          <InputAdornment position="end">
                            <IconButton
                              aria-label="Toggle password visibility"
                              onClick={this.handleClickShowPassword}
                            >
                              {this.state.showPassword ? <VisibilityOff /> : <Visibility />}
                            </IconButton>
                          </InputAdornment>
                        )
                      }}
                    variant='outlined'/>
                    {/* <input name='rememberme' value='true'/>
                    <input name='returnurl' value={atob(returnUrl)}/>
                    <button type='submit'>zazazaz</button>
            </form> */}
              </MuiThemeProvider>
            </div>
        )
    }
}

export default LoginContent