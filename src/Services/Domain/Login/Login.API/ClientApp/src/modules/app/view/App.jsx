import React from 'react';
import { Component } from 'react'
import { Switch, Route } from 'react-router-dom'
import PropTypes from 'prop-types'
import { withRouter } from 'react-router-dom'
import { Paper } from '@material-ui/core'
import { block } from 'bem-cn'

import { Login } from '../../login'
import { Registration } from '../../registration'

import './App.styl'

const App = () => {
    var b = block('app')
        return (
            <div className={b()}>
                <div className={b('content_container')}>
                    <Paper className='app__content'>
                        <Switch>
                            <Route path='/login/:returnUrl' component={ Login }/>
                            <Route path='/registration/:returnUrl' component={ Registration }/>
                        </Switch>
                    </Paper>
                </div>
            </div>
)}

export default App