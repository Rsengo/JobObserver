import React from 'react';
import block from 'bem-cn';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import './Resume.scss';

class Resume extends React.Component {
  static propTypes = {
  }

  render() {
    const b = block('resume');
    const { resumeID } = this.props;
    return (
      <div className={b()}>
        Резюме для менеджера:{resumeID}
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

export default connect(mapStateToProps, mapDispatchToProps)(Resume);