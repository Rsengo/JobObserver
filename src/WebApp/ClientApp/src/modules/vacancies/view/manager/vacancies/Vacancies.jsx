import React from 'react';
import { Component } from 'react';
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'
import block from 'bem-cn';
import { bind } from 'decko';

import { actions as vacanciesActions } from '../../../'
import VacancyList from '../vacancyList/VacancyList'
import VacancyForm from '../vacancyForm/VacancyForm'

import './Vacancies.styl'

class Vacancies extends Component {
    constructor(props) {
        super(props);

        this.state ={
            startIndexViewVacancies: 0,
            amountViewVacancies: 8,
        }
    }

    componentWillMount() {
        const { loadAllVacancies } = this.props;
        loadAllVacancies();
    }

    render() {
        const b = block('vacancies');
        const { vacancies, addVacancy, user } = this.props;
        return (
            <div className={b()}>
                <div className={b('left-container')}>
                    <VacancyList vacancies={vacancies} />
                </div>
                <div className={b('right-container')}>
                    <VacancyForm addVacancy={addVacancy} user={user} />
                </div>
            </div>
        )
    }
}

function mapStateToProps(state) {
    return {
        vacancies: state.vacancies.vacancies,
        user: state.auth.user,
    }
}

function mapDispatchToProps(dispatch) {
    const actions = {
        loadTestVacancies: vacanciesActions.loadTestVacancies,
        loadAllVacancies: vacanciesActions.loadAllVacancies,
        addVacancy: vacanciesActions.addVacancy,
    }
    return bindActionCreators(actions, dispatch)
}

export default connect(mapStateToProps, mapDispatchToProps)(Vacancies)