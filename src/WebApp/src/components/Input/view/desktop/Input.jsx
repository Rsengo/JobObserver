import React from 'react';
import block from 'bem-cn';
import PropTypes from 'prop-types';

import './Input.scss';

const Input = ({ value, name = '', callBack = t => t, placeholder, size = 'default', type = 'text', label = '', disabled = false }) => {
  const b = block('input');
  return (
    <div>
      <div className={b('label')}>{label}</div>
      <input
        type={type}
        name={name}
        value={value}
        placeholder={placeholder || ''}
        onChange={callBack}
        className={b({ sizable: size })}
        disabled={disabled}
      />
    </div>
  );
};

Input.propTypes = {
  value: PropTypes.oneOfType([PropTypes.string, PropTypes.number]).isRequired,
  name: PropTypes.string.isRequired,
  callBack: PropTypes.func.isRequired,
  placeholder: PropTypes.string,
  size: PropTypes.string,
  type: PropTypes.string,
  label: PropTypes.string,
  disabled: PropTypes.bool,
};

export default Input;