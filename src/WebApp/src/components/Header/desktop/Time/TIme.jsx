import React from 'react';
import block from 'bem-cn';
import dayjs from 'dayjs';

import './Time.scss';

const Time = () => {
  const b = block('time');
  return (
    <div className={b()}>
      <span className={b('time')}>{`${dayjs().format('HH')}:${dayjs().format('mm')}`}</span>
      <div className={b('right')}>
        <span className={b('day')}>{dayjs().format('dddd')}</span>
        <span className={b('date')}>{dayjs().format('DD.MM.YYYY')}</span>
      </div>
    </div>
  );
};

export default Time;