import React from 'react';
import block from 'bem-cn';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import './Resumes.scss';

class Resumes extends React.Component {
  static propTypes = {
  }

  render() {
    const b = block('resumes');
    return (
      <div className={b()}>
        Резюме для менеджера
      </div>
    );
  }
}

function mapStateToProps(state) {
  return {
  };
}

function mapDispatchToProps(dispatch) {

}

export default connect(mapStateToProps, mapDispatchToProps)(Resumes);