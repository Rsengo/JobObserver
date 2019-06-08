import React from 'react';
import block from 'bem-cn';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import PropTypes from 'prop-types';

import { Profile } from 'features/profile';

class ProfileLayout extends React.Component {
  static propTypes ={
    role: PropTypes.string.isRequired,
  }

  render() {
    const b = block('resumes-layout');
    const { role } = this.props;
    return (
      <div className={b()}>
        {Profile[role]}
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

export default connect(mapStateToProps, mapDispatchToProps)(ProfileLayout);
