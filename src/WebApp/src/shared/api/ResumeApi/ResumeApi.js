import { remouteLanguages } from 'shared/utils/languages/languages';
import BaseApi from '../BaseApi';
import ResumeConverter from './ResumeConverter';

class ResumeApi extends BaseApi {
  constructor(baseUrl = '') {
    super(baseUrl);
    this.baseUrl = `${baseUrl}/api`;
    this.converter = new ResumeConverter();
  }

  loadUserResumes = userID => this.sendQuery(
    this.queryTypes.GET,
    `${this.baseUrl}/v1/r/resumes/byApplicant/${userID}`,
    null, null,
  );

  loadResumeByID = resumeID => this.sendQuery(
    this.queryTypes.GET,
    `${this.baseUrl}/v1/r/resumes/${resumeID}`,
    null, null,
  );

  updateResume = (resumeID, resume) => this.sendQuery(
    this.queryTypes.PUT,
    `${this.baseUrl}/v1/r/resumes/${resumeID}`,
    { ...resume }, null,
  )
}

export default ResumeApi;
