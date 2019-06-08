import React from 'react';
import block from 'bem-cn';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import { actions as profileActions } from '../../../redux';

import './Profile.scss';

class Profile extends React.Component {
  static propTypes = {
  }

  componentWillMount() {
    
  }

  render() {
    const b = block('profile');
    return (
      <section className={b()}>
        Профиль соискателя
      </section>
    );
  }
}

function mapStateToProps(state) {
  return {
  };
}

function mapDispatchToProps(dispatch) {
  const actions = {
    ...profileActions,
  };
  return bindActionCreators(actions, dispatch);
}

export default connect(mapStateToProps, mapDispatchToProps)(Profile);