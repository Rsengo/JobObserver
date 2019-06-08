import React from 'react';
import block from 'bem-cn';
import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';

import './SubHeader.scss';

export const SubHeader = ({ flatPagesList }) => {
  const b = block('subheader');
  return (
    <nav className={b()}>
      <ul className={b('list')}></ul>
    </nav>
  );
};

SubHeader.propTypes = {
  flatPagesList: PropTypes.array.isRequired,
};