import { remouteLanguages } from 'shared/utils/languages/languages';
import BaseApi from '../BaseApi';
import UserSettingsConverter from './UserSettingsConverter';

class UserSettingsApi extends BaseApi {
  constructor(baseUrl = '') {
    super(baseUrl);
    this.baseUrl = `${baseUrl}/api`;
    this.converter = new UserSettingsConverter();
  }

  loadDictionaries = () => this.sendQuery(
    this.queryTypes.GET,
    `${this.baseUrl}/v1/d/dictionaries`,
    null, null,
  );
}

export default UserSettingsApi;
