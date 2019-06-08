import React from 'react';
import block from 'bem-cn';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';

import { Resume } from 'features/resumes';

class ResumeLayout extends React.Component {
  static propTypes ={
    match: PropTypes.object.isRequired,
    role: PropTypes.string.isRequired,
  }

  render() {
    const b = block('resume-layout');
    const { match, role } = this.props;
    const { resumeID } = match.params;
    return (
      <React.Fragment>
        {Resume[role](resumeID)}
      </React.Fragment>
    );
  }
}

function mapStateToProps(state) {
  return {
    role: state.auth.role,
  };
}

const mapDispatchToProps = dispatch => ({});

export default connect(mapStateToProps, mapDispatchToProps)(React.memo(ResumeLayout));
