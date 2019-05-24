import React from 'react'
import { Component } from 'react'
import { block } from 'bem-cn'
import { bind } from 'decko'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'

import {actions as authActions} from '../../'

import CheckBox from '../../../../elements/CheckBox/desktop';
import Input from '../../../../elements/Input/desktop';
import Button from '../../../../elements/Button/desktop';
import { AuthTypes } from '../../redux/data/types'

import './AuthModal.styl'

class AuthModal extends Component {

    constructor(props) {
        super(props);

        this.state = {
            login: '',
            password:'',
            rememberMe: false,
        }
    }

    @bind
    handleSignInClick() {
        const { login, password, rememberMe } = this.state;
        this.props.signIn( login, password, rememberMe );
        this.props.switchViewAuthModal(false)
    }

    @bind
    handleSwitchRoleClick( type ) {
        this.setState({
            role: type,
        })
    }

    changeState = (e) => {
        this.setState({
            [e.currentTarget.name]: e.currentTarget.value,
        })
    }

    changeChecked = value => this.setState({ rememberMe: value })

    render() {
        const b = block('auth-modal')
        const { login, password, rememberMe } = this.state;
        return (
            <div className={b()}>
                <div className={b('close')} onClick={() => this.props.switchViewAuthModal(false)}>
                    x
                </div>
                <div className={b('input')}>
                    <Input value={login} name="login" callBack={this.changeState} placeholder="Login" />
                </div>
                <div className={b('input')}>
                    <Input value={password} name="password" callBack={this.changeState} placeholder="Password" />
                </div>
                <div className={b('check-box')}>
                    {`Remember password  `}<CheckBox checked={rememberMe} callBack={this.changeChecked} />
                </div>
                <div className={b('input')}>
                </div>  
                <div className={b('sign-in')}>
                    <Button
                        text={'Войти'}
                        color='blue'
                        callBack={this.handleSignInClick}
                        disabled={!(password.length !== 0 && login.length !== 0)} 
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