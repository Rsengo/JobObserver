import React from 'react';
import block from 'bem-cn';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import './Profile.scss';

class Profile extends React.Component {
  static propTypes = {
  }

  render() {
    const b = block('profile');
    return (
      <div className={b()}>
        Профиль Менеджера вуза
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

export default connect(mapStateToProps, mapDispatchToProps)(Profile);