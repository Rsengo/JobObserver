import React from 'react';
import block from 'bem-cn';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import { actions as sportMenuActions } from 'features/sportMenu';
import { getSportImgByID } from 'shared/utils/sports';
import { getSportColorByID } from 'shared/utils/sports';
import { SportItem } from './SportItem';

import BallPNG from '../img/ball.png';
import './SportMenu.scss';

class SportMenu extends React.Component {
  static propTypes = {
    sports: PropTypes.array.isRequired,
    countries: PropTypes.array.isRequired,
    locale: PropTypes.object.isRequired,
    collapsedID: PropTypes.number,
    sportsLoading: PropTypes.bool.isRequired,
    countriesLoading: PropTypes.bool.isRequired,
    lang: PropTypes.string.isRequired,

    getSports: PropTypes.func.isRequired,
    collapseSport: PropTypes.func.isRequired,
  }

  componentDidMount() {
    this.props.getSports();
  }

  componentWillReceiveProps(nextProps) {
    if (nextProps.lang !== this.props.lang) {
      this.props.getSports();
    }
  }

  render() {
    const b = block('sport-menu');
    const { sports, locale, collapsedID,
      collapseSport, sportsLoading, countriesLoading, countries } = this.props;
    const items = sports.map(sport => {
      const isCollapsed = sport.ID === collapsedID;
      const img = getSportImgByID(sport.ID);
      const color = getSportColorByID(sport.ID);
      return (
        <SportItem
          key={sport.ID}
          id={sport.ID}
          text={sport.text}
          isCollapsed={isCollapsed}
          collapseSport={collapseSport}
          countriesLoading={countriesLoading}
          countries={countries}
          locale={locale}
          img={img}
          color={color}
        />
      );
    });
    return (
      <nav className={b()}>
        <div className={b('caption')}>
          <img className={b('ball')} src={BallPNG} alt={locale.sport} />
          <span className={b('title')}>{locale.sport}</span>
        </div>
        <ul className={b('sport-list')}>
          {!sportsLoading ? items : `${locale.loading}...`}
        </ul>
      </nav>
    );
  }
}

function mapStateToProps(state) {
  return {
    sports: state.sportMenu.sports,
    locale: state.locale.line,
    lang: state.userSettings.lang,
    collapsedID: state.sportMenu.collapsedID,
    countriesLoading: state.sportMenu.countriesLoading,
    sportsLoading: state.sportMenu.sportsLoading,
    countries: state.sportMenu.countries,
  };
}

function mapDispatchToProps(dispatch) {
  const actions = {
    getSports: sportMenuActions.getSports,
    collapseSport: sportMenuActions.collapseSport,
  };
  return bindActionCreators(actions, dispatch);
}

export default connect(mapStateToProps, mapDispatchToProps)(SportMenu);