import React from 'react'
import { Component } from 'react'
import { block } from 'bem-cn'
import { bind } from 'decko'
import PropTypes from 'prop-types'

import Button from '../../../../../elements/button'
import Input from '../../../../../elements/input'
import Dictionary from '../../../redux/data/dictionary'

import './FormResume.styl'

class FormResume extends Component {

    constructor(props) {
        super(props);

        this.state = {
            validation: false,
            title: '',
            additional_info: '',
            has_vehicle: '',
            arg4: '',
        }
    }

    static propTypes = {
        validation: PropTypes.bool.isRequired,
        title: PropTypes.string,
        additional_info: PropTypes.string,
        has_vehicle: PropTypes.bool,
    }

    @bind
    onChangeListener(e) {
        const { value, name } = e.currentTarget;
        const newState = {};
        newState[name] = value;
        this.setState(newState);
        this.checkValidation()
    }

    @bind
    checkValidation() {
        const { title, additional_info, has_vehicle, arg4 } = this.state;
        title !== '' && 
        additional_info !== '' &&
        has_vehicle &&
        arg4 !== '' ?
        this.setState({validation: true}) : this.setState({validation: false})
    }

    @bind
    onClickListener(e) {
        const { name } = e.currentTarget;
        const newState = {};
        newState[name] = !this.state[name];
        this.setState(newState);
        this.checkValidation()
    }

    @bind
    handleRequestClick() {
        const { addResume, user } = this.props
        const { title, additional_info, has_vehicle, arg4 } = this.state
        const newResumes =  {
            title: title,
            additional_info: additional_info,
            has_vehicle: has_vehicle,
            arg4: arg4,
            applicant_id: 2,
            area_id: 761
        }
        addResume(newResumes, user.id)

    }

    render() {
        const b = block('form-resume')
        const { validation, title, additional_info, has_vehicle, arg4 } = this.state;
        return (
            <div className={b()} onClick={this.checkValidation}>
                <div className={b('title')}>
                    {Dictionary.addedResume}
                </div>
                <div className={b('require')}>
                    <div className={b('require-title')}>
                        {Dictionary.require}
                    </div>
                    <div className={b('require-inputs-row')}>
                        <Input 
                            type='text'
                            size='big'
                            placeholder={Dictionary.inputTitle}
                            onChange={this.onChangeListener}
                            name='title'
                            value={title}
                        />
                        <Input 
                            type='text'
                            size='big'
                            placeholder={Dictionary.inputTitle}
                            onChange={this.onChangeListener}
                            name='additional_info'
                            value={additional_info}
                        />
                    </div>
                    <div className={b('require-inputs-row')}>
                        <Input 
                            type='checkbox'
                            text={Dictionary.inputTitle}
                            onClick={this.onClickListener}
                            name='has_vehicle'
                            value={has_vehicle}
                        />
                        <Input 
                            type='text'
                            size='big'
                            placeholder={Dictionary.inputTitle}
                            onChange={this.onChangeListener}
                            name='arg4'
                            value={arg4}
                        />                    
                    </div>
                    <div className={b('require-inputs-row')}>
                        {/* <Input 
                            type='text'
                            size='big'
                            placeholder={Dictionary.inputTitle}
                            onChange={this.onChangeListener}
                            name='arg5'
                            value={arg5}
                        />
                        <Input 
                            type='text'
                            size='big'
                            placeholder={Dictionary.inputTitle}
                            onChange={this.onChangeListener}
                            name='arg6'
                            value={arg6}
                        />               */}
                    </div>
                    <div className={b('require-validation', { valid : validation ? 'true' : 'false'})}>
                        {validation ? 'L' : 'X'}
                    </div>
                </div>
                <div className={b('unrequire')}>
                    <div className={b('unrequire-title')}>
                        {Dictionary.unrequire}
                    </div>
                </div>
                <div className={b('request')}>
                    <Button 
                        value={Dictionary.add}
                        color='green'
                        onClick={this.handleRequestClick}
                        size='middle'
                        isDisabled={!validation}
                    />
                </div>

            </div>
        )
    }
}

export default FormResume