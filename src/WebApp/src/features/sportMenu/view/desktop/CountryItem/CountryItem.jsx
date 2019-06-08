import React from 'react';
import block from 'bem-cn';
import PropTypes from 'prop-types';
import { NavLink } from 'react-router-dom';
import SVGInline from 'react-svg-inline';

import getFlagSVG from 'shared/utils/countries';
import './CountryItem.scss';

export const CountryItem = ({ text, id, sportID }) => {
  const b = block('country-item');
  const svg = getFlagSVG(id);
  return (
    <li className={b()}>
      <NavLink
        className={b('link').toString()}
        to={`/line/sport${sportID}/country${id}`}
        activeClassName={b('link', { active: true }).toString()}
      >
        <SVGInline className={b('flag')} svg={svg} />
        <span className={b('text')}>{text}</span>
      </NavLink>
    </li>
  );
};

CountryItem.propTypes = {
  text: PropTypes.string.isRequired,
  id: PropTypes.number.isRequired,
  sportID: PropTypes.number.isRequired,
};