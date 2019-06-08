import { remouteLanguages } from 'shared/utils/languages/languages';
import LineConverter from './LineConverter';

class LineApi {
  _timestamp = 0;

  constructor(actions, baseUrl = '') {
    this.actions = actions;
    this.baseUrl = baseUrl;
    this.lineConverter = new LineConverter();
  }

  async loadLineTourneys(sportID, countryID, lang) {
    const remouteLang = remouteLanguages[lang];
    const response = await this.actions.get(
      `${this.baseUrl}/api/remote/admin/api/line/${remouteLang}/tournaments/sport${sportID}/country${countryID}`,
    );
    const success = response.data != null;
    const convertedEvent = success ? this.lineConverter.convertorLineTourneys(response.data) : null;
    const resultResponse = {
      success,
      data: convertedEvent,
      errorMessage: success ? null : '',
    };
    return resultResponse;
  }

  async loadEventsByTourney({ sportID, countryID, tourneyID }, lang) {
    const remouteLang = remouteLanguages[lang];
    const url = `${this.baseUrl}/api/remote/admin/api/line/${remouteLang}/events/sport${sportID}/country${countryID}/tourney${tourneyID}`;
    const tourneyResponse = await this.actions.get(url);
    const events = tourneyResponse.data.length > 0 ? tourneyResponse.data : [];
    const convertedEvents = this.lineConverter.convertorLineEvents(events);
    return convertedEvents;
  }

  async loadTopEvents(lang) {
    const remouteLang = remouteLanguages[lang];
    const url = `${this.baseUrl}/api/remote/admin/api/line/${remouteLang}/topevents`;
    const response = await this.actions.get(url);
    const events = response.data;
    const convertedEvents = this.lineConverter.convertorTopEvents(events);
    return convertedEvents;
  }
}

export default LineApi;
