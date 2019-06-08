import React from 'react';
import block from 'bem-cn';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import { Vacancies } from 'features/vacancies';

class VacanciesLayout extends React.Component {
  render() {
    const b = block('vacancies-layout');
    const { role } = this.props;
    console.log('хуй1')
    return (
      <div className={b()}>
        {Vacancies[role]}
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

export default connect(mapStateToProps, mapDispatchToProps)(React.memo(VacanciesLayout));
