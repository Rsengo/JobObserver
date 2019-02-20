import React from 'react'
import { Component } from 'react'
import { block } from 'bem-cn'
import { bind } from 'decko'
import PropTypes from 'prop-types'

import Button from '../../../../../elements/button'
import Input from '../../../../../elements/input'
import Dictionary from '../../../redux/data/dictionary'

import './VacancyForm.styl'

class VacancyForm extends Component {

    constructor(props) {
        super(props);

        this.state = {
            validation: false,
            acceptHandicapes: false,
            acceptIncompleteResumes: false,
            allowMessages: false,
            description: '',
            requiredVehicle: false,
            responseLetterRequired: false,
            responseNotification: false,
            title: '',
        }
    }

    static propTypes = {
        acceptHandicapes: PropTypes.bool.isRequired,
        acceptIncompleteResumes: PropTypes.bool.isRequired,
        allowMessages: PropTypes.bool.isRequired,
        description: PropTypes.string.isRequired,
        requiredVehicle:PropTypes.bool.isRequired,
        responseLetterRequired: PropTypes.bool.isRequired,
        responseNotification: PropTypes.bool.isRequired,
        title: PropTypes.string.isRequired,
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
    onClickListener(e) {
        const { name } = e.currentTarget;
        const newState = {};
        newState[name] = !this.state[name];
        this.setState(newState);
        this.checkValidation()
    }

    @bind
    checkValidation() {
        const { acceptHandicapes, acceptIncompleteResumes, allowMessages, description, requiredVehicle, 
            responseLetterRequired, responseNotification, title } = this.state;
        // acceptHandicapes &&  acceptIncompleteResumes && allowMessages && requiredVehicle && responseLetterRequired && responseNotification
        //  && description.length > 0 && 
         title.length > 0 ?
        this.setState({validation: true}) : this.setState({validation: false})
    }

    @bind
    handleRequestClick() {
        const { addVacancy, user } = this.props
        const { acceptHandicapes, acceptIncompleteResumes, allowMessages, description, requiredVehicle, 
            responseLetterRequired, responseNotification, title } = this.state;
        const newVacancy =  {
            accept_handicapes: acceptHandicapes,
            accept_incomplete_resumes: acceptIncompleteResumes,
            allow_messages: allowMessages,
            description: description,
            required_vehicle: requiredVehicle,
            response_letter_required: responseLetterRequired,
            response_notification: responseNotification,
            title: title,
            manager_id: user.id,
            employer_id: 1,
        }
        addVacancy(newVacancy)
    }

    render() {
        const b = block('vacancy-resume')
        const { validation, acceptHandicapes, acceptIncompleteResumes, allowMessages, description, requiredVehicle, 
            responseLetterRequired, responseNotification, title } = this.state;
        return (
            <div className={b()} onClick={this.checkValidation}>
                <div className={b('title')}>
                    {Dictionary.addedVacancy}
                </div>
                <div className={b('require')}>
                    <div className={b('require-title')}>
                        {Dictionary.require}
                    </div>
                    <div className={b('require-inputs-row')}>
                        <Input 
                            type='text'
                            size='small'
                            placeholder={Dictionary.inputTitle}
                            onChange={this.onChangeListener}
                            name='title'
                            value={title}
                        />
                        <Input 
                            type='checkbox'
                            onClick={this.onClickListener}
                            name='acceptHandicapes'
                            value={acceptHandicapes}
                            text={Dictionary.inputAcceptHandicapes}
                        />
                        <Input 
                            type='checkbox'
                            onClick={this.onClickListener}
                            name='acceptIncompleteResumes'
                            value={acceptIncompleteResumes}
                            text={Dictionary.inputAcceptIncompleteResumes}
                        />
                    </div>
                    <div className={b('require-inputs-row')}>
                        <Input 
                            type='checkbox'
                            onClick={this.onClickListener}
                            name='allowMessages'
                            value={allowMessages}
                            text={Dictionary.inputAllowMessages}
                        />
                        <Input 
                            type='checkbox'
                            onClick={this.onClickListener}
                            name='requiredVehicle'
                            value={requiredVehicle}
                            text={Dictionary.inputRequiredVehicle}
                        />
                    </div>
                    <div className={b('require-inputs-row')}>
                        <Input 
                            type='checkbox'
                            onClick={this.onClickListener}
                            name='responseLetterRequired'
                            value={responseLetterRequired}
                            text={Dictionary.inputResponseLetterRequired}
                        />
                        <Input 
                            type='checkbox'
                            onClick={this.onClickListener}
                            name='responseNotification'
                            value={responseNotification}
                            text={Dictionary.inputResponseNotification}
                        />
                        <Input 
                            type='text'
                            size='small'
                            placeholder={Dictionary.inputDescription}
                            onChange={this.onChangeListener}
                            name='description'
                            value={description}
                        />
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

export default VacancyForm