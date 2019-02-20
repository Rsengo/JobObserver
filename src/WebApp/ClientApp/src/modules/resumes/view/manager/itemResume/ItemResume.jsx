import React from 'react';
import { Component } from 'react';
import block from 'bem-cn';
import { bind } from 'decko';

import Button from '../../../../../elements/button'

import './ItemResume.styl'

class ItemResume extends Component {

    render() {
        const b = block('resume-item')
        const { resume } = this.props;
        console.log(resume)
        return (
            <div className={b()}>
                <div>
                    {resume.title}
                </div>
                <div>
                    {resume.additional_info}
                </div>
                <div>
                    Наличие транспортного средства: {resume.has_vehicle ? '+' : '-'}
                </div>
                <div>
                    {resume.area.name}
                </div>                                 
            </div>
        )
    }
}

export default ItemResume