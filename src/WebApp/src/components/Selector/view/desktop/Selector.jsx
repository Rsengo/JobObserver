import React, { useState } from 'react';
import block from 'bem-cn';
import PropTypes from 'prop-types';

import './Selector.scss';

const Selector = ({ itemsList, activeID, callBack, label, name, size = 'default' }) => {
  const b = block('selector');
  const [isOpen, changeOpen] = useState(false);
  itemsList = [{ id: null, name: 'Не выбрано' }, ...itemsList];
  const optionsList = itemsList.filter(temp => activeID !== temp.id).map(temp => (
    <div key={temp.id} className={b('item')} onClick={() => callBack(name, temp.id)}>
      {temp.name}
    </div>
  ));
  return (
    <div className={b({ size })} onClick={() => changeOpen(!isOpen)}>
      <div className={b('label')}>{label}</div>
      <div className={b('active-item', { opened: isOpen ? 'open' : 'close' })}>
        {itemsList.find(temp => activeID === temp.id).name}
      </div>
      <div className={b('additional-items')}>
        {isOpen && optionsList}
      </div>
    </div>
  );
};

Selector.propTypes = {
  itemsList: PropTypes.arrayOf(PropTypes.shape({
    ID: PropTypes.number,
    name: PropTypes.string,
  })).isRequired,
  activeID: PropTypes.string.isRequired,
  callBack: PropTypes.func.isRequired,
  label: PropTypes.string.isRequired,
  name: PropTypes.string.isRequired,
  size: PropTypes.string,
};

export default Selector;