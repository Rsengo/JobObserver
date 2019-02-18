import React from 'react';
import { Component } from 'react';
import block from 'bem-cn';

import ItemResume from '../itemResume/ItemResume'

import './ListResume.styl'

class ListResume extends Component {
    render() {
        const b = block('resume-list')
        const { resumes } = this.props;
        const resumeList = resumes.map(resume =>
            <ItemResume resume={resume} />
        )
        return (
            <div className={b()}>{resumeList}</div>
        )
    }
}

export default ListResume