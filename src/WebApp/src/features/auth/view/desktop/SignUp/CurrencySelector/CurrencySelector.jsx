import React from 'react';
import block from 'bem-cn';
import PropTypes from 'prop-types';

import './CurrencySelector.scss';

class CurrencySelector extends React.Component {
  state = { isOpen: false };

  static propTypes = {
    itemsList: PropTypes.arrayOf(PropTypes.shape({
      value: PropTypes.string,
      text: PropTypes.string,
    })).isRequired,
    activeValue: PropTypes.string.isRequired,
    callBack: PropTypes.func.isRequired,
  }

  render() {
    const b = block('currency-selector');
    const { isOpen } = this.state;
    const { itemsList, activeValue, callBack } = this.props;
    const optionsList = itemsList.map(temp => activeValue !== temp.value && (
      <div key={temp.value} className={b('item')} onClick={() => callBack(temp.value)}>
        {temp.text}
      </div>
    ));
    return (
      <div className={b()} onClick={this.changeOpened}>
        <div className={b('active-item', { opened: isOpen ? 'open' : 'close' })}>
          {itemsList.find(temp => activeValue === temp.value).text}
        </div>
        <div className={b('additional-items')}>
          {isOpen && optionsList}
        </div>
      </div>
    );
  }

  changeOpened = () => this.setState(state => ({ isOpen: !state.isOpen }));
}

export default CurrencySelector;