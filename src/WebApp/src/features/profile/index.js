import React from 'react';

import ApProfile from './view/ap/Profile';
import McProfile from './view/mc/Profile';
import MuProfile from './view/mu/Profile';

export const Profile = {
  ap: <ApProfile />,
  mc: <McProfile />,
  mu: <MuProfile />,
};

export { actions, reducer } from './redux';