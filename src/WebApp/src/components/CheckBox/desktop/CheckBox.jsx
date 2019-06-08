import React from 'react';
import block from 'bem-cn';
import PropTypes from 'prop-types';

import checkImg from '../img/check.png';
import './CheckBox.scss';

const CheckBox = ({ checked, callBack }) => {
  const b = block('check-box');
  return (
    <div className={b()} onClick={() => callBack(!checked)}>
      {checked && <img src={checkImg} alt="" />}
    </div>
  );
};

CheckBox.propTypes = {
  callBack: PropTypes.func.isRequired,
  checked: PropTypes.bool.isRequired,
};

export default CheckBox;