import React from 'react';
import block from 'bem-cn';
import PropTypes from 'prop-types';
import SVGInline from 'react-svg-inline';

import Input from 'components/Input/desktop';
import Button from 'components/Button/desktop';
import socialItems from '../../../data/social';
import './SignIn.scss';

class SignIn extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      phone: '',
      password: '',
    };
  }

  static propTypes = {
    signIn: PropTypes.func.isRequired,
    locale: PropTypes.object,
  }

  onChangeListener = e => this.setState({ [e.currentTarget.name]: e.currentTarget.value });

  onChangePhoneListener = e => e.currentTarget.value.split('').find(temp => !Number(temp) || temp === ' ') === undefined &&
    this.setState({ [e.currentTarget.name]: e.currentTarget.value });

  onSignInClick = () => this.props.signIn(this.state.phone, this.state.password);

  render() {
    const b = block('sign-in');
    const { phone, password } = this.state;
    const { locale } = this.props;

    const socialItemList = Object.values(socialItems).map(temp => (
      <SVGInline
        key={temp.route}
        svg={temp.img}
        className={b('social-item').toString()}
        onClick={() => window.open(`/api/user/login/${temp.route}`, '_self')} />
    ));

    const validation = phone.length && password.length;
    return (
      <article className={b()}>
        <div className={b('label')}>{`${locale.socialAuthorization}:`}</div>
        <section className={b('social')}>
          {socialItemList}
        </section>
        <label>
          <div className={b('label')}>{locale.inputPhone}</div>
          <div className={b('input')}>
            <Input
              value={phone}
              name="phone"
              placeholder={locale.phone}
              callBack={this.onChangePhoneListener}
            />
          </div>
        </label>
        <div className={b('label')}>{locale.inputPassword}</div>
        <div className={b('input')}>
          <Input
            value={password}
            name="password"
            placeholder={locale.password}
            callBack={this.onChangeListener}
            type="password"
          />
        </div>
        <div className={b('button')}>
          <Button
            callBack={this.onSignInClick}
            text={locale.login}
            size="low"
            disabled={!validation}
          />
        </div>
      </article>
    );
  }
}

export default SignIn;