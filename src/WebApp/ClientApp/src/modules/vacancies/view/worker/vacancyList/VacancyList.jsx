import React from 'react';
import { Component } from 'react';
import block from 'bem-cn';

import VacancyItem from '../vacancyItem/VacancyItem'

import './VacancyList.styl'

class VacancyList extends Component {
    render() {
        const b = block('vacancy-list')
        const { vacancies } = this.props;
        const vacanciesList = vacancies.map(vacancy =>
            <VacancyItem
             vacancy={vacancy} />
        )
        return (
            <div className={b()}>{vacanciesList}</div>
        )
    }
}

export default VacancyList