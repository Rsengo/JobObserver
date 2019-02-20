import React from 'react';
import { Component } from 'react';
import { Route, Switch } from 'react-router-dom';

import {Vacancies} from '../../../vacancies/worker'
import {Resumes} from '../../../resumes/worker'
import {Profile} from '../../../profile/worker'
import {Info} from '../../../info'

import './Content.styl'

class Content extends Component {
    render() {
        const {user} = this.props
        const profileWrapper = props => <Profile {...props} user={user}/>
        return (
            <div className='content'>
                <Switch >
                    <Route path='/vacancies' component={Vacancies} />
                    <Route path='/resumes' component={Resumes} />
                    <Route path='/profile' component={profileWrapper} />
                    <Route path='/info' component={Info} />
                </Switch>
            </div>
        )
    }
}

export default Content