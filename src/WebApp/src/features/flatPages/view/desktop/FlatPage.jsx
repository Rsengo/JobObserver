import React from 'react';
import block from 'bem-cn';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';

class FlatPage extends React.Component {
  static propTypes = {
    name: PropTypes.string.isRequired,
    flatPagesList: PropTypes.array.isRequired,
  }

  render() {
    const b = block('flat-page');
    const { name, flatPagesList } = this.props;
    const { text } = flatPagesList.length ? this._getFlatPageByName(name) : '';
    return <article className={b()} dangerouslySetInnerHTML={{ __html: text }} />;
  }

  _getFlatPageByName = name => {
    const { flatPagesList } = this.props;
    let flatPage;
    flatPagesList.forEach(item => {
      if (item.idName === name) {
        flatPage = item;
      }
    });
    return flatPage;
  }
}

function mapStateToProps(state) {
  return {
    flatPagesList: state.flatPages.flatPagesList,
  };
}

export default connect(mapStateToProps)(FlatPage);