import BaseApi from '../BaseApi';

class AuthApi extends BaseApi {
  constructor(baseUrl) {
    super(baseUrl);
    this.baseUrl = `${baseUrl}/api`;
  }

  signIn = (phone, password) => {
    return this.sendQuery(
      this.queryTypes.POST,
      `${this.baseUrl}/user/login/phone`,
      { phone, password },
    );
  }

  sendToPhoneCode = phone => {
    return this.sendQuery(
      this.queryTypes.POST,
      `${this.baseUrl}/user/phone/code`,
      { phone },
      { headers: { 'Content-Type': 'application/json' } },
    );
  }
}

export default AuthApi;