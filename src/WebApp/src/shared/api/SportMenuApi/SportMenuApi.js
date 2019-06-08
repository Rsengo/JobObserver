import BaseApi from '../BaseApi';
import { SportMenuConverter } from './SportMenuConverter';

class SportMenuApi extends BaseApi {
  constructor(baseUrl) {
    super(baseUrl);
    this.baseUrl = `${baseUrl}/api/remote/admin/api/`;
    this.converter = new SportMenuConverter();
  }

  getSports = shortLang => {
    return this.sendLineQuery(
      this.queryTypes.GET,
      `${this.baseUrl}/line/${shortLang}/sports`,
      null, null,
      this.converter.convertSports,
    );
  }

  getCountries = (id, shortLang) => {
    return this.sendLineQuery(
      this.queryTypes.GET,
      `${this.baseUrl}/line/${shortLang}/countries/sport${id}`,
    );
  }
}

export default SportMenuApi;