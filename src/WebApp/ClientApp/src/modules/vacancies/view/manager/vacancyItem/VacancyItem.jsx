import React from 'react';
import { Component } from 'react';
import block from 'bem-cn';
import { bind } from 'decko';

import Button from '../../../../../elements/button'

import './VacancyItem.styl'

class VacancyItem extends Component {

    constructor(props) {
        super(props);

        this.state = {
            isOpen: false,
        }
    }

    @bind
    handleClickOpen() {
        this.setState({
            isOpen: !this.state.isOpen,
        })
    }

    render() {
        const b = block('vacancy-item')
        const { vacancy } = this.props;
        const bottomBlock = <div className={b({position : 'bottom'})}>
            <div className={b('discription')}>{vacancy.description}</div>
        </div>
        return (
            <div key={vacancy.id} className={b( {}, {open: this.state.isOpen}, {close: !this.state.isOpen})}>
                <div className={b('container')}>
                    <div className={b({position : 'top'})}>
                        <div className={b({ position : 'left'})}>
                            <div className={b('name')}>{vacancy.title}</div>
                            <div className={b('salary')}>{vacancy.salary}</div>
                            <div className={b('company')}>{vacancy.company}</div>
                        </div>
                        <div className={b({ position : 'right'})}>
                            <Button
                                value={this.state.isOpen ? 'Close' : 'Open'}
                                color={!this.state.isOpen ? 'green' :'gray'}
                                size={'small'}
                                onClick={this.handleClickOpen}
                            />
                            <div className={b('date')}>{vacancy.published_at}</div>
                        </div>
                    </div>
                    {this.state.isOpen && bottomBlock}
                </div>
            </div>            
        )
    }
}

export default VacancyItem