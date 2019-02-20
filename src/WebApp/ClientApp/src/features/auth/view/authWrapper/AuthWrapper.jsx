import React from 'react'
import { Component } from 'react'
import { block } from 'bem-cn'
import { bind } from 'decko'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'
import PropTypes from 'prop-types'

import {actions as authActions} from '../../'

import Button from '../../../../elements/button'
import AuthModal from '../authModal/AuthModal'
import RegModal from '../regModal/RegModal'

import './AuthWrapper.styl'
import { AuthTypes } from '../../redux/data/types';

class AuthWrapper extends Component {

    static propTypes = {
        switchViewRegModal: PropTypes.func.isRequired,
        switchViewAuthModal: PropTypes.func.isRequired,
        role: PropTypes.string,        
    }

    @bind
    handleSignInClick() {
        const {switchViewAuthModal, switchViewRegModal, isOpenAuthModal} = this.props;
        switchViewAuthModal(!isOpenAuthModal);
        switchViewRegModal(false);
    }

    @bind
    handleSignUpClick() {
        const {switchViewRegModal, switchViewAuthModal, isOpenRegModal} = this.props;
        switchViewRegModal(!isOpenRegModal);
        switchViewAuthModal(false);
    }

    @bind
    handleLogOutClick() {
        this.props.logOut();
    }

    render() {
        const b = block('auth-wrapper')
        const {isAuth, user, isOpenAuthModal, isOpenRegModal, role} = this.props
        const tempRole = role === AuthTypes.UN ? 'Менеджер Университета' : role === AuthTypes.COMP ? 'Менеджер Компании' : 'Соискатель'
        return (
            <div className={b()}>
                {isOpenAuthModal && <AuthModal />}
                {isOpenRegModal && <RegModal />}
                {isAuth && <div className={b('name')}>{user.first_name} {user.last_name} <br></br> {tempRole}</div>}
                <Button
                    value={isAuth ? 'Выйти' : 'Войти'}
                    color='green'
                    onClick={isAuth ? this.handleLogOutClick : this.handleSignInClick}
                    size='small'
                />
                { !isAuth && 
                <Button
                    value='Регистрация'
                    color='gray'
                    onClick={this.handleSignUpClick}
                    size='middle'
                />}
            </div>
        )
    }
}

function mapStateToProps(state) {
    return {
        isOpenAuthModal: state.auth.isOpenAuthModal,
        isOpenRegModal: state.auth.isOpenRegModal,
        isAuth: state.auth.isAuth,
        user: state.auth.user,
        role: state.auth.role,
    }
}

function mapDispatchToProps(dispatch) {
    const actions = {
        signIn: authActions.signIn,
        logOut: authActions.logOut,
        switchViewAuthModal: authActions.switchViewAuthModal,
        switchViewRegModal: authActions.switchViewRegModal,        
    };
    return bindActionCreators(actions, dispatch);
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(AuthWrapper)