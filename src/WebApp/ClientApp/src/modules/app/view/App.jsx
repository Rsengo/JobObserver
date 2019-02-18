import React from 'react';
import { Component } from 'react'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'
import PropTypes from 'prop-types'
import { withRouter } from 'react-router-dom'

import {actions as authActions} from '../../../features/auth'
import { AuthTypes } from '../../../features/auth/redux/data/types'

import { Header } from '../../header/'
import { Footer } from '../../footer'
import { Content as ContentWorker} from '../../content/worker'
import { Content as ContentManager} from '../../content/manager'
import { Nav as NavWorker} from '../../nav/worker'
import { Nav as NavManager } from '../../nav/manager'

import './App.styl'

class App extends Component {

    static propTypes = {
        
        isAuth: PropTypes.bool.isRequired,
        user: PropTypes.object,
    }

    render() {
        const {isAuth, user, role} = this.props
        return (
                <div className='app'>
                    <Header/>
                    <div className='app__center'>
                        {isAuth ?
                            <div className='app__content'>
                                {role === AuthTypes.APP && <NavWorker/>}
                                {role === AuthTypes.COMP && <NavManager/>}
                                {role === AuthTypes.APP &&
                                <ContentWorker 
                                    user={user}
                                />}
                                {role === AuthTypes.COMP &&
                                <ContentManager 
                                    user={user}
                                />}

                            </div>
                            :
                            <div>Авторизируйтесь!</div>                        
                        }

                    </div>
                    <Footer/>
                </div>
        )
    }
}

function mapStateToProps(state) {
    return {
        user: state.auth.user,
        isAuth: state.auth.isAuth,
        role: state.auth.role,
    };
}

function mapDispatchToProps(dispatch) {
    const actions = {
        signIn: authActions.signIn,
        signUp: authActions.signUp,
        logOut: authActions.logOut,
    };
    return bindActionCreators(actions, dispatch);
}


export default withRouter(connect(
    mapStateToProps,
    mapDispatchToProps
)(App))