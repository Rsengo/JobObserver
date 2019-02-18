import React from 'react';
import { Component } from 'react';
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'
import block from 'bem-cn';
import { bind } from 'decko';

import { actions as vacanciesActions } from '../../../'
import VacancyList from '../vacancyList/VacancyList'

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

    @bind 
    handleBackIndex() {
        this.setState({
            startIndexViewVacancies: this.state.startIndexViewVacancies - this.state.amountViewVacancies,
        })
    }

    @bind 
    handleNextIndex() {
        this.setState({
            startIndexViewVacancies: this.state.startIndexViewVacancies + this.state.amountViewVacancies,
        })
    }

    render() {
        const b = block('vacancies');
        const { vacancies } = this.props;
        const viewVacancies = vacancies.reduce(
            (newArray, temp, index) => ((index >= this.state.startIndexViewVacancies) && (index < this.state.startIndexViewVacancies + this.state.amountViewVacancies)) ?
            [...newArray,temp] : newArray,[] 
        )
        return (
            <div className={b()}>
                <div className={b('arrow-container')}>
                    <div className={b('arrow', {direction : 'left'})}
                        onClick={this.state.startIndexViewVacancies && this.handleBackIndex}>
                    </div>
                </div>
                <VacancyList vacancies={viewVacancies} />
                <div className={b('arrow-container')}>
                    <div className={b('arrow', {direction : 'right'})}
                        onClick={((this.state.startIndexViewVacancies + this.state.amountViewVacancies) < vacancies.length) && this.handleNextIndex}>
                    </div>
                </div>
            </div>
        )
    }
}

function mapStateToProps(state) {
    return {
        vacancies: state.vacancies.vacancies,
    }
}

function mapDispatchToProps(dispatch) {
    const actions = {
        loadTestVacancies: vacanciesActions.loadTestVacancies,
        loadAllVacancies: vacanciesActions.loadAllVacancies,
    }
    return bindActionCreators(actions, dispatch)
}

export default connect(mapStateToProps, mapDispatchToProps)(Vacancies)