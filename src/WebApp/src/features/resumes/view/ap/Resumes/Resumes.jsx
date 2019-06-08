import React from 'react';
import block from 'bem-cn';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import { actions as resumeActions } from '../../../redux';

import './Resumes.scss';

class Resumes extends React.Component {
  static propTypes = {
    resumes: PropTypes.array.isRequired,
    loadUserResumes: PropTypes.func.isRequired,
  }

  componentWillMount() {
    const { loadUserResumes } = this.props;
    loadUserResumes();
  }

  render() {
    const b = block('ap-resumes');
    const { resumes } = this.props;
    return (
      <div className={b()}>
        {resumes.length}
      </div>
    );
  }
}

function mapStateToProps(state) {
  return {
    resumes: state.resume.resumes,
  };
}

function mapDispatchToProps(dispatch) {
  const actions = {
    ...resumeActions,
  };
  return bindActionCreators(actions, dispatch);
}

export default connect(mapStateToProps, mapDispatchToProps)(Resumes);