import BaseApi from '../BaseApi';
import ResumeConverter from './VacancyConverter';

class VacancyApi extends BaseApi {
  constructor(baseUrl = '') {
    super(baseUrl);
    this.baseUrl = `${baseUrl}/api`;
    this.converter = new ResumeConverter();
  }

  loadCompanyVacancy = userID => this.sendQuery(
    this.queryTypes.GET,
    `${this.baseUrl}/v1/r/resumes/byApplicant/${userID}`,
    null, null,
  );

  loadVacancyyID = resumeID => this.sendQuery(
    this.queryTypes.GET,
    `${this.baseUrl}/v1/r/resumes/${resumeID}`,
    null, null,
  );

  updateVacancy = (resumeID, resume) => this.sendQuery(
    this.queryTypes.PUT,
    `${this.baseUrl}/v1/r/resumes/${resumeID}`,
    { ...resume }, null,
  )

  removeVacancy = vacancyID => this.sendQuery(
    this.queryTypes.PUT,
    `${this.baseUrl}/v1/r/resumes/`,
    null, null,
  )

  addVacancy = vacancy => this.sendQuery(
    this.queryTypes.PUT,
    `${this.baseUrl}/v1/r/resumes/`,
    null, null,
  )
}

export default VacancyApi;
