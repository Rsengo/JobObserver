import React from 'react';
import block from 'bem-cn';
import PropTypes from 'prop-types';

import './Spinner.scss';

export const Spinner = ({ isLoading, size = 'default' }) => {
  const b = block('spinner');
  return isLoading ? (
    <div className={b('wrapper', { loading: isLoading })}>
      <svg className={b({ size, loading: isLoading })} viewBox="0 0 50 50">
        <circle className={b('circle')} cx="25" cy="25" r="20" fill="none" strokeWidth="5" />
      </svg>
    </div>
  ) : '';
};

Spinner.propTypes = {
  isLoading: PropTypes.bool.isRequired,
  size: PropTypes.string,
};