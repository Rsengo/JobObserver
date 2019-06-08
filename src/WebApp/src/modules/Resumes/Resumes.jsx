import React from 'react';
import { Route } from 'react-router-dom';

import ResumesLayout from './view/ResumesLayout/ResumesLayout';
import ResumeLayout from './view/ResumeLayout/ResumeLayout';

export class ResumesModule extends React.Component {
  getRoutes() {
    return (
      <Route key="resumes">
        <Route key="/resumes" path="/resumes" component={ResumesLayout} />
        <Route key="/resume/:resumeID" path="/resume/:resumeID" component={ResumeLayout} />
      </Route>
    );
  }
}