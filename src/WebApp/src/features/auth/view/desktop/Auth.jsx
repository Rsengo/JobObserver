import React from 'react';
import block from 'bem-cn';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import PropTypes from 'prop-types';

import { actions as authActions } from '../../redux';
import SignIn from './SignIn/SignIn';
import SignUp from './SignUp/SignUp';
import './Auth.scss';

class Auth extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      isSignIn: true,
    };
  }

  static propTypes = {
    locale: PropTypes.object,
    lang: PropTypes.string.isRequired,
    signIn: PropTypes.func.isRequired,
    isSignIn: PropTypes.bool.isRequired,
    sendToPhoneCode: PropTypes.func.isRequired,
  }

  componentDidMount() {
    this.setState({ isSignIn: this.props.isSignIn });
  }

  render() {
    const b = block('auth');
    const { locale, lang, signIn, sendToPhoneCode } = this.props;
    const { isSignIn } = this.state;
    return (
      <div className={b()}>
        <div className={b('switcher')}>
          <div className={b('switch-item', { active: !isSignIn })} onClick={() => this.switchAuthType(false)}>{locale.registration}</div>
          <div className={b('switch-item', { active: isSignIn })} onClick={() => this.switchAuthType(true)}>{locale.authorization}</div>
        </div>
        <div className={b('content')}>
          {isSignIn ?
            <div className={b('sign-in')}>
              <SignIn
                locale={locale}
                signIn={signIn}
              />
            </div>
            :
            <div className={b('sign-up')}>
              <SignUp
                locale={locale}
                sendToPhoneCode={sendToPhoneCode}
                // signUp={signUp}
              />
            </div>
          }
        </div>
      </div>
    );
  }

  switchAuthType = value => this.setState({ isSignIn: value });
}

function mapStateToProps(state) {
  return {
    lang: state.userSettings.lang,
    locale: state.locale.auth,
  };
}

function mapDispatchToProps(dispatch) {
  const actions = {
    signIn: authActions.signIn,
    sendToPhoneCode: authActions.sendToPhoneCode,
  };
  return bindActionCreators(actions, dispatch);
}

export default connect(mapStateToProps, mapDispatchToProps)(Auth);