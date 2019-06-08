import { remouteLanguages } from 'shared/utils/languages/languages';
import FullEventLineConverter from './FullEventLineConverter';
import FullEventLiveConverter from './FullEventLiveConverter';

class FullEventApi {
  _timestamp = 0;

  constructor(actions, baseUrl = '') {
    this.actions = actions;
    this.baseUrl = baseUrl;
    this.lineConverter = new FullEventLineConverter();
    this.liveConverter = new FullEventLiveConverter();
  }

  async loadFullEventLine(eventID, lang) {
    const remouteLang = remouteLanguages[lang];
    const response = await this.actions.get(
      `${this.baseUrl}/api/remote/admin/api/line/${remouteLang}/event/${eventID}`,
    );
    const success = response.data != null;
    const convertedEvent = success ? this.lineConverter.convertFullEvent(response.data) : null;
    const resultResponse = {
      success,
      data: convertedEvent,
      errorMessage: success ? null : '',
    };
    return resultResponse;
  }

  async loadFullEventLive(eventID, lang) {
    const remouteLang = remouteLanguages[lang];
    const response = await this.actions.get(
      `${this.baseUrl}/api/remote/admin/api/live/${remouteLang}/event/${eventID}`,
    );
    const success = (response.data != null && response.data !== []);
    const convertedEvent = success ? this.liveConverter.convertFullEvent(response.data) : null;
    const resultResponse = {
      success,
      data: convertedEvent,
      errorMessage: success ? null : '',
    };
    this._timestamp = response.data.TimeStamp;
    return resultResponse;
  }

  async loadStatisticList(sportID, tourneyID, fullEventID, lang, isLive) {
    const remouteLang = remouteLanguages[lang];
    const response = await this.actions.get(
      `${this.baseUrl}/api/remote/admin/api/${isLive}/${remouteLang}/extgames/sport${sportID}/tourney${tourneyID}/${fullEventID}`,
    );
    const success = response.data != null;
    const statisticList = success ? response.data : null;
    return this.lineConverter.convertorStaticticList(statisticList);
  }

  async updateFullEventLive(eventID, lang, previewEventCoefs = null) {
    const remouteLang = remouteLanguages[lang];
    const response = await this.actions.get(
      `${this.baseUrl}/api/remote/admin/api/live/${remouteLang}/event/${eventID}/${Date.now()}`,
    );
    const success = response.data != null;
    const convertedEvent = success ? this.liveConverter.convertFullEvent(response.data, previewEventCoefs) : null;
    const resultResponse = {
      success,
      data: convertedEvent,
      errorMessage: success ? null : '',
    };
    this._timestamp = response.data.TimeStamp;
    return resultResponse;
  }
}

export default FullEventApi;
