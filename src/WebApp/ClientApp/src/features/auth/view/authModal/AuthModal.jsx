import React from 'react'
import { Component } from 'react'
import { block } from 'bem-cn'
import { bind } from 'decko'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'

import {actions as authActions} from '../../'

import Button from '../../../../elements/button'
import { AuthTypes } from '../../redux/data/types'

import './AuthModal.styl'

class AuthModal extends Component {

    constructor(props) {
        super(props);

        this.state = {
            role: AuthTypes.APP,
            login: '',
            password:'',
        }
    }

    @bind
    handleSignInClick() {
        const { role, login, password } = this.state;
        this.props.signIn( role, login, password );
        this.props.switchViewAuthModal(false)
    }

    @bind
    handleSwitchRoleClick( type ) {
        this.setState({
            role: type,
        })
    }

    render() {
        const b = block('auth-modal')
        return (
            <div className={b()}>
                <div className={b('close')} onClick={() => this.props.switchViewAuthModal(false)}>
                    x
                </div>
                <div className={b('container-button')}>
                    <Button
                        value={'Менеджер вуза'}
                        color={this.state.role === AuthTypes.UN ? 'orange' : 'green'}
                        onClick={() => this.handleSwitchRoleClick(AuthTypes.UN)} 
                        size='middle'
                    />
                    <Button
                        value={'Менеджер компании'}
                        color={this.state.role === AuthTypes.COMP ? 'orange' : 'green'}
                        onClick={() => this.handleSwitchRoleClick(AuthTypes.COMP)} 
                        size='middle'
                    />
                    <Button
                        value={'Соискатель'}
                        color={this.state.role === AuthTypes.APP ? 'orange' : 'green'}
                        onClick={() => this.handleSwitchRoleClick(AuthTypes.APP)} 
                        size='middle'
                    />
                </div>         
                <div className={b('sign-in')}>
                    <Button
                        value={'Войти'}
                        color='green'
                        onClick={this.handleSignInClick} 
                        size='big'
                    />                         
                </div>          
            </div>
        )
    }
}

function mapStateToProps(state) {
    return {

    }
}

function mapDispatchToProps(dispatch) {
    const actions = {
        signIn: authActions.signIn,
        switchViewAuthModal: authActions.switchViewAuthModal,
    };
    return bindActionCreators(actions, dispatch);
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(AuthModal)