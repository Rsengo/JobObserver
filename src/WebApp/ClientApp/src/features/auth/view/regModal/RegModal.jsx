import React from 'react'
import { Component } from 'react'
import { block } from 'bem-cn'
import { bind } from 'decko'

import Button from '../../../../elements/button'

import './RegModal.styl'

class RegModal extends Component {

    @bind
    handleSignInClick() {
        this.props.signIn(1);
    }

    @bind
    handleSignUpClick() {
        this.props.signUp(1);
    }

    @bind
    handleLogOutClick() {
        this.props.logOut();
    }

    render() {
        const b = block('reg-modal')
        return (
            <div className={b()}>
            
            </div>
        )
    }
}

export default RegModal