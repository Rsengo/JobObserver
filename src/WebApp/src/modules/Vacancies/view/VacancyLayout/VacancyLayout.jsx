import React from 'react';
import block from 'bem-cn';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import PropTypes from 'prop-types';

import { Vacancy } from 'features/vacancies/index';

class VacancyLayuot extends React.Component {
  static propTypes ={
    match: PropTypes.object.isRequired,
  }

  render() {
    const b = block('vacancy-layout');
    const { match, role } = this.props;
    const { vacancyID } = match.params;
    console.log('хуй')
    return (
      <div className={b()}>
        {Vacancy[role](vacancyID)}
      </div>
    );
  }
}

function mapStateToProps(state) {
  return {
    role: state.auth.role,
  };
}

const mapDispatchToProps = dispatch => ({});

export default connect(mapStateToProps, mapDispatchToProps)(React.memo(VacancyLayuot));
