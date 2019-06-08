import AuthApi from './AuthApi';
import ResumeApi from './ResumeApi';
import UserSettingsApi from './UserSettingsApi';
import VacancyApi from './VacancyApi';

class Api {
  constructor(baseUrl = '') {
    this.auth = new AuthApi(baseUrl);
    this.resume = new ResumeApi(baseUrl);
    this.userSettings = new UserSettingsApi(baseUrl);
    this.vacancy = new VacancyApi(baseUrl);
  }
}

export default Api;
