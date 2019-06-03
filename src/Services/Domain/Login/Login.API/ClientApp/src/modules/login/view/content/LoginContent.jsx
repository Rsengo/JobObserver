import React from 'react';
import { Component } from 'react'
import { block } from 'bem-cn'
import { bind } from 'decko'
import { Visibility, VisibilityOff } from '@material-ui/icons'
import { 
    TextField, 
    InputAdornment, 
    IconButton,
    FormControlLabel,
    Checkbox
} from '@material-ui/core'


import './LoginContent.styl'

class LoginContent extends Component {
    constructor(props) {
        super(props);

        this.state = {
            showPassword: false,
            rememberMe: false
        };
    }

    @bind
    handleClickShowPassword() {
        this.setState({ ...this.state, showPassword: !this.state.showPassword });
    };

    render() {
        const { callback } = this.props

        var b = block('login_content')
        return (
            <div className={b()}>
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
                <FormControlLabel
                  control={
                    <Checkbox
                      inputProps={{name: 'remember_me'}}
                      onChange={callback}
                      value={this.state.rememberMe}
                      color="primary"
                    />
                  }
                  label="Remember me"
                  labelPlacement="start"
                />
            </div>
        )
    }
}

export default LoginContent