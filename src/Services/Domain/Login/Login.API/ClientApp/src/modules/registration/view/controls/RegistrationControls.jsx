import React from 'react';
import { Component } from 'react'
import PropTypes from 'prop-types'
import { withRouter } from 'react-router-dom'
import { block } from 'bem-cn'
import { Button } from '@material-ui/core'


import './RegistrationControls.styl'

class RegistrationControls extends Component {
    render() {
        const { registrationCallback, loginCallback } = this.props;
        
        var b = block('registration_controls');
        return (
            <div className={b()}>
                <div className={b('login_button_block')}>
                    {/* <Button color="secondary" >
                        Войти
                    </Button> */}
                </div>
                <div className={b('registration_button_block')}>
                    <Button 
                        variant="contained" 
                        color="primary"
                        onClick={registrationCallback}>
                        Регистрация
                    </Button>
                </div>
            </div>
        )
    }
}

export default RegistrationControls