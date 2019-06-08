import React from 'react';

import ApResumes from './view/ap/Resumes';
import McResumes from './view/mc/Resumes';

import ApResume from './view/ap/Resume';
import McResume from './view/mc/Resume';

export const Resumes = {
  ap: <ApResumes />,
  mc: <McResumes />,
};

export const Resume = {
  ap: resumeID => <ApResume resumeID={resumeID} />,
  mc: resumeID => <McResume resumeID={resumeID} />,
};

export { actions, reducer } from './redux';