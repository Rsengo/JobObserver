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

import './Login.styl'

class Login extends Component {
    constructor(props) {
        super(props);

        this.state = {
            email: '',
            password: ''
        }
    }

    @bind
    login() {
        const { match } = this.props;
        const { email, password } = this.state;
        
        var loginInfo = {
            email,
            password,
            remember_me: false,
            // return_url: atob(match.params.returnUrl)
        }

        var service = new WebApiService();
        service.login(loginInfo).then((response) => {
            window.location.href = response.data;
        });
    }

    @bind
    changeState(e) {
        this.setState({...this.state, [e.currentTarget.name]: e.currentTarget.value});
    }

    render() {
        var b = block('login')
        return (
            <div className={b()}>
                <div className={b('header')}>
                    <Header />
                </div>
                <div className={b('content')}>
                    {/* <LoginContent callback={this.changeState} returnUrl={this.props.match.params.returnUrl}/> */}
                    <LoginContent callback={this.changeState}/>
                </div>
                <div className={b('controls')}>
                    <LoginControls loginCallback={this.login}/>
                </div>
            </div>
        )
    }
}

export default Login