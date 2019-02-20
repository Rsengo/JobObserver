import React from 'react';
import { Component } from 'react';
import block from 'bem-cn'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'

import { actions as resumesActions } from '../../../'
import FormResumes from '../formResume/FormResume'
import ListResume from '../listResume/ListResume'

import './Resumes.styl'

class Resumes extends Component {

    componentWillMount() {
        const { loadAllResumes } = this.props
        loadAllResumes()
    }
    
    render() {
        const b = block('resumes') 
        const { loadUserResumes, addResume, resumes, user } = this.props
        return (
            <div className={b()}>
                <div className={b('left-container')}>
                    <ListResume resumes={resumes}/>
                </div>
                <div className={b('right-container')}>
                    <FormResumes addResume={addResume} user={user}/>
                </div>
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
        loadAllResumes: resumesActions.loadAllResumes,
    };
    return bindActionCreators(actions, dispatch);
}

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(Resumes)