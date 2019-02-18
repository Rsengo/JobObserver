import React from 'react';
import { Component } from 'react';
import block from 'bem-cn'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'

import { actions as resumesActions } from '../../../'
import ListResume from '../listResume/ListResume'

import './Resumes.styl'

class Resumes extends Component {
    render() {
        const b = block('resumes') 
        const {  resumes, user } = this.props
        return (
            <div className={b()}>
                <ListResume resumes={resumes}/>
            </div>
        )
    }
}

function mapStateToProps(state) {
    return {
        resumes: state.resumes.resumes,
        user: state.auth.user,
    }
}

function mapDispatchToProps(dispatch) {
    const actions = {
        addResume: resumesActions.addResume,
        loadUserResumes: resumesActions.loadUserResumes,
    };
    return bindActionCreators(actions, dispatch);
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(Resumes)