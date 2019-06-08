import React from 'react';
import block from 'bem-cn';
import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';

import CheckBox from 'components/CheckBox/desktop';
import Button from 'components/Button/desktop';
import './OneClickRegistration.scss';

class OneClickRegistration extends React.Component {
  state = { isAccept: true };

  static propTypes = {
    locale: PropTypes.object,
  }

  onChangeAccept = value => this.setState({ isAccept: value });

  render() {
    const b = block('one-click-registration');
    const { locale } = this.props;
    const { isAccept } = this.state;

    return (
      <div className={b()}>
        <div className={b('accept')}>
          <CheckBox checked={isAccept} callBack={this.onChangeAccept} />
          <div className={b('accept-text')}>
            {locale.iAssign}
            <Link to="/rules" className={b('link')}>
              {locale.terms}
            </Link>
          </div>
        </div>
        <div className={b('button')}>
          <Button
            callBack={f => f}
            text={locale.registration}
            size="low"
            disabled={!isAccept}
          />
        </div>
      </div>
    );
  }
}

export default OneClickRegistration;