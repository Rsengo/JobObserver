import React from 'react';
import { Component } from 'react'
import { Switch, Route } from 'react-router-dom'
import PropTypes from 'prop-types'
import { withRouter } from 'react-router-dom'
import { block } from 'bem-cn'
import { bind } from 'decko'
import LoginControls  from './controls/LoginControls'
import { Header } from '../../header'
import LoginContent from './content/LoginContent'
import WebApiService from '../../../services/webApiService'
import { Snackbar, Paper } from '@material-ui/core'

import './Login.styl'

class Login extends Component {
    constructor(props) {
        super(props);

        this.state = {
            snackbar: {
                opened: false,
                message: ''
            },
            user: {
                email: '',
                password: ''
            }
        }
    }

    @bind
    login() {
        const { match } = this.props;
        const { user } = this.state;
        const { email, password } = user;
        
        var loginInfo = {
            email,
            password,
            remember_me: false,
            return_url: match.params.returnUrl
        }

        var service = new WebApiService();
        service.login(loginInfo).then((response) => {
            window.location.href = response.data;
        }).catch(() => {
            this.handleClick({message: 'Неверный логин или пароль!'});
        });
    }

    @bind
    changeState(e) {
        this.setState({ ...this.state, user: {...this.state.user, [e.currentTarget.name]: e.currentTarget.value} });
    }

    @bind
    handleClick(state) {
        this.setState({ ...this.state, snackbar: {opened: true, ...state} });
    };
    
    @bind
    handleClose() {
        this.setState({ ...this.state, snackbar: {...this.state.snackbar, opened: false} });
    };

    render() {
        var b = block('login');
        const { snackbar } = this.state;
        return (
            <div className={b("app")}>
                <div className={b('content_container')}>
                    <Paper className='login__app_content'>
                        <div className={b()}>
                            <div className={b('header')}>
                                    <Header />
                            </div>
                            <div className={b('content')}>
                                <LoginContent callback={this.changeState}/>
                            </div>
                            <div className={b('controls')}>
                                <LoginControls loginCallback={this.login}/>
                            </div>

                            <Snackbar
                                anchorOrigin={{ vertical: 'top', horizontal: 'right' }}
                                open={snackbar.opened}
                                onClose={this.handleClose}
                                message={<span id={b('message-id')}>{snackbar.message}</span>} />
                        </div>
                    </Paper>
                </div>
            </div>
        )
    }
}

export default Login