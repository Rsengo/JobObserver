import React from 'react';
import block from 'bem-cn';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import './Vacancies.scss';

class Vacancies extends React.Component {
  static propTypes = {
  }

  render() {
    const b = block('vacancies');
    return (
      <nav className={b()}>
        Вакансии для компании
      </nav>
    );
  }
}

function mapStateToProps(state) {
  return {
    // sports: state.sportMenu.sports,
    // locale: state.locale.line,
    // lang: state.userSettings.lang,
    // collapsedID: state.sportMenu.collapsedID,
    // countriesLoading: state.sportMenu.countriesLoading,
    // sportsLoading: state.sportMenu.sportsLoading,
    // countries: state.sportMenu.countries,
  };
}

function mapDispatchToProps(dispatch) {

}

export default connect(mapStateToProps, mapDispatchToProps)(Vacancies);