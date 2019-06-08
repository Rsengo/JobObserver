import React from 'react';
import block from 'bem-cn';
import PropTypes from 'prop-types';

import './Button.scss';

const Button = ({ text, callBack, disabled = false, size = 'default', color = 'green' }) => {
  const b = block('button');
  return (
    <div className={b({ sizable: size }, { disable: disabled }, { colors: color })} onClick={disabled ? f => f : callBack}>
      {text}
    </div>
  );
};

Button.propTypes = {
  text: PropTypes.string.isRequired,
  callBack: PropTypes.func.isRequired,
  disabled: PropTypes.bool,
  size: PropTypes.string,
  color: PropTypes.string,
};

export default Button;