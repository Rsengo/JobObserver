import React from 'react';
import block from 'bem-cn';
import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';

import Input from 'components/Input/desktop';
import CheckBox from 'components/CheckBox/desktop';
import Button from 'components/Button/desktop';
import CurrencySelector from '../CurrencySelector/CurrencySelector';
import PhoneInput from '../PhoneInput/PhoneInput';
import './PhoneRegistration.scss';

class PhoneRegistration extends React.Component {
  state = {
    phone: '',
    code: '',
    currency: 'RUB',
    password: '',
    repeatPassword: '',
    isAccept: false,
    isOpenAllInputs: false,
  };

  static propTypes = {
    locale: PropTypes.object,
    sendToPhoneCode: PropTypes.func.isRequired,
  }

  onChangeListener = e => this.setState({ [e.currentTarget.name]: e.currentTarget.value });

  onChangePhone = value => this.setState({ phone: value });

  onChangeCurrency = value => this.setState({ currency: value });

  onChangeAccept = value => this.setState({ isAccept: value });

  onChangeOpenedAllInputs = value => this.setState({ isOpenAllInputs: value });

  render() {
    const b = block('phone-registration');
    const { locale, sendToPhoneCode } = this.props;
    const { phone, code, currency, password, repeatPassword, isAccept, isOpenAllInputs } = this.state;
    const validation = this.checkValidation();
    return (
      <div className={b()}>
        <div className={b('row')}>
          <label className={b('group')}>
            <div className={b('group-title')}>
              {locale.numberPhone}
              <span className={b('require')}>*</span>
            </div>
            <div className={b('input-container')}>
              <PhoneInput
                callBack={this.onChangePhone}
              />
            </div>
          </label>
          <div className={b('group')}>
            {isOpenAllInputs ?
              <React.Fragment>
                <div className={b('group-title')}>
                  {locale.currencyBets}
                </div>
                <div className={b('select-container')}>
                  <CurrencySelector
                    itemsList={[{ value: 'RUB', text: 'РУБ' }, { value: 'USD', text: 'ДОЛ' }, { value: 'EUR', text: 'ЕВР' }]}
                    activeValue={currency}
                    callBack={this.onChangeCurrency} />
                </div>
              </React.Fragment> :
              <React.Fragment>
                <div className={b('code-button')}>
                  <Button
                    callBack={() => sendToPhoneCode(phone, () => this.onChangeOpenedAllInputs(true))}
                    text={locale.sendCode}
                    size="low"
                    disabled={!validation}
                  />
                </div>
                <div className={b('code-button')}>
                  <Button
                    callBack={() => this.onChangeOpenedAllInputs(true)}
                    text={locale.iHaveCode}
                    size="low"
                    disabled={!validation}
                    color="blue"
                  />
                </div>
              </React.Fragment>
          }
          </div>
        </div>
        {isOpenAllInputs && <React.Fragment>
          <div className={b('row')}>
            <label className={b('group')}>
              <div className={b('group-title')}>
                {locale.inputPassword}
                <span className={b('require')}>*</span>
              </div>
              <div className={b('input-container')}>
                <Input
                  type="password"
                  value={password}
                  name="password"
                  callBack={this.onChangeListener}
                />
              </div>
            </label>
            <label className={b('group')}>
              <div className={b('group-title')}>
                {locale.repeatPassword}
                <span className={b('require')}>*</span>
              </div>
              <div className={b('input-container')}>
                <Input
                  type="password"
                  value={repeatPassword}
                  name="repeatPassword"
                  callBack={this.onChangeListener}
                />
              </div>
            </label>
          </div>
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
              disabled={!validation}
            />
          </div>
        </React.Fragment>}
      </div>
    );
  }

  checkValidation = () => {
    // const { email, currency, password, repeatPassword, isAccept } = this.state;
    // if (email.split('').findIndex(temp => temp === '@') === -1 || email.split('').findIndex(temp => temp === '.') === -1) {
    //   return false;
    // }
    // if (password === '') {
    //   return false;
    // }
    // if (password !== repeatPassword) {
    //   return false;
    // }
    // if (!currency) {
    //   return false;
    // }
    // if (!isAccept) {
    //   return false;
    // }
    return true;
  }
}

export default PhoneRegistration;