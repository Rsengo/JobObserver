import React from 'react';
import { Component } from 'react'
import { Switch, Route } from 'react-router-dom'
import PropTypes from 'prop-types'
import { withRouter } from 'react-router-dom'
import { block } from 'bem-cn'
import { bind } from 'decko'
import RegistrationControls  from './controls/RegistrationControls'
import { Header } from '../../header'
import RegistrationContent from './content/RegistrationContent'
import WebApiService from '../../../services/webApiService'
import roles from '../../../settings/roles'
import { Snackbar, Paper } from '@material-ui/core'

import './Registration.styl'

class Registration extends Component {
    constructor(props) {
        super(props);

        this.state = {
            snackbar: {
                opened: false,
                message: ''
            },
            user: {
                email: null,
                password: null,
                confirm_password: null,
                first_name: null,
                last_name: null,
                birth_date: null,
                area_id: null,
                gender_id: null,
                position: null,
                organization_id: null,
                role: roles.APPLICANT.id
            }
        }
    }

    @bind
    registration() {
        const { user } = this.state;
        const { role, ...data } = user;
        var service = new WebApiService();
        service.registration(role, data).then((response) => {
            window.location.href = response.data;
        }).catch(() => {
            this.handleClick({message: 'Возникла ошибка при регистрации'})
        });
    }

    // login() {
    //     const { match } = this.props;
    //     const authorizationUrl = 'http://localhost:5105/connect/authorize';
    //     const client_id = 'web_app';
    //     const redirect_uri = '/';
    //     const response_type = 'id_token token';
    //     const scope = 'openid profile';
    //     const nonce = 'N' + Math.random() + '' + Date.now();
    //     const state = Date.now() + '' + Math.random();

    //     const url =
    //         authorizationUrl + '?' +
    //         'response_type=' + encodeURI(response_type) + '&' +
    //         'client_id=' + encodeURI(client_id) + '&' +
    //         'redirect_uri=' + encodeURI(redirect_uri) + '&' +
    //         'scope=' + encodeURI(scope) + '&' +
    //         'nonce=' + encodeURI(nonce) + '&' +
    //         'state=' + encodeURI(state);

    //     window.location.href = url;
    // }

    @bind
    changeState(e) {
        this.setState({ ...this.state, user: {...this.state.user, [e.currentTarget.name]: e.currentTarget.value} });
    }

    @bind
    handleClick(state) {
        this.setState({ snackbar: {opened: true, ...state} });
    };
    
    @bind
    handleClose() {
        this.setState({ snackbar: {...this.state.snackbar, opened: false} });
    };

    render() {
        const b = block('registration')
        const { snackbar } = this.state;
        return (
            <div className={b("app")}>
            <div className={b('content_container')}>
                <Paper className='registration__app_content'>
                    <div className={b()}>
                        <div className={b('header')}>
                            <Header />
                        </div>
                        <div className={b('content')}>
                            <RegistrationContent callback={this.changeState} />
                        </div>
                        <div className={b('controls')}>
                            <RegistrationControls registrationCallback={this.registration} />
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

export default Registration