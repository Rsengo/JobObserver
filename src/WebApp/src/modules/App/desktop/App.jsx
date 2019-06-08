import React from 'react';
import block from 'bem-cn';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import PropTypes from 'prop-types';

import { actions as userSettingsActions } from 'features/userSettings';
import { actions as flatPagesActions } from 'features/flatPages';

import Auth from 'features/auth/desktop';
import { addNotify } from 'features/notify';
import Notify from 'features/notify/desktop';
import Header from 'components/Header/desktop';
import Footer from 'components/Footer/desktop';
import Modal from 'components/Modal/desktop';
import './App.scss';

class App extends React.Component {
  state = { authModal: { isOpen: false, isSignIn: true } };

  static propTypes = {
    lang: PropTypes.string.isRequired,
    locale: PropTypes.object.isRequired,
    children: PropTypes.node.isRequired,
    flatPagesList: PropTypes.array.isRequired,

    getFlatPages: PropTypes.func.isRequired,
    changeLang: PropTypes.func.isRequired,
  }

  componentDidMount() {
    const { changeLang, lang, loadDictionaries } = this.props;
    changeLang(lang);
    loadDictionaries();
  }

  componentWillReceiveProps(nextProps) {
  }

  render() {
    const b = block('app');
    const { locale, children, flatPagesList } = this.props;
    const { authModal } = this.state;
    return (
      <div className={b()}>
        <Notify />
        {authModal.isOpen && <Modal closeFunction={() => this.changeOpenAuthModal(false)} widthContent="30%">
          <Auth isSignIn={authModal.isSignIn} />
        </Modal>}
        <Header changeOpenAuthModal={this.changeOpenAuthModal} />
        <main className={b('main')}>
          <div className={b('main-wrapper')}>
            {/* <div className={b('main-left')}>
            </div> */}
            <div className={b('main-center')}>
              {children}
            </div>
            {/* <div className={b('main-right')}></div> */}
          </div>
        </main>
        <Footer locale={locale} flatPagesList={flatPagesList} />
      </div>
    );
  }

  changeOpenAuthModal = (visible, isOpenSignIn = this.state.isSignIn) => this.setState(
    {
      authModal: {
        isOpen: visible,
        isSignIn: isOpenSignIn,
      },
    },
  )
}

function mapStateToProps(state) {
  return {
    lang: state.userSettings.lang,
    locale: state.locale.common,
  };
}

function mapDispatchToProps(dispatch) {
  const actions = {
    changeLang: userSettingsActions.changeLang,
    loadDictionaries: userSettingsActions.loadDictionaries,
    addNotify,
  };
  return bindActionCreators(actions, dispatch);
}

export default connect(mapStateToProps, mapDispatchToProps)(App);