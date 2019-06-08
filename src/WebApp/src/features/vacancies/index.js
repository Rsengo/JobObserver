import React from 'react';

import ApVacancies from './view/ap/Vacancies';
import McVacancies from './view/mc/Vacancies';

import ApVacancy from './view/ap/Vacancy';
import McVacancy from './view/mc/Vacancy';

export const Vacancies = {
  ap: <ApVacancies />,
  mc: <McVacancies />,
};

export const Vacancy = {
  ap: vacancyID => <ApVacancy vacancyID={vacancyID} />,
  mc: vacancyID => <McVacancy vacancyID={vacancyID} />,
};

export { actions, reducer } from './redux';