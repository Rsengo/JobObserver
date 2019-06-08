import React from 'react';
import block from 'bem-cn';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import PropTypes from 'prop-types';

import { actions as userSettingsActions } from 'features/userSettings';
import SetLanguage from 'components/SetLanguage/desktop';
import Button from 'components/Button/desktop';
import LinkMenu from './LinkMenu';
import MainMenu from './MainMenu';
import { SubHeader } from './SubHeader';
import logo from '../img/logo3.png';
import Time from './Time';

import './Header.scss';

const Header = ({ locale, changeLang, lang, changeOpenAuthModal, logOutFunc }) => {
  const b = block('header');
  return (
    <header className={b()}>
      <div className={b('main')}>
        <div className={b('left')}>
          <div className={b('logo-bg')}>
            <Link className={b('logo-click')} to="/">
              <img className={b('image')} src={logo} alt="" />
            </Link>
          </div>
        </div>
        <div className={b('right')}>
          <div className={b('bottom')}>
            <div className={b('bottom-left')}>
              <MainMenu locale={locale} />
            </div>
            <div className={b('bottom-right')}>
              <Time />
              <div className={b('separator')} />
              <div className={b('language')}>
                <Button callBack={logOutFunc}
                  text={locale.logout}
                  size="low" />
              </div>
            </div>
          </div>
        </div>
      </div>
    </header>
  );
};

Header.propTypes = {
  locale: PropTypes.object,
  lang: PropTypes.string.isRequired,
  logOutFunc: PropTypes.func.isRequired,
  
  changeLang: PropTypes.func.isRequired,
  changeOpenAuthModal: PropTypes.func.isRequired,
};

function mapStateToProps(state) {
  return {
    locale: state.locale.common,
    lang: state.userSettings.lang,
  };
}

function mapDispatchToProps(dispatch) {
  const actions = {
    changeLang: userSettingsActions.changeLang,
  };
  return bindActionCreators(actions, dispatch);
}

export default connect(mapStateToProps, mapDispatchToProps)(React.memo(Header));