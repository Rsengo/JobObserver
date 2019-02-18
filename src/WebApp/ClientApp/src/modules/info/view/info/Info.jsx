import React from 'react';
import { Component } from 'react';

import {infoText} from '../../redux/data/dictionary'
import './Info.styl'

class Info extends Component {
    render() {
        return (
            <div className='info'>{infoText[0].ru}</div>
        )
    }
}

export default Info