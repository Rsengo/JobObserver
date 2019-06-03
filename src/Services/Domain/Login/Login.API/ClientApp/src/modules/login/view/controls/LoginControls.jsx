import React from 'react';
import { Component } from 'react'
import PropTypes from 'prop-types'
import { withRouter } from 'react-router-dom'
import { block } from 'bem-cn'
import { Button } from '@material-ui/core'
import { Link } from 'react-router-dom'


import './LoginControls.styl'

const LoginControls = ({ loginCallback }) => {
    const b = block('login_controls');
    const registrationUrl = `/registration/${btoa(window.location.href)}`
        return (
            <div className={b()}>
                <div className={b('registration_button_block')}>
                    <Button color="secondary" >
                        <Link 
                            className={b('registration_link')} 
                            to={registrationUrl}>
                                Регистрация
                        </Link>
                    </Button>
                </div>
                <div className={b('login_button_block')}>
                    <Button 
                        variant="contained" 
                        color="primary"
                        onClick={loginCallback}>
                        Войти
                    </Button>
                </div>
            </div>
        )
}

export default LoginControls