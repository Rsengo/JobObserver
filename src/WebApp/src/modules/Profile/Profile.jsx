import React from 'react';
import { Route } from 'react-router-dom';

import ProfileLayout from './view/ProfileLayout/ProfileLayout';

export class ProfileModule extends React.Component {
  getRoutes() {
    return (
      <Route key="profile">
        <Route key="/profile" path="/profile" component={ProfileLayout} />
      </Route>
    );
  }
}