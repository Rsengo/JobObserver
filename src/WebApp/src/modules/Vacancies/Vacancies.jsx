import React from 'react';
import { Route } from 'react-router-dom';

import VacanciesLayout from './view/VacanciesLayout/VacanciesLayout';
import VacancyLayout from './view/VacancyLayout/VacancyLayout';

export class VacanciesModule extends React.Component {
  getRoutes() {
    return (
      <Route key="vacancies">
        <Route key="/vacancies" path="/vacancies" component={VacanciesLayout} />
        <Route key="/vacancy/:vacancyID" path="/vacancy/:vacancyID" component={VacancyLayout} />
      </Route>
    );
  }
}