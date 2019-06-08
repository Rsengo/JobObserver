import React from 'react';
import block from 'bem-cn';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import './Vacancy.scss';

class Vacancy extends React.Component {
  static propTypes = {
  }

  static contextTypes = {
    router: PropTypes.object,
  }

  render() {
    const b = block('vacancy');
    const { vacancyID } = this.props;
    return (
      <nav className={b()}>
        {`Вакансия для компании № ${vacancyID}`}
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

export default connect(mapStateToProps, mapDispatchToProps)(Vacancy);